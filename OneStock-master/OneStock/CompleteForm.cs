using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;

namespace OneStock
{
    public partial class CompleteForm : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        public string sessionId { get; set; }
        public string userName { get; set; }
        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public string reference = null;

        public CompleteForm()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true; // Enable Keyboard shortcuts
            KeyDown += KeyboardShortcuts; // Subscribe to Keydown Events            
        }

        // Form Load ------------------------------------------------------------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[CompleteForm]", "[FormLoad]", $"Form Started");
            Text = $"{Environment.UserName.ToUpper()} - {SessionMaintenance.appName} - Complete Putaway";
            lblUsername.Text = userName; // If applicable
            ClearFields();
        }

        // Exit Application Method -----------------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[CompleteForm]", "[FormClosing]", "Form Closed");
        }

        //=============================================================================================================================================================================================
        //-- Operational Methods --//
        //=============================================================================================================================================================================================

        // Check OSPA Status ------------------------------------------------------------------------------------------------------------------
        private int CheckStatus(string opsaRef)
        {
            string query = "SELECT Status FROM OSPA WHERE Reference = @Reference";
            int status = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    {
                        cmd.Parameters.AddWithValue("@Reference", opsaRef);
                        SqlDataReader reader = cmd.ExecuteReader();
                        {
                            if (reader.Read())
                            {
                                status = Convert.ToInt32(reader["Status"]);
                            }
                        }
                    }
                    conn.Close();

                    SessionMaintenance.LogBook("", "[CompleteForm]", "[CheckStatus]", $"Status retrieved for {opsaRef}");
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("109", $"\n{ex.Message}"); // An error occurred checking Reference: 
                SessionMaintenance.LogBook($"ERROR", "[CompleteForm]", "[CheckStatus]", $"FAILED (  {ex.Message}  )");
            }

            return status;
        }

        // Get Lines ------------------------------------------------------------------------------------------------------------------
        private List<string> GetLines(string opsaRef)
        {
            List<string> lines = new List<string>();
            string query = $"SELECT Part FROM OSPA_line WHERE Reference = @Reference";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    {
                        cmd.Parameters.AddWithValue("@Reference", opsaRef);
                        SqlDataReader reader = cmd.ExecuteReader();
                        {
                            while (reader.Read())
                            {
                                lines.Add(reader["Part"].ToString());
                            }
                        }
                    }
                    conn.Close();

                    SessionMaintenance.LogBook("", "[CompleteForm]", "[GetLines]", $"List of parts retrieved for {opsaRef}");
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("234", $"\n{ex.Message}"); // An error occurred getting line data:
                SessionMaintenance.LogBook($"ERROR", "[CompleteForm]", "[GetLines]", $"FAILED (  {ex.Message}  )");
            }

            return lines;
        }

        // Populate DataGrid -----------------------------------------------------------------------------------------------------------------------
        private void PopulateDatagrid()
        {
            string query = "SELECT " +
                "[Part]" +
                ",[Description]" +
                ",RTRIM([store]) + ' - ' + RTRIM([Bin]) as [Location]" +
                ",[QTY]" +
                " FROM " +
                " OSPA_Line " +
                " WHERE " +
                " Reference = @Reference" +
                " ORDER BY DT_Created DESC";

            DataTable dataTable = new DataTable();

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Reference", reference);


                        // Execute Query
                        cmd.ExecuteNonQuery();

                        // Execute Data Reader
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Populate DataTable From Reader
                        dataTable.Load(reader);
                    }

                    conn.Close(); // Close SQL Connection

                    // Populate Data Grid
                    dgPutaway.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgPutaway.DataSource = dataTable;
                    dgPutaway.Refresh();
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}"); // An error occurred getting query results: 
                SessionMaintenance.LogBook($"ERROR", "[CompleteForm]", "[PopulateDatagrid]", $"FAILED (  {ex.Message}  )");
            }
        }

        // Get Header -----------------------------------------------------------------------------------------------------------------------
        private void GetHeaders(Label label, int mode)
        {
            string query = "";
            string output = "";

            switch (mode)
            {
                case 0: query = "SELECT [Client] as [1] FROM OSPA WHERE Reference = @Parameter"; break;
                case 1: query = "SELECT [Status] as [1] FROM OSPA WHERE Reference = @Parameter"; break;
                case 2: query = "SELECT [Lines] as [1] FROM OSPA WHERE Reference = @Parameter"; break;
                case 3: query = "SELECT [Units] as [1] FROM OSPA WHERE Reference = @Parameter"; break;
                case 4: query = "SELECT [Walks] as [1] FROM OSPA WHERE Reference = @Parameter"; break;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Parameter", reference);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                output = reader["1"].ToString();
                            }
                        }
                    }

                    conn.Close();
                }

                label.Text = output;

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("230", $"\n{ex.Message}"); // An error occurred getting Putaway headers
                SessionMaintenance.LogBook("ERROR", "[CompleteForm]", "[GetHeaders]", $"FAILED Code: 230 ( {ex.Message} )");
            }
        }

        // Load Data -----------------------------------------------------------------------------------------------------------------------
        private void LoadData()
        {
            reference = txbRef.Text;

            if (!string.IsNullOrEmpty(reference))
            {
                // Check OSPA Status
                int status = CheckStatus(reference);
                if (status == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("235", ""); //No Putaway found for this reference
                    return;
                }
                else if (status == 220)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("236", ""); // Putaway already completed
                    return;
                }
                else if (status == 200)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("237", ""); // Putaway has been cancelled
                    return;
                }
                else if (status == 40)
                {
                    lblPutaway.Text = reference;

                    // Get Headers
                    GetHeaders(lblClient, 0);
                    GetHeaders(lblStatus, 1);
                    GetHeaders(lblLines, 2);
                    GetHeaders(lblUnits, 3);
                    GetHeaders(lblWalks, 4);

                    cntHeaders.Visible = true;
                    btnClear.Visible = true;
                    btnConfirm.Visible = true;

                    // Populate DataGrid
                    PopulateDatagrid();

                    SessionMaintenance.LogBook("", "[CompleteForm]", "[LoadData]", $"Data Loaded for {reference}");
                }
                else
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("238", ""); // Unknown status
                    return;
                }

            }
            else
            {
                cntHeaders.Visible = false;
                btnClear.Visible = false;
                btnConfirm.Visible = false;
                dgPutaway.DataSource = null;
                dgPutaway.Refresh();
            }
        }

        // Move Stock ------------------------------------------------------------------------------------------------------------------
        private void MoveStock(string ospaRef, List<string> parts)
        {
            string query = "EXECUTE [OSPA_Move_Stock] @Session_Id, @User, @Reference, @Part";
            int? error = 0;
            string? output = "";

            DataTable result = new DataTable();
            DataColumn col1 = new DataColumn("Output", typeof(string));
            DataColumn col2 = new DataColumn("Error", typeof(int));
            result.Columns.Add(col1);
            result.Columns.Add(col2);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (string part in parts)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                            cmd.Parameters.AddWithValue("@User", userName);
                            cmd.Parameters.AddWithValue("@Part", part);
                            cmd.Parameters.AddWithValue("@Reference", ospaRef);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    output = reader["Output"].ToString();
                                    error = Convert.ToInt32(reader["Error"]);
                                }
                            }

                            // Add to DataTable
                            DataRow row = result.NewRow();
                            row["Output"] = output;
                            row["Error"] = error;
                            result.Rows.Add(row);

                            SessionMaintenance.LogBook("", "[CompleteForm]", "[MoveStock]", $"Stock movements attempted for {ospaRef}, {part} with results: \n {error} - {output}");
                        }

                        dgPutaway.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Auto size columns
                        dgPutaway.DataSource = result;
                        dgPutaway.Sort(dgPutaway.Columns["Error"], ListSortDirection.Descending);
                        dgPutaway.Refresh();

                        FormatDataGrid();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("239", $"\n{ex.Message}"); // An error occurred while updating stock
                SessionMaintenance.LogBook($"ERROR", "[CompleteForm]", "[MoveStock]", $"FAILED ({ex.Message})");
            }
        }

        // Complete Putaway ------------------------------------------------------------------------------------------------------------------
        private void CompletePutaway(string ospaRef)
        {
            string query = "EXECUTE OSPA_comp_putaway @Reference";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Reference", ospaRef);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("242", $"\n{ex.Message}"); // An error occurred completing putaway
                SessionMaintenance.LogBook($"ERROR", "[CompleteForm]", "[CompletePutaway]", $"FAILED ({ex.Message})");
            }
        }

        // Clear Fields ------------------------------------------------------------------------------------------------------------------
        private void ClearFields()
        {
            txbRef.Text = "";
            lblClient.Text = "";
            lblStatus.Text = "";
            lblLines.Text = "";
            lblUnits.Text = "";
            lblWalks.Text = "";

            cntHeaders.Visible = false;
            btnClear.Visible = false;
            btnConfirm.Visible = false;
            dgPutaway.DataSource = null;
            dgPutaway.Refresh();

            txbRef.Focus();
        }

        // Format Datagrid ------------------------------------------------------------------------------------------------------------------
        private void FormatDataGrid()
        {
            foreach (DataGridViewRow row in dgPutaway.Rows)
            {
                if (row.Cells.Count > 0)
                {
                    int errorColumnIndex = 1; // Last column index

                    if (int.TryParse(row.Cells[errorColumnIndex].Value?.ToString(), out int errorFlag) && errorFlag == 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        //=============================================================================================================================================================================================
        //-- Environment Events --//
        //=============================================================================================================================================================================================      

        // Reference TextBox ------------------------------------------------------------------------------------------------------------------
        private void txbRef_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.FocusEnter(txbRef);
        }

        private void txbRef_Leave(object sender, EventArgs e)
        {
            LoadData();
            SessionMaintenance.FocusLeave(txbRef);
        }

        // Confirm Button ------------------------------------------------------------------------------------------------------------------
        private void btnConfrim_MouseEnter(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.Red;
            btnConfirm.ForeColor = Color.Black;
        }

        private void btnConfrim_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnConfirm);
        }
        // Exit Button ------------------------------------------------------------------------------------------------------------------
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnExit);
        }

        private void btnClear_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnClear);
        }

        private void btnClear_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnClear);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Confirm Button ------------------------------------------------------------------------------------------------------------------
        private void btnConfrim_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();

            if (string.IsNullOrEmpty(reference))
            {
                messageBox.ShowDefError("240", ""); // Please enter a reference number
                return;
            }
            else
            {
                bool result = messageBox.ShowQuestion("Warning!", $"Are you sure you want to confirm putaway {reference}? \nThis action will create stock movements on Elucid and effect live stock levels!\n This cannot be undone!");
                if (result == true)
                {
                    MoveStock(reference, GetLines(reference));
                    CompletePutaway(reference);
                }
                else
                {
                    return;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Exit Button ------------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        // Keybord Shortcuts ------------------------------------------------------------------------------------------------------------------
        private void KeyboardShortcuts(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                ClearFields();
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }
    }
}
