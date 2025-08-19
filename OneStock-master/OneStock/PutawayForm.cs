using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OneStock
{
    public partial class PutawayForm : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        // Declare Global Variables
        public string userName { get; set; }
        public string sessionId { get; set; }

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public int formMode = 1; // 1 = Input Mode, 0 = Edit Mode.

        public PutawayForm()
        {
            InitializeComponent();
            Text = $"Putaway - {Environment.UserName.ToUpper()}";
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
        }

        // Form Load -----------------------------------------------------------------------------------------------------------------------
        private void PutawayForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = userName; // Show Username
            SessionMaintenance.LogBook("", "[PutawayForm]", "[FormLoad]", "Form Started");
            PopulateComboBoxes(cbClient, "CLIENT");
            ClearFields();
            rbtnInput.Checked = true;
            msPutaway.BackColor = Color.White;
        }

        // Form Closing -----------------------------------------------------------------------------------------------------------------------
        private void PutawayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearSession();
            SessionMaintenance.LogBook("", "[PutawayForm]", "[FormClosed]", "Form Closed");
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Update Form Mode --------------------------------------------------------------------------------------------------------------------------------
        private void UpdateMode()
        {
            if (rbtnInput.Checked && !rbtnEdit.Checked)
            {
                SetInputMode();
                SessionMaintenance.LogBook("", "[PutawayForm]", "[UpdateMode]", "Mode Changed: Input");
            }
            else if (rbtnEdit.Checked && !rbtnInput.Checked)
            {
                SetEditMode();
                SessionMaintenance.LogBook("", "[PutawayForm]", "[UpdateMode]", "Mode Changed: Edit");
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("215", $"");
                SessionMaintenance.LogBook($"ERROR", "[PutawayForm]", "[UpdateMode]", $"An Error occured Updating Form Mode");
            }
        }

        // Set Edit Mode --------------------------------------------------------------------------------------------------------------------------------
        private void SetEditMode()
        {
            txbSku.Text = "";
            txbSku.Enabled = false;
            txbSku.BackColor = Color.DarkGray;

            cbClient.Enabled = false;
            cbClient.BackColor = Color.White;

            btnFun.Text = "Remove";

            formMode = 0; // Set Form to Edit mode

            btnPutaway.Visible = false;

            Text = $"Putaway - {Environment.UserName.ToUpper()} - Edit Mode";

            SessionMaintenance.LogBook("", "[PutawayForm]", "[SetEditMode]", "Edit Mode Set");

        }

        // Set Input Mode --------------------------------------------------------------------------------------------------------------------------------
        private void SetInputMode()
        {
            txbSku.Text = "";
            txbSku.Enabled = true;
            txbSku.BackColor = Color.White;

            cbClient.Enabled = true;
            cbClient.BackColor = Color.White;

            btnFun.Text = "Generate";

            formMode = 1; // Set Form to Input mode

            btnPutaway.Visible = true;

            Text = $"Putaway - {Environment.UserName.ToUpper()}";

            SessionMaintenance.LogBook("", "[PutawayForm]", "[SetInputMode]", "Input Mode Set");

        }

        // Check Part -----------------------------------------------------------------------------------------------------------------------
        private int CheckPart(string client, string part)
        {           
            string query = "EXECUTE [OneStock_Check_Part] @Client, @Search";
            int count = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Search", part);

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
                messageBox.ShowDefError("116", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[PutawayForm]", "[CheckPart]", $"FAILED ( {ex.Message} )");
            }

            return count;
        }

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
                messageBox.ShowDefError("112", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[PutawayForm]", "[PopulateComboBoxes]", $"FAILED ( {ex.Message} )");
                SessionMaintenance.LogBook("ERROR", "[PutawayForm]", "[PopulateComboBoxes]", "Application Closed");
                Application.Exit();
            }
        }

        // Populate DataGrid -----------------------------------------------------------------------------------------------------------------------
        private void PopulateDatagrid()
        {
            string query = "SELECT " +
                "[Part]" +
                ",[Description]" +
                ",RTRIM([store]) + ' - ' + RTRIM([Bin]) as [Location]" +
                ",'1' as [QTY]" +
                " FROM " +
                " OSPA_TEMP " +
                " WHERE " +
                " Reference = @Reference" +
                " ORDER BY DT_Created DESC";
            string reference = lblPutaway.Text;
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
                    dgPutaway.DataSource = dataTable;
                    dgPutaway.Refresh();
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();                
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[PutawayForm]", "[PopulateDatagrid]", $"FAILED Code: 117 (  {ex.Message}  )");
            }
        }

        // Get Header -----------------------------------------------------------------------------------------------------------------------
        private void GetHeaders(Label label, int mode)
        {
            string query = "";
            string output = "";
            string parameter = "";

            switch (mode)
            {
                case 0: query = "SELECT TOP 1 Reference as [1] FROM OSPA WHERE Session_Id = @Parameter ORDER BY DT_Created DESC"; parameter = sessionId; break;
                case 1: query = "SELECT [Status] as [1] FROM OSPA WHERE Reference = @Parameter"; parameter = lblPutaway.Text; break;
                case 2: query = "SELECT [Lines] as [1] FROM OSPA WHERE Reference = @Parameter"; parameter = lblPutaway.Text; break;
                case 3: query = "SELECT [Units] as [1] FROM OSPA WHERE Reference = @Parameter"; parameter = lblPutaway.Text; break;
                case 4: query = "SELECT [Walks] as [1] FROM OSPA WHERE Reference = @Parameter"; parameter = lblPutaway.Text; break;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Parameter", parameter);

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
                messageBox.ShowDefError("230", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[PutawayForm]", "[GetHeaders]", $"FAILED Code: 230 ( {ex.Message} )");
            }
        }

        // Clear Fields -----------------------------------------------------------------------------------------------------------------------
        private void ClearFields()
        {
            cbClient.SelectedItem = null;
            txbSku.Text = "";
            lblPutaway.Text = "";
            lblStatus.Text = "";
            lblLines.Text = "";
            lblUnits.Text = "";
            lblWalks.Text = "";

            btnFun.Visible = false;

            dgPutaway.DataSource = null;
            dgPutaway.Refresh();
        }

        // Insert Putaway -----------------------------------------------------------------------------------------------------------------------
        private void InsertPutaway(string sku, string client, string reference)
        {
            string query = "EXECUTE [OSPA_Insert] @Session_ID, @Client, @Reference, @Search";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Reference", reference);
                        cmd.Parameters.AddWithValue("@Search", sku);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();

                    SessionMaintenance.LogBook($"", "[PutawayForm]", "[InsertPutaway]", $"Record Inserted: {reference}, {sku}");
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();                
                messageBox.ShowDefError("120", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[PutawayForm]", "[InsertPutaway]", $"FAILED Code: 120 (  {ex.Message}  )");
            }
        }

        // Generate Report -----------------------------------------------------------------------------------------------------------------------
        private void GenerateReport(string reference)
        {
            // Construct the URL with the reference parameter
            string url = $"http://sql-ssrs/ReportServer/Pages/ReportViewer.aspx?%2fApplication+Reporting%2fOneStock%2fOSPA_Putaway_V1&rs:Command=Render&Reference={Uri.EscapeDataString(reference)}";

            // Open URL
            try
            {
                // Open the URL in the default web browser
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };

                Process.Start(processStartInfo);

                SessionMaintenance.LogBook($"", "[PutawayForm]", "[GenerateReport]", $"Process Executed with parameter: {reference}");
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("121", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[PutawayForm]", "[GenerateReport]", $"FAILED Code: 121 (  {ex.Message}  )");
            }
        }

        // Delete Line -----------------------------------------------------------------------------------------------------------------------
        private void DeleteLine(string reference, string part)
        {
            string query = "EXECUTE [OSPA_DELETE] @Reference, @Part";

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
                        cmd.Parameters.AddWithValue("@Part", part);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("211", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[PutawayForm]", "[DeleteLine]", $"FAILED Code: 211 (  {ex.Message}  )");
            }
        }

        // Delete Function -----------------------------------------------------------------------------------------------------------------------
        private void DeleteFunction()
        {
            if (dgPutaway.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgPutaway.SelectedRows[0];

                string reference = lblPutaway.Text;
                string part = selectedRow.Cells[0].Value.ToString();

                DeleteLine(reference, part);

                SessionMaintenance.LogBook($"", "[PutawayForm]", "[DeleteFunction]", $"Record removed from OSPA_TEMP: {reference}, {part}");
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("205", $"");
                SessionMaintenance.LogBook("", "[PutawayForm]", "[DeleteFunction]", "Error Triggered: 205", lblStatus);
                return;
            }
        }

        // Clear Session -----------------------------------------------------------------------------------------------------------------------
        private void ClearSession()
        {
            string query = "EXECUTE [OSPA_Clear_Session] @Session_Id";

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

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                    SessionMaintenance.LogBook("", "[PutawayForm]", "[ClearSession]", "Session Cleared");

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("211", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[PutawayForm]", "[ClearSession]", $"FAILED (  {ex.Message}  )");
            }
        }

        // Update Status Label ---------------------------------------------------------------------------------------------------
        private void UpdateStatus(int mode, string status)
        {
            bool enableControls = (mode == 1) && (status == "Open" || status == "Printed" || string.IsNullOrEmpty(status));

            txbSku.Text = "";
            txbSku.Enabled = enableControls;
            txbSku.BackColor = enableControls ? Color.Black : Color.DarkGray;

            cbClient.Enabled = enableControls;
            cbClient.BackColor = enableControls ? Color.Black : Color.DarkGray;

            btnPutaway.Visible = enableControls;
        }


        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Radio Buttons Checked --------------------------------------------------------------------------------------------------------------------------------
        private void rbtnInput_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMode();
        }

        private void rbtnEdit_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMode();
        }

        // Mouse Enter/Leave --------------------------------------------------------------------------------------------------------------
        private void MouseEnter(Button button)
        {
            button.ForeColor = Color.Black;
            button.BackColor = Color.White;
        }

        private void MouseLeave(Button button)
        {
            button.ForeColor = Color.White;
            button.BackColor = Color.Black;
        }

        // Focus Enter/Leave --------------------------------------------------------------------------------------------------------------
        private void FocusEnter(Control control)
        {
            control.ForeColor = Color.White;
            control.BackColor = Color.Black;
        }

        private void FocusLeave(Control control)
        {
            control.ForeColor = Color.Black;
            control.BackColor = Color.White;
        }

        // Putaway Reference Change ----------------------------------------------------------------------------------------------------------
        private void lblPutaway_TextChanged(object sender, EventArgs e)
        {
            string reference = lblPutaway.Text;
            if (!string.IsNullOrEmpty(reference))
            {
                btnFun.Visible = true;
                rbtnEdit.Visible = true;
                rbtnInput.Visible = true;
            }
            else
            {
                btnFun.Visible = false;
                rbtnEdit.Visible = false;
                rbtnInput.Visible = false;
            }
        }

        // Status Change ----------------------------------------------------------------------------------------------------------
        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            string statusCode = lblStatus.Text;

            // Use a dictionary for status mappings
            var statusMap = new Dictionary<string, string>
            {
                { "30", "Open" },
                { "40", "Printed" },
                { "200", "Cancelled" },
                { "220", "Complete" }
            };

            // Update label text if a mapped status exists
            if (statusMap.TryGetValue(statusCode, out string statusText))
            {
                lblStatus.Text = statusText;
            }

            // Update UI elements based on status
            UpdateStatus(formMode, lblStatus.Text);
        }

        // Units Change ----------------------------------------------------------------------------------------------------------
        private void lblUnits_TextChanged(object sender, EventArgs e)
        {
            bool hasUnits = lblUnits.Text != "0";

            if (formMode == 1)
            {
                btnFun.Visible = hasUnits;
                btnPutaway.Visible = true;
            }
            else
            {
                btnFun.Visible = hasUnits;
                btnPutaway.Visible = false;
            }
        }

        // Button Focus -----------------------------------------------------------------------------------------------------------------------
        private void btnPutaway_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnPutaway);
        }

        private void btnPutaway_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnPutaway);
        }

        private void btnFun_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnFun);
        }

        private void btnFun_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnFun);
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnClear);
        }

        private void btClose_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnClose);
        }

        private void btClose_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnClose);
        }

        // Field Focus -----------------------------------------------------------------------------------------------------------------------
        private void cbClient_Enter(object sender, EventArgs e)
        {
            FocusEnter(cbClient);

            string reference = lblPutaway.Text;

            if (!string.IsNullOrEmpty(reference))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowQuestion("Warning!", "Changing the client will clear any unsaved data! are you sure?");
                if (result == true)
                {
                    ClearFields();
                    cbClient.Focus();
                    cbClient.BackColor = Color.Black;
                    cbClient.ForeColor = Color.White;
                }
                else
                {
                    txbSku.Focus();
                    return;
                }
            }
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            FocusLeave(cbClient);
        }

        private void txbSku_Enter(object sender, EventArgs e)
        {
            FocusEnter(txbSku);
        }

        private void txbSku_Leave(object sender, EventArgs e)
        {
            FocusLeave(txbSku);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Input Button --------------------------------------------------------------------------------------------------------------------------------
        private void rbtnInput_Click(object sender, EventArgs e)
        {
            rbtnInput.Checked = true;
            rbtnEdit.Checked = false;
        }

        // Edit Button --------------------------------------------------------------------------------------------------------------------------------
        private void rbtnEdit_Click(object sender, EventArgs e)
        {
            rbtnInput.Checked = false;
            rbtnEdit.Checked = true;
        }

        // Putaway Button -----------------------------------------------------------------------------------------------------------------------
        private void btnPutaway_Click(object sender, EventArgs e)
        {
            string sku = txbSku.Text;
            string client = "";
            string reference = lblPutaway.Text;
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(client))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError($"130", "");
                return;
            }
            else if (string.IsNullOrEmpty(sku))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError($"188", "");
                return;
            }
            else
            {
                if(CheckPart(client, sku) == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError($"190", $"{sku}");                    
                    return;
                }
                else
                {
                    InsertPutaway(sku, client, reference);
                    GetHeaders(lblPutaway, 0);
                    GetHeaders(lblStatus, 1);
                    GetHeaders(lblLines, 2);
                    GetHeaders(lblUnits, 3);
                    GetHeaders(lblWalks, 4);
                    PopulateDatagrid();

                    txbSku.Text = "";
                    txbSku.Focus();
                }
            }
        }

        // Close Button -----------------------------------------------------------------------------------------------------------------------
        private void btClose_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();
            bool result = messageBox.ShowQuestion("Warning!", "Quitting this screen will cancel all your session's open or unprinted putaways, are you sure?");
            if (result == true)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        // Clear Button -----------------------------------------------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Function Button -----------------------------------------------------------------------------------------------------------------------
        private void btnFun_Click(object sender, EventArgs e)
        {
            if (formMode == 1)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowQuestion("Warning!", "You will not be able to edit the putaway once the report has been generated, are you sure?");
                if (result == true)
                {
                    string reference = lblPutaway.Text;
                    GenerateReport(reference);

                    lblStatus.Text = "Printed";

                    txbSku.Text = "";
                    txbSku.Enabled = false;
                    txbSku.BackColor = Color.DarkGray;

                    cbClient.Enabled = false;
                    cbClient.BackColor = Color.White;

                    btnPutaway.Visible = false;
                    btnFun.Visible = false;

                    rbtnEdit.Visible = false;
                    rbtnInput.Visible = false;
                }
                else
                {
                    return;
                }
            }
            else if (formMode == 0)
            {
                DeleteFunction();

                GetHeaders(lblPutaway, 0);
                GetHeaders(lblStatus, 1);
                GetHeaders(lblLines, 2);
                GetHeaders(lblUnits, 3);
                GetHeaders(lblWalks, 4);
                PopulateDatagrid();
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("203", $"");
                SessionMaintenance.LogBook("", "[PutawayForm]", "[btnFun_Click]", "Error Triggered: 203");
            }
        }

        // Menu Strip //
        // Edit Button -----------------------------------------------------------------------------------------------------------------------
        private void editModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnFun.Visible)
            {
                if (formMode == 1)
                {
                    rbtnEdit.Focus();
                    rbtnEdit_Click(sender, e);

                }
                else if (formMode == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("202", $"");
                    SessionMaintenance.LogBook("", "[PutawayForm]", "[editModeToolStripMenuItem_Click]", "Error Triggered: 202");
                }
                else
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("203", $"");
                    SessionMaintenance.LogBook("", "[PutawayForm]", "[editModeToolStripMenuItem_Click]", "Error Triggered: 203");
                }
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("203", $"");
                return;
            }
        }

        // Clear Button -----------------------------------------------------------------------------------------------------------------------
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
        }

        // Close Menustrip Button -----------------------------------------------------------------------------------------------------------------------
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btClose_Click(sender, e);
        }

        // Reprint Menustrip Button -----------------------------------------------------------------------------------------------------------------------
        private void reprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReprintForm reprintForm = new ReprintForm();
            reprintForm.sessionId = sessionId;
            reprintForm.userName = userName;
            reprintForm.Show();
        }

        // Complete Menustrip Button -----------------------------------------------------------------------------------------------------------------------
        private void completeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteForm completeForm = new CompleteForm();
            completeForm.sessionId = sessionId;
            completeForm.userName = userName;
            completeForm.Show();
        }

        // Overrides Menustrip Button -----------------------------------------------------------------------------------------------------------------------
        private void overridesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverridesForm overridesForm = new OverridesForm();
            overridesForm.sessionId = sessionId;
            overridesForm.userName = userName;
            overridesForm.Show();   
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Tab Key - License plate field --------------------------------------------------------------------------------------------------------------------------------
        private void txbSku_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (formMode == 1)
            {
                // Check if Tab is pressed without Shift to trigger the insert function
                if (e.KeyCode == Keys.Tab && !ModifierKeys.HasFlag(Keys.Shift))
                {
                    btnPutaway_Click(sender, e);  // Call the Insert function
                    e.IsInputKey = true;      // Indicate this is an input key to avoid default tab behavior
                }
            }
        }

        // Override Key Commands ----------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (txbSku != null && !txbSku.IsDisposed)
            {
                // Check if Tab is pressed
                if (keyData == Keys.Tab && !ModifierKeys.HasFlag(Keys.Shift))
                {
                    return true; // Prevent default Tab navigation
                }
                // Handle Shift + Tab to allow backward navigation focus to txbConsign from txbPlate
                else if (keyData == (Keys.Tab | Keys.Shift) && txbSku.Focused)
                {
                    txbSku.Focus();
                    return true; // Prevent default Shift + Tab navigation
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Keyboard Shortcuts --------------------------------------------------------------------------------------------------------------------------------
        private void PutawayForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + O
            if (e.Control && e.KeyCode == Keys.O)
            {
                OverridesForm overridesForm = new OverridesForm();
                overridesForm.sessionId = sessionId;
                overridesForm.userName = userName;
                overridesForm.Show();
            }

            // ctrl + R
            if (e.Control && e.KeyCode == Keys.R)
            {
                ReprintForm reprintForm = new ReprintForm();
                reprintForm.sessionId = sessionId;
                reprintForm.userName = userName;
                reprintForm.Show();
            }

            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (formMode == 1)
                {
                    ClearFields();
                }
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btClose_Click(sender, e);
            }

            // ctrl + E
            if (e.Control && e.KeyCode == Keys.E)
            {
                if (btnFun.Visible)
                {
                    editModeToolStripMenuItem_Click(sender, e);
                }
            }

            // ctrl + K
            if (e.Control && e.KeyCode == Keys.K)
            {
                if (formMode == 0 && btnFun.Visible)
                { 
                    btnFun_Click(sender, e); 
                }
            }

            // ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (formMode == 1 && btnFun.Visible)
                {
                    btnFun_Click(sender, e);
                }
            }

            // ctrl + A
            if (e.Control && e.KeyCode == Keys.A)
            {
                completeToolStripMenuItem_Click(sender, e);
            }
        }
    }
}
