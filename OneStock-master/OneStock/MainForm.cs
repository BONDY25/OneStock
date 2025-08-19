using System.Data;
using System.Data.SqlClient;


namespace OneStock
{
    public partial class MainForm : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        // Declare Global Variables
        public string userName { get; set; }
        public string sessionId { get; set; }
        public string globalClient = "";
        public string globalPart = "";
        public string globalBarcode = "";

        // Set SQL Connection String
        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public MainForm()
        {
            InitializeComponent();
            Text = $"Home - {Environment.UserName.ToUpper()}";
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = userName; // Show Username
            SessionMaintenance.LogBook("", "[MainForm]", "[FormLoad]", "Application Started", lblLogBook);
            PopulateComboBoxes(cbClient, "CLIENT");
            cbClient.SelectedItem = null;
            txbSearch.Text = "";
            ClearFields();
            pbBorga.Image = Properties.Resources.OnestockBorgaBlack;
        }

        // Exit Application Method -----------------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
                if (result == true)
                {
                    txbSearch.Text = "";
                    ClearFields();
                    SessionMaintenance.LogBook("", "[MainForm]", "[FormClosing]", "Application Closed");
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        // Application Closed -----------------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SessionMaintenance.ClearSessionID(sessionId);
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Populate Combo Boxes -----------------------------------------------------------------------------------------------------------------------
        private void PopulateComboBoxes(ComboBox comboBox, string field)
        {
            // Declare Variables
            string query = "";

            if (field == "CLIENT")
            {
                query = "SELECT [Description] FROM OneStock_Clients WHERE [Active] = '1' ORDER BY [Description]";
            }

            try
            {
                // Execute SQL Command 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    // Combo Box //
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox.Items.Clear(); // Clear Combo box ready for new data

                            // Populate ComboBox from reader
                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader["Description"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting ComboBox values: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[PopulateComboBoxes]", $"FAILED ( {ex.Message} )", lblLogBook);
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[PopulateComboBoxes]", "Application Closed", lblLogBook);
                Application.Exit();
            }
        }

        // Check Part -----------------------------------------------------------------------------------------------------------------------
        private int CheckPart()
        {
            string client = null;
            string search = txbSearch.Text;
            string query = "EXECUTE [OneStock_Check_Part] @Client, @Search";
            int count = 0;
            // Check Client Field
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Search", search);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                count = (int)reader["Result"]; // Populate variable
                            }
                        }
                    }

                    conn.Close();
                }

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting part data: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[GetPart]", $"FAILED ( {ex.Message} )", lblLogBook);
            }

            return count;
        }

        // Get Part -----------------------------------------------------------------------------------------------------------------------
        public void GetPart()
        {
            string client = null;
            string search = txbSearch.Text;
            string part = "";

            string query = "EXECUTE [OneStock_Search] @Client, @Search";

            // Check Client Field
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Search", search);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                part = reader["Result"].ToString(); // Populate variable
                            }
                        }
                    }

                    conn.Close();
                }

                if (part == "NO RESULT")
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"No results found for search term: {search}.");
                    ClearFields();
                    return;
                }
                else
                {
                    globalPart = part;
                    globalClient = client;

                    GetHeaders(client, part);
                    PopulateTables(client, part, dgStock, 1);
                    PopulateTables(client, part, dgPoBreak, 2);
                    PopulateTables(client, part, dgScripts, 3);
                    GetDueDate(part);

                    SessionMaintenance.LogBook("", "[MainForm]", "[GetPart]", $"Part data retrieved for {part}", lblLogBook);
                }
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting part data: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[GetPart]", $"FAILED ( {ex.Message} )", lblLogBook);
            }
        }

        // Get DueDate -----------------------------------------------------------------------------------------------------------------------
        private void GetDueDate(string part)
        {
            string query = "EXECUTE [OneStock_Get_Del_Date] @Session_Id, @Part";
            DateTime dtDueDate = new DateTime(2050, 12, 31);
            int pram = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Part", part);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal("Delivery_Date")))
                                    dtDueDate = reader.GetDateTime(reader.GetOrdinal("Delivery_Date"));
                                pram = (int)reader["Pram"];
                            }
                        }
                    }

                    conn.Close();
                }

                switch (pram)
                {
                    case 0: lblDueDate.BackColor = Color.Lime; lblDueDate.ForeColor = Color.Black; break;
                    case 1: lblDueDate.BackColor = Color.Yellow; lblDueDate.ForeColor = Color.Black; break;
                    case 2: lblDueDate.BackColor = Color.Red; lblDueDate.ForeColor = Color.Black; break;
                    default: lblDueDate.BackColor = Color.Black; break;
                }
                switch (dtDueDate.ToString("dd/MM/yyyy"))
                {
                    case "31/12/2050": lblDueDate.Text = $""; lblDueDate.BackColor = Color.Black; lblDueDate.Visible = false; break;
                    default: lblDueDate.Text = $"{dtDueDate.ToString("dd/MM/yyyy")}"; lblDueDate.Visible = true; break;
                }

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting Promise Date: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[GetDueDate]", $"FAILED ( {ex.Message} )", lblLogBook);
            }
        }

        // Get Headers -----------------------------------------------------------------------------------------------------------------------
        private void GetHeaders(string client, string part)
        {
            string query = "EXECUTE [OneStock_Get_Part] @Session_Id, @Client, @Part";
            string descr = "";
            string status = "";
            string obsCode = "";
            string attr1 = "";
            string attr2 = "";
            string barcode = "";
            string freeStock = "";
            string qtyOh = "";
            string qtyQuar = "";
            string qtyAloc = "";
            string qtyDem = "";
            string qtyGi = "";
            string qtyOnOrd = "";
            string qtyDesp = "";
            double freeStockQty = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Part", part);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                descr = reader["Description"].ToString();
                                status = reader["Status"].ToString();
                                obsCode = reader["Obs_Code"].ToString();
                                attr1 = reader["Attr_1"].ToString();
                                attr2 = reader["Attr_2"].ToString();
                                barcode = reader["Barcode"].ToString();
                                freeStock = reader["Free_Stock"].ToString();
                                freeStockQty = (double)reader["Free_Stock"];
                                qtyOh = reader["QTY_OH"].ToString();
                                qtyQuar = reader["QTY_QUAR"].ToString();
                                qtyAloc = reader["QTY_Aloc"].ToString();
                                qtyDem = reader["QTY_Dem"].ToString();
                                qtyGi = reader["QTY_GI"].ToString();
                                qtyOnOrd = reader["QTY_On_Ord"].ToString();
                                qtyDesp = reader["QTY_Desp"].ToString();
                            }
                        }
                    }

                    conn.Close();
                }

                txbSku.Text = $"{part} - {barcode}";
                lblDescription.Text = $"{descr}";
                lblStatus.Text = $"Status: {status}";
                lblObsCode.Text = $"Obs Code: {obsCode}";
                lblAttr1.Text = $"Attribute 1: {attr1}";
                lblAttr2.Text = $"Attribute 2: {attr2}";
                lblFreeStock.Text = $"{freeStock}";
                lblOnHand.Text = $"On Hand: {qtyOh}";
                lblOnOrder.Text = $"On Order: {qtyOnOrd}";
                lblDemand.Text = $"Demand: {qtyDem}";
                lblAloc.Text = $"Allocated: {qtyAloc}";
                lblQuar.Text = $"Quarantine: {qtyQuar}";
                lblGoodsIn.Text = $"Goods In: {qtyGi}";
                lblDesp.Text = $"In Despatch: {qtyDesp}";

                globalBarcode = barcode;

                switch (freeStockQty)
                {
                    case <= 0: lblFreeStock.BackColor = Color.Red; lblFreeStock.ForeColor = Color.Black; break;
                    default: lblFreeStock.BackColor = Color.Lime; lblFreeStock.ForeColor = Color.Black; break;
                }

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting part headers: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[GetHeaders]", $"FAILED ( {ex.Message} )", lblLogBook);
            }
        }

        // Get Part -----------------------------------------------------------------------------------------------------------------------
        private void PopulateTables(string client, string part, DataGridView dataGrid, int field)
        {
            string query = "";
            DataTable dataTable = new DataTable();

            switch (field)
            {
                case 1: query = "EXECUTE [OneStock_Get_Stock] @Session_Id, @Client, @Part"; break;
                case 2: query = "EXECUTE [OneStock_Get_PO] @Session_Id, @Client, @Part"; break;
                case 3: query = "EXECUTE [OneStock_Get_Scripts] @Session_Id, @Client, @Part"; break;
            }

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Part", part);

                        // Execute Query
                        cmd.ExecuteNonQuery();

                        // Execute Data Reader
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Populate DataTable From Reader
                        dataTable.Load(reader);
                    }

                    conn.Close(); // Close SQL Connection

                    // Populate Data Grid
                    dataGrid.DataSource = dataTable;
                    dataGrid.Refresh();
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred Populating DataGrids: {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[PopulateTable]", $"FAILED (  {ex.Message}  )", lblLogBook);
            }
        }

        // Clear Results -----------------------------------------------------------------------------------------------------------------------
        private void ClearResults()
        {
            string query = "EXECUTE [OneStock_Clear_Results] @Session_Id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred clearing results tables: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            ClearResults();


            txbSku.Text = "";
            lblDescription.Text = "";
            lblStatus.Text = "";
            lblObsCode.Text = "";
            lblAttr1.Text = "";
            lblAttr2.Text = "";
            lblFreeStock.Text = "";
            lblOnHand.Text = "";
            lblOnOrder.Text = "";
            lblDemand.Text = "";
            lblAloc.Text = "";
            lblQuar.Text = "";
            lblGoodsIn.Text = "";
            lblDesp.Text = "";
            lblDueDate.Text = "";

            lblFreeStock.BackColor = Color.Black;
            lblFreeStock.ForeColor = Color.White;
            lblDueDate.BackColor = Color.Black;
            lblDueDate.ForeColor = Color.White;

            dgPoBreak.DataSource = null;
            dgStock.DataSource = null;
            dgScripts.DataSource = null;

            dgPoBreak.Refresh();
            dgStock.Refresh();
            dgScripts.Refresh();

            txbSearch.Focus();
        }



        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Prevent Special Characters (txbUsername) --------------------------------------------------------------------------------------------------------------
        private void txbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here");
                e.Handled = true;
            }
        }



        // Client Field --------------------------------------------------------------------------------------------------------------
        private void cbClient_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.FocusEnter(cbClient);
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.FocusLeave(cbClient);
        }

        // Search Field --------------------------------------------------------------------------------------------------------------
        private void txbSearch_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.FocusEnter(txbSearch);

            SessionMaintenance.LogBook("", "[MainForm]", "[txbSearch_Enter]", "Field Entered", lblLogBook);
        }

        private void txbSearch_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.FocusLeave(txbSearch);

            SessionMaintenance.LogBook("", "[MainForm]", "[txbSearch_Leave]", "Field Left", lblLogBook);

            string search = txbSearch.Text;
            string client = null;
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }
            else
            {
                return;
            }

            if (!string.IsNullOrEmpty(search))
            {
                if (string.IsNullOrEmpty(client))
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"Client not selected, please select a client.");
                    cbClient.Focus();
                    return;
                }
                else
                {
                    if (CheckPart() > 1 || CheckPart() == 0)
                    {
                        SearchFrom searchFrom = new SearchFrom(this);
                        searchFrom.search = search;
                        searchFrom.sessionId = sessionId;
                        searchFrom.client = client;
                        searchFrom.userName = userName;
                        searchFrom.Show();
                        txbSearch.Text = "";
                    }
                    else
                    {
                        GetPart();
                    }
                }
            }
        }

        // Exit Button --------------------------------------------------------------------------------------------------------------
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnExit);
        }

        // Clear Button --------------------------------------------------------------------------------------------------------------
        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnClear);
        }

        // Cheese Borga --------------------------------------------------------------------------------------------------------------
        private void pbBorga_MouseEnter(object sender, EventArgs e)
        {
            pbBorga.Image = Properties.Resources.OnestockBorgaWhite;
        }

        private void pbBorga_MouseLeave(object sender, EventArgs e)
        {
            pbBorga.Image = Properties.Resources.OnestockBorgaBlack;
        }

        // LogBook Label --------------------------------------------------------------------------------------------------------------
        private void lblLogBook_MouseEnter(object sender, EventArgs e)
        {
            lblLogBook.ForeColor = Color.White;
            lblLogBook.BackColor = Color.Black;
        }

        private void lblLogBook_MouseLeave(object sender, EventArgs e)
        {
            lblLogBook.ForeColor = Color.Silver;
            lblLogBook.BackColor = Color.FromArgb(224, 224, 224);
        }

        // Move Button --------------------------------------------------------------------------------------------------------------
        private void btnMove_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnMove);
        }

        private void btnMove_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnMove);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Exit Button --------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();
            bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
            if (result == true)
            {
                SessionMaintenance.LogBook("", "[MainForm]", "[FormClosing]", "Application Closed", lblLogBook);
                txbSearch.Text = "";
                ClearFields();
                SessionMaintenance.ClearSessionID(sessionId);
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        // Script Breakdown --------------------------------------------------------------------------------------------------------------
        private void dgScripts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string notes = dgScripts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                ScriptForm scriptForm = new ScriptForm();
                scriptForm.sessionId = sessionId;
                scriptForm.notes = notes;
                scriptForm.part = globalPart;
                scriptForm.barcode = globalBarcode;
                scriptForm.Show();
            }
        }

        // LogBook Label --------------------------------------------------------------------------------------------------------------
        private void lblLogBook_Click(object sender, EventArgs e)
        {
            string message = lblLogBook.Text;
            CustomMessageBox messageBox = new CustomMessageBox();
            messageBox.ShowLogBook($"LogBook Activity Recorded For '{Environment.MachineName}.{Environment.UserName} \n{message}");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbSearch.Text = "";
            ClearFields();
        }

        // Cheese Borga Click --------------------------------------------------------------------------------------------------------------
        private void pbBorga_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.userName = userName;
            menuForm.sessionId = sessionId;
            menuForm.Show();
        }

        // Move Button Click --------------------------------------------------------------------------------------------------------------
        private void btnMove_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MainForm]", "[btnMove_Click]", "Move Button Clicked", lblLogBook);
            Movements movements = new Movements();
            movements.sessionId = sessionId;
            movements.passedPart = globalPart;
            movements.passedClient = globalClient;
            movements.Show();
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts--------------------------------------------------------------------------------------------------------
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnClear_Click(sender, e);
            }

            // ctrl + R
            if (e.Control && e.KeyCode == Keys.R)
            {
                txbSearch.Focus();
                txbSearch.Text = globalPart;
                cbClient.SelectedItem = globalClient;
                txbSearch_Leave(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }
    }
}
