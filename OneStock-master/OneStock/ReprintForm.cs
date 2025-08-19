using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OneStock
{
    public partial class ReprintForm : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        public string userName { get; set; }
        public string sessionId { get; set; }

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public ReprintForm()
        {
            InitializeComponent();
            Text = $"Re-Print - {Environment.UserName.ToUpper()}";
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
        }

        // Form Load --------------------------------------------------------------------------------------------------------------------------------
        private void ReprintForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[ReprintForm]", "[FormLoad]", "Form Started");
            PopulateDatagrid();
        }

        // Form Close --------------------------------------------------------------------------------------------------------------------------------
        private void ReprintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[ReprintForm]", "[FormClosing]", "Form Closed");
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Populate DataGrid -----------------------------------------------------------------------------------------------------------------------
        private void PopulateDatagrid()
        {
            string query = "SELECT " +
                "RTRIM([Reference]) as [Reference]" +
                ",RTRIM([Client]) as [Client]" +
                ",[Lines]" +
                ",[Units]" +
                ",[Walks]" +
                ",[Last_Updated] " +
                "FROM " +
                "OSPA " +
                "WHERE " +
                "[Status] = 40 " +
                "AND [Lines] > 0 " +
                "ORDER BY [Last_Updated] DESC ";

            DataTable dataTable = new DataTable();

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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

                    SessionMaintenance.LogBook("", "[ReprintForm]", "[PopulateDatagrid]", "Data Grid Populated");
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ReprintForm]", "[PopulateDatagrid]", $"FAILED Code: 117 (  {ex.Message}  )");
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

                SessionMaintenance.LogBook($"", "[ReprintForm]", "[GenerateReport]", $"Process Executed with parameter: {reference}");
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("121", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ReprintForm]", "[GenerateReport]", $"FAILED (  {ex.Message}  )");
            }
        }

        private void ReprintFunction()
        {
            if (dgPutaway.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgPutaway.SelectedRows[0];

                if (selectedRow.Cells[0].Value != null) // Check if Value is not null
                {
                    string reference = selectedRow.Cells[0].Value.ToString();

                    GenerateReport(reference);

                    SessionMaintenance.LogBook($"", "[ReprintForm]", "[ReprintFunction]", $"Putaway Re-Printed: {reference}");
                }
                else
                {
                    // Handle the case where the cell value is null
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("205", "");
                    SessionMaintenance.LogBook("", "[ReprintForm]", "[ReprintFunction]", "Error Triggered: 206");
                }
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("205", $"");
                SessionMaintenance.LogBook("", "[ReprintForm]", "[ReprintFunction]", "Error Triggered: 205");
                return;
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

        // Reprint Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnReprint_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnReprint);
        }

        private void btnReprint_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnReprint);
        }

        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnClose);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnClose);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Reprint Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnReprint_Click(object sender, EventArgs e)
        {
            ReprintFunction();
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts --------------------------------------------------------------------------------------------------------------------------------
        private void ReprintForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
