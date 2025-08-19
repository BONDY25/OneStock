using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OneStock
{
    public partial class OverridesForm : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        // Declare Global Variables
        public string userName { get; set; }
        public string sessionId { get; set; }

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance
        public OverridesForm()
        {
            InitializeComponent();
            Text = $"Overrides - {Environment.UserName.ToUpper()}";
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
        }

        // Form Load -----------------------------------------------------------------------------------------------------------------------
        private void OverridesForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[OverridesForm]", "[FormLoad]", "Form Started");
            PopulateComboBoxes(cbClient, "CLIENT");
        }

        // Form Closing -----------------------------------------------------------------------------------------------------------------------
        private void OverridesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[OverridesForm]", "[FormClosed]", "Form Closed");
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
                query = "SELECT [Description] FROM OneStock_Clients WHERE [Active] = '1' ORDER BY [ID]";
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

                    conn.Close();
                }
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("112", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[OverridesForm]", "[PopulateComboBoxes]", $"FAILED ( {ex.Message} )");
                SessionMaintenance.LogBook("ERROR", "[OverridesForm]", "[PopulateComboBoxes]", "Application Closed");
                Application.Exit();
            }
        }

        // Get Client -----------------------------------------------------------------------------------------------------------------------
        private void GetClient()
        {
            string client = "";
            string query = "SELECT [Override] FROM [OneStock_Clients] WHERE [Description] = @Client";
            int over = 0;

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

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                over = (int)reader["Override"];
                            }
                        }
                    }

                    conn.Close();
                }

                switch (over)
                {
                    case 0: cbxOverride.Checked = false; break;
                    case 1: cbxOverride.Checked = true; break;
                }

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("231", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[OverridesForm]", "[GetClient]", $"FAILED Code: 231 ( {ex.Message} )");
            }

            PopulateDatagrid(client);
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
                SessionMaintenance.LogBook("ERROR", "[PutawayForm]", "[CheckPart]", $"FAILED Code: 116 ( {ex.Message} )");
            }

            return count;
        }

        // Populate DataGrid -----------------------------------------------------------------------------------------------------------------------
        private void PopulateDatagrid(string client)
        {
            string query = "SELECT[Part],[Store],[bin],[DT_Created]FROM[OSPA_Over]WHERE[Client]=@Client ORDER BY[DT_Created] DESC";

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
                        cmd.Parameters.AddWithValue("@Client", client);

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

                    SessionMaintenance.LogBook("", "[OverridesForm]", "[PopulateDatagrid]", "Data Grid Populated");
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[OverridesForm]", "[PopulateDatagrid]", $"FAILED Code: 117 (  {ex.Message}  )");
            }
        }

        // Update Override -----------------------------------------------------------------------------------------------------------------------
        private void UpdateOverride(string client)
        {
            string query = "EXECUTE [OSPA_Over_Update] @Client, @Over, @User";
            bool overBool = cbxOverride.Checked;
            int overInt = 0;

            switch (overBool)
            {
                case true: overInt = 1; break;
                case false: overInt = 0; break;
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
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Over", overInt);
                        cmd.Parameters.AddWithValue("@User", userName);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                    SessionMaintenance.LogBook("", "[OverridesForm]", "[UpdateOverride]", $"Override flag updated for: {client}");

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("229", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[OverridesForm]", "[UpdateOverride]", $"FAILED Code: 229 (  {ex.Message}  )");
            }

        }

        // Insert Override -----------------------------------------------------------------------------------------------------------------------
        private void InsertOverride(string client, string part, string store, string bin)
        {
            string query = "EXECUTE [OSPA_Over_Insert] @Client, @Part, @Store, @Bin";

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Part", part);
                        cmd.Parameters.AddWithValue("@Store", store);
                        cmd.Parameters.AddWithValue("@Bin", bin);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                    SessionMaintenance.LogBook("", "[OverridesForm]", "[InsertOverride]", $"Override location added for: {client},{part},{store},{bin}");

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("120", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[OverridesForm]", "[InsertOverride]", $"FAILED (  {ex.Message}  )");
            }
        }
        
        // Remove Override Function -----------------------------------------------------------------------------------------------------------------------
        private async void RemoveFuncion(string client)
        {
            if (dgPutaway.SelectedRows.Count > 0)
            {
                List<string> partsToRemove = new List<string>();

                // Collect all selected parts
                foreach (DataGridViewRow selectedRow in dgPutaway.SelectedRows)
                {
                    if (selectedRow.Cells[0].Value != null)
                    {
                        string part = selectedRow.Cells[0].Value.ToString();
                        partsToRemove.Add(part);
                    }
                }

                if (partsToRemove.Count > 0)
                {
                    int maxRows = partsToRemove.Count;
                    int currentRows = 0;

                    // Show Progress Bar
                    pBarImport.Invoke((MethodInvoker)(() =>
                    {
                        pBarImport.Visible = true;
                        pBarImport.Maximum = maxRows;
                        pBarImport.Value = 0;
                        btnDelete.Enabled = false;
                        btnAdd.Enabled = false;
                        btnImport.Enabled = false;
                        btnClose.Enabled = false;
                    }));

                    foreach (string part in partsToRemove)
                    {
                        RemoveOverride(client, part);
                        currentRows++;

                        // Update Progress Bar
                        pBarImport.Invoke((MethodInvoker)(() =>
                        {
                            pBarImport.Value = currentRows;
                        }));

                        // Update Label
                        lblProgress.Invoke((MethodInvoker)(() =>
                        {
                            lblProgress.Visible = true;
                            lblProgress.Text = $"Removing: {currentRows}/{maxRows} Rows";
                        }));

                        // Small delay to allow UI to refresh
                        await Task.Delay(1);

                        // Log removal
                        SessionMaintenance.LogBook("", "[OverridesForm]", "[RemoveFuncion]", $"Override location Removed: {part}");
                    }

                    // Refresh UI
                    PopulateDatagrid(client);

                    // Hide Progress Bar
                    pBarImport.Invoke((MethodInvoker)(() => pBarImport.Visible = false));
                    lblProgress.Invoke((MethodInvoker)(() => lblProgress.Visible = false));
                    btnDelete.Enabled = true;
                    btnAdd.Enabled = true;
                    btnImport.Enabled = true;
                    btnClose.Enabled = true;
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowMisc($"Successfully removed {partsToRemove.Count} overrides.", "Overrides Removed", 380, 276);
                }
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("205", $"");
                SessionMaintenance.LogBook("", "[OverridesForm]", "[RemoveFuncion]", "Error Triggered: 205 - No rows selected.");
            }
        }

        // Remove Override -----------------------------------------------------------------------------------------------------------------------
        private void RemoveOverride(string client, string part)
        {
            string query = "EXECUTE [OSPA_Over_Delete] @Client, @Part";

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Part", part);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                    SessionMaintenance.LogBook("", "[OverridesForm]", "[RemoveOverride]", $"Override location removed for: {client},{part}");

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("211", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[OverridesForm]", "[RemoveOverride]", $"FAILED Code: 211 (  {ex.Message}  )");
            }
        }

        // Show Remove Button -----------------------------------------------------------------------------------------------------------------------
        private void ShowRemoveButton()
        {
            string query = "SELECT COUNT(*) as [1] FROM OSPA_Over WHERE Client = @Client";
            string client = "";
            int show = 0;

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

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                show = (int)reader["1"];
                            }
                        }
                    }

                    conn.Close();
                }

                switch (show)
                {
                    case 0: btnDelete.Visible = false; break;
                    case >= 1: btnDelete.Visible = true; break;
                }
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("227", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[OverridesForm]", "[ShowRemoveButton]", $"FAILED Code: 227 ( {ex.Message} )");
            }
        }

        // Read CSV ----------------------------------------------------------------------------------------------------------------------------
        private DataTable ReadCsv(string filePath)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    bool isFirstLine = true;

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split(',');

                        if (isFirstLine)
                        {
                            // Add columns to DataTable based on the first line (header)
                            foreach (string header in values)
                            {
                                dataTable.Columns.Add(header);
                            }
                            isFirstLine = false;
                        }
                        else
                        {
                            // Add rows to DataTable
                            dataTable.Rows.Add(values);
                        }
                    }
                }
                SessionMaintenance.LogBook("", "[OverridesForm]", "[ReadCsv]", $"CSV File accepted");
                return dataTable;


            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Error Reading CSV: {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[OverridesForm]", "[ReadCsv]", $"FAILED (  {ex.Message}  )");
                return null;
            }
        }

        // Import Data ----------------------------------------------------------------------------------------------------------------------------
        private async void ImportOSPA(DataTable dataTable)
        {
            int maxRows = dataTable.Rows.Count;
            int currentRows = 0;
            string client = cbClient.SelectedItem?.ToString() ?? "";
            int batchSize = 1;

            Stopwatch stopwatch = Stopwatch.StartNew();
            SessionMaintenance.LogBook("", "[OverridesForm]", "[ImportOSPA]", $"Method Started");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    pBarImport.Visible = true;
                    lblProgress.Visible = true;
                    
                    btnDelete.Enabled = false;
                    btnAdd.Enabled = false;
                    btnImport.Enabled = false;
                    btnClose.Enabled = false;

                    lblProgress.Text = $"{currentRows}/{maxRows}";

                    pBarImport.Invoke((MethodInvoker)(() =>
                    {
                        pBarImport.Maximum = maxRows;
                        pBarImport.Value = 0;
                    }));

                    // ** Parallel Execution with Task List **
                    List<Task> insertTasks = new List<Task>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create task for each insert
                        insertTasks.Add(Task.Run(async () =>
                        {
                            string query = "EXECUTE [OSPA_Over_Insert] @Client, @Part, @Store, @Bin";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Client", row["client"]);
                                cmd.Parameters.AddWithValue("@Part", row["part"]);
                                cmd.Parameters.AddWithValue("@Store", row["store"]);
                                cmd.Parameters.AddWithValue("@Bin", row["bin"]);

                                await cmd.ExecuteNonQueryAsync();
                            }

                            // Increment row count in a thread-safe way
                            Interlocked.Increment(ref currentRows);
                                                        
                            SessionMaintenance.LogBook("", "[OverridesForm]", "[ImportOSPA]",$"Record Insert Attempt: [{row["client"]}], [{row["part"]}], [{row["store"]}], [{row["bin"]}]");

                            // UI Update - Only update every 'batchSize' rows
                            if (currentRows % batchSize == 0 || currentRows == maxRows)
                            {
                                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                                double rps = elapsedSeconds > 0 ? currentRows / elapsedSeconds : 0;

                                pBarImport.Invoke((MethodInvoker)(() =>
                                {
                                    pBarImport.Value = currentRows;
                                }));

                                lblProgress.Invoke((MethodInvoker)(() =>
                                {
                                    lblProgress.Text = $"Processed: {currentRows}/{maxRows} Rows ({rps:F2} Rows/s)";
                                }));
                            }
                        }));

                        // ** Wait for batch of tasks to finish before continuing (prevents overload) **
                        if (insertTasks.Count >= batchSize)
                        {
                            await Task.WhenAll(insertTasks);
                            insertTasks.Clear();
                        }
                    }

                    // ** Ensure all remaining tasks complete **
                    await Task.WhenAll(insertTasks);

                    stopwatch.Stop();
                    double finalRps = stopwatch.Elapsed.TotalSeconds > 0 ? maxRows / stopwatch.Elapsed.TotalSeconds : 0;

                    // Final UI update after completion
                    pBarImport.Invoke((MethodInvoker)(() => pBarImport.Value = maxRows));

                    lblProgress.Invoke((MethodInvoker)(() =>
                    {
                        lblProgress.Text = $"Completed: {maxRows}/{maxRows} Rows ({finalRps:F2} Rows/s)";
                    }));

                    PopulateDatagrid(client);
                    ShowRemoveButton();
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowMisc($"Data imported successfully.", "Data Imported", 380, 276);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Error Importing Data: {ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[OverridesForm]", "[ImportOSPA]", $"FAILED ({ex.Message})");
            }
            finally
            {
                pBarImport.Invoke((MethodInvoker)(() => pBarImport.Value = pBarImport.Maximum));
                pBarImport.Visible = false;
                lblProgress.Visible = false;
                btnDelete.Enabled = true;
                btnAdd.Enabled = true;
                btnImport.Enabled = true;
                btnClose.Enabled = true;
                SessionMaintenance.LogBook("", "[OverridesForm]", "[ImportOSPA]", $"Method Finished");
            }
        }

        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

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

        // Client Changed --------------------------------------------------------------------------------------------------------------
        private void cbClient_TextChanged(object sender, EventArgs e)
        {
            GetClient();
            ShowRemoveButton();

            txbSku.Text = "";
            txbStore.Text = "";
            txbBin.Text = "";

            txbSku.Focus();
        }

        // Close Button -----------------------------------------------------------------------------------------------------------------------
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnClose);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnClose);
        }

        // Delete Button -----------------------------------------------------------------------------------------------------------------------
        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnDelete);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnDelete);
        }

        // Add Button -----------------------------------------------------------------------------------------------------------------------
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnAdd);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnAdd);
        }

        // Import Button -----------------------------------------------------------------------------------------------------------------------
        private void btnImport_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnImport);
        }

        private void btnImport_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnImport);
        }

        // Client Field -----------------------------------------------------------------------------------------------------------------------
        private void cbClient_Enter(object sender, EventArgs e)
        {
            FocusEnter(cbClient);
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            FocusLeave(cbClient);
            //GetClient();
        }

        // Part Text Box -----------------------------------------------------------------------------------------------------------------------
        private void txbSku_Enter(object sender, EventArgs e)
        {
            FocusEnter(txbSku);
        }

        private void txbSku_Leave(object sender, EventArgs e)
        {
            FocusLeave(txbSku);
        }

        // Store Text Box -----------------------------------------------------------------------------------------------------------------------
        private void txbStore_Enter(object sender, EventArgs e)
        {
            FocusEnter(txbStore);
        }

        private void txbStore_Leave(object sender, EventArgs e)
        {
            FocusLeave(txbStore);
        }

        // Bin Text Box -----------------------------------------------------------------------------------------------------------------------
        private void txbBin_Enter(object sender, EventArgs e)
        {
            FocusEnter(txbBin);
        }

        private void txbBin_Leave(object sender, EventArgs e)
        {
            FocusLeave(txbBin);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Close Button -----------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Remove Button -----------------------------------------------------------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string client = "";

            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            RemoveFuncion(client);
            PopulateDatagrid(client);
        }

        // Add Button -----------------------------------------------------------------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string client = "";
            string part = txbSku.Text;
            string store = txbStore.Text;
            string bin = txbBin.Text;

            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(client))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("159", $"");
                return;
            }
            else if (string.IsNullOrEmpty(part))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("188", $"");
                return;
            }
            else if (string.IsNullOrEmpty(store))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("232", $"");
                return;
            }
            else if (string.IsNullOrEmpty(bin))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("233", $"");
                return;
            }
            else
            {
                if (CheckPart(client, part) == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("190", $"{part}");
                    return;
                }
                else
                {
                    InsertOverride(client, part, store, bin);

                    txbSku.Text = "";
                    txbStore.Text = "";
                    txbBin.Text = "";

                    txbSku.Focus();

                    PopulateDatagrid(client);
                    ShowRemoveButton();
                }
            }
        }

        // Override Flag -----------------------------------------------------------------------------------------------------------------------
        private void cbxOverride_Click(object sender, EventArgs e)
        {
            string client = "";

            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            UpdateOverride(client);
            ShowRemoveButton();
        }

        // Import Button -----------------------------------------------------------------------------------------------------------------------
        private async void btnImport_Click(object sender, EventArgs e)
        {
            string client = "";

            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            // Create an OpenFileDialog to choose the CSV file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            // Show the dialog and get the file path
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string csvFilePath = openFileDialog.FileName;
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Read the CSV data
                    DataTable dataTable = ReadCsv(csvFilePath);

                    // Insert data into the database
                    if (dataTable != null)
                    {
                        ImportOSPA(dataTable);
                    }
                }
                finally
                {
                    PopulateDatagrid(client);
                    Cursor = Cursors.Default;
                }
            }
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts --------------------------------------------------------------------------------------------------------------------------------
        private void OverridesForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }

            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbSku.Text = "";
                txbStore.Text = "";
                txbBin.Text = "";
                cbClient.SelectedItem = "";

                dgPutaway.DataSource = null;
                dgPutaway.Refresh();
            }
        }
    }
}
