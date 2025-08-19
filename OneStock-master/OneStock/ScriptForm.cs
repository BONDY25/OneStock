using System.Data.SqlClient;
using System.Reflection.Emit;

namespace OneStock
{
    public partial class ScriptForm : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        public string notes { get; set; }
        public string part { get; set; }
        public string barcode { get; set; }
        public string userName { get; set; }
        public string sessionId { get; set; }

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public ScriptForm()
        {
            InitializeComponent();
            Text = $"Scripts - {Environment.UserName.ToUpper()}";
        }

        // Form Load --------------------------------------------------------------------------------------------------------------
        private void ScriptForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[ScriptForm]", "[FormLoad]", $"Form Started ({part} - {barcode})");
            GetScripts();
        }

       

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Get Scripts --------------------------------------------------------------------------------------------------------------
        private void GetScripts()
        {
            string query = "SELECT TOP 1 * FROM OneStock_Scripts WHERE notes = @Notes AND Session_Id = @Session_Id AND part = @Part";
            string summary = null;
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Notes", notes);
                        cmd.Parameters.AddWithValue("@Part", part);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                summary = reader["Summary"].ToString();
                                if (!reader.IsDBNull(reader.GetOrdinal("Date_From")))
                                    dateFrom = reader.GetDateTime(reader.GetOrdinal("Date_From"));
                                if (!reader.IsDBNull(reader.GetOrdinal("Date_From")))
                                    dateTo = reader.GetDateTime(reader.GetOrdinal("Date_To"));
                            }
                        }
                    }

                    conn.Close();
                }

                lblSku.Text = $"{part} - {barcode}";
                lblSummary.Text = $"{summary}";
                lblNotes.Text = $"{notes}";
                lblDates.Text = $"{dateFrom.ToString("dd/MM/yyyy")} - {dateTo.ToString("dd/MM/yyyy")}";

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting part headers: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[ScriptForm]", "[GetScripts]", $"FAILED ( {ex.Message} )");
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

        // Close Button --------------------------------------------------------------------------------------------------------------
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

        // Close Button --------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[ScriptForm]", "[FormClose]", $"Form Closing");
            this.Close();
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts--------------------------------------------------------------------------------------------------------
        private void ScriptForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
