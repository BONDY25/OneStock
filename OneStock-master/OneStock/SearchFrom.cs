using Microsoft.Data.SqlClient;
using System.Data;

namespace OneStock
{
    public partial class SearchFrom : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        public string sessionId { get; set; }
        public string search { get; set; }
        public string client { get; set; }
        public string userName { get; set; }

        private MainForm mainForm;

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public SearchFrom(MainForm mainForm)
        {
            InitializeComponent();
            Text = $"Search - {Environment.UserName.ToUpper()}";
            this.KeyPreview = true;
            //this.FormClosing += MainForm_FormClosing;
            this.KeyDown += MainForm_KeyDown;
            this.mainForm = mainForm;
        }

        private void SearchFrom_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[SearchForm]", "[FormLoad]", $"Form Opened");
            txbTerm.Text = search;
            DoSearch();
            PopulateDataGrid();
        }

        // Exit Application Method --------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // LogBook("", "[SearchForm]", "[FormClosing]", $"Form Closed", sessionId);
                this.Close();
            }
        }        

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Do A Search -----------------------------------------------------------------------------------------------------------------------
        private void DoSearch()
        {
            string query = "EXECUTE [SearchApp_GetPart] @Client, @Session_Id, @Term";

            string term = txbTerm.Text;
            int mode = 0;

            SessionMaintenance.LogBook("", "[SearchForm]", "[DoSearch]", $"Method Started: {term}, {client}, {mode}");

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Execute SQL Command 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Term", term);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection
                }

                SessionMaintenance.LogBook("", "[SearchForm]", "[DoSearch]", $"Search Complete: {term}, {client}, {mode}");
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting Customer Details values: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[SearchForm]", "[DoSearch]", $"FAILED ( {ex.Message} )");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // Populate DataGrid -----------------------------------------------------------------------------------------------------------------------
        private void PopulateDataGrid()
        {
            string query = "SELECT [Part],[Description],[Sales_Group],[Product_Group],[Price],[Last_Order],[Free_Stock] " +
                    "FROM SearchApp_Part_Results " +
                    "WHERE Session_Id = @Session_Id " +
                    "ORDER BY Last_Order DESC";


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

                        // Execute Query
                        cmd.ExecuteNonQuery();

                        // Execute Data Reader
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Populate DataTable From Reader
                        dataTable.Load(reader);
                    }

                    conn.Close(); // Close SQL Connection

                    // Populate Data Grid
                    dgResults.DataSource = dataTable;
                    dgResults.Refresh();
                }

                SessionMaintenance.LogBook("", "[SearchForm]", "[PopulateDataGrid]", $"DataGrid Populated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting query results: {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[SearchForm]", "[PopulateDataGrid]", $"FAILED (  {ex.Message}  )");
            }
        }


        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Exit Button --------------------------------------------------------------------------------------------------------------
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
            btnExit.ForeColor = Color.Black;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Black;
            btnExit.ForeColor = Color.White;
        }

        // Search Button --------------------------------------------------------------------------------------------------------------
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.White;
            btnSearch.ForeColor = Color.Black;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.Black;
            btnSearch.ForeColor = Color.White;
        }

        // Term Field --------------------------------------------------------------------------------------------------------------
        private void txbTerm_Enter(object sender, EventArgs e)
        {
            txbTerm.BackColor = Color.Black;
            txbTerm.ForeColor = Color.White;
        }

        private void txbTerm_Leave(object sender, EventArgs e)
        {
            txbTerm.BackColor = Color.White;
            txbTerm.ForeColor = Color.Black;
        }

        private void txbTerm_TextChanged(object sender, EventArgs e)
        {

        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Exit Button --------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            //LogBook("", "[SearchForm]", "[FormClosing]", $"Form Closed", sessionId);
            this.Close();
        }

        // Search Button --------------------------------------------------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txbTerm.Text;
            DoSearch();
            PopulateDataGrid();
        }

        // Results Table Click --------------------------------------------------------------------------------------------------------------
        private void dgResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                // Check if mainForm and the first cell value are not null
                if (mainForm != null && dgResults.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    string part = dgResults.Rows[e.RowIndex].Cells[0].Value.ToString();
                    mainForm.txbSearch.Text = part;
                    mainForm.GetPart();
                    this.Close();
                }
                else if (dgResults.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    // Handle the case where mainForm or cell value is null
                    MessageBox.Show("part number cell is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (mainForm == null)
                {
                    MessageBox.Show("The main form is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts ------------------------------------------------------------------------------------------------------
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbTerm.Text = null;
                dgResults.DataSource = null;
                dgResults.Refresh();

                txbTerm.Focus();
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