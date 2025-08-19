using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;

namespace OneStock
{
    public partial class Movements : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        public string sessionId = SessionMaintenance.sessionId;
        public string userName = SessionMaintenance.userName;

        public string passedClient { get; set; } // Passed Client from MainForm
        public string passedPart { get; set; } // Passed Part from MainForm

        // Set SQL Connection String
        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance
        public Movements()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true; // Enable Keyboard shortcuts
            KeyDown += KeyboardShortcuts; // Subscribe to Keydown Events
        }

        private void Movements_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[Movements]", "[FormLoad]", $"Form Started");
            Text = $"{Environment.UserName.ToUpper()} - {SessionMaintenance.appName} Movements";
            PopulateComboBoxes(cbClient, "CLIENT");

            if (!string.IsNullOrEmpty(passedClient) && !string.IsNullOrEmpty(passedPart))
            {
                cbClient.SelectedItem = passedClient; // Set Client ComboBox to passed value
                txbSearch.Text = passedPart; // Set Part TextBox to passed value
                PopulateDatagrid(passedClient, passedPart); // Populate DataGrid with passed values
            }
            else
            {
                dgStock.DataSource = null; // Clear DataGrid if no passed values
            }
        }

        // Exit Application Method -----------------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[Movements]", "[FormClosing]", "Form Closed");
        }

        //=============================================================================================================================================================================================
        //-- Operational Methods --//
        //=============================================================================================================================================================================================

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
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[PopulateComboBoxes]", $"FAILED ( {ex.Message} )");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[PopulateComboBoxes]", "Application Closed");
                Application.Exit();
            }
        }

        // Populate DataGrid -----------------------------------------------------------------------------------------------------------------------
        private void PopulateDatagrid(string client, string part)
        {
            string query = "EXECUTE [OneStock_Get_Smov] @Session_Id, @Client, @Part";

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
                    dgStock.DataSource = dataTable;
                    dgStock.Refresh();
                    SessionMaintenance.LogBook("", "[Movements]", "[PopulateDatagrid]", $"DataGrid populated with {dataTable.Rows.Count} rows for Client: {client} and Part: {part}");
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}"); // An error occurred getting query results: 
                SessionMaintenance.LogBook($"ERROR", "[Movements]", "[PopulateDatagrid]", $"FAILED (  {ex.Message}  )");
            }
        }

        //=============================================================================================================================================================================================
        //-- Environment Events --//
        //=============================================================================================================================================================================================      

        // Client field events ------------------------------------------------------------------------------------------------------------------
        private void cbClient_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.FocusEnter(cbClient);
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.FocusLeave(cbClient);
        }

        // Search Field ------------------------------------------------------------------------------------------------------------------
        private void txbSearch_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.FocusEnter(txbSearch);
        }

        private void txbSearch_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.FocusLeave(txbSearch);
        }

        // Clear Button ------------------------------------------------------------------------------------------------------------------
        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnClear);
        }

        // Search Button ------------------------------------------------------------------------------------------------------------------
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnSearch);
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnSearch);
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

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Exit Button ------------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Search Button ------------------------------------------------------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[Movements]", "[btnSearch_Click]", "Searching for part");
            string part = txbSearch.Text; // Get Part TextBox value
            string client = null;

            // Check Client Field
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(part))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Please enter a part to search for.");
            }
            else if (string.IsNullOrEmpty(client))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Please select a client to search for.");
            }
            else
            {
                PopulateDatagrid(client, part); // Populate DataGrid with results
                dgStock.Focus(); // Set focus on DataGrid
            }
        }

        // Clear Button ------------------------------------------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[Movements]", "[btnClear_Click]", "Clearing fields");
            dgStock.DataSource = null; // Clear DataGrid
            dgStock.Refresh(); // Refresh DataGrid
            cbClient.Text = string.Empty; // Clear Client TextBox
            txbSearch.Text = string.Empty; // Clear Part TextBox
            cbClient.Focus(); // Set focus on Client ComboBox
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
                btnClear_Click(sender, e);
            }
            // ctrl + R
            if (e.Control && e.KeyCode == Keys.R)
            {
                btnSearch_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }
    }
}
