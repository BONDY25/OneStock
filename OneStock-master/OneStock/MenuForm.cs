using System.Data.SqlClient;

namespace OneStock
{
    public partial class MenuForm : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        // Declare Global Variables
        public string userName { get; set; }
        public string sessionId { get; set; }

        // Set SQL Connection String
        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public MenuForm()
        {
            InitializeComponent();
            Text = $"Modules - {Environment.UserName.ToUpper()}";
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
            KeyDown += MenuForm_KeyDown;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MenuForm]", "[FormLoad]", "Form Loaded");
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//


        // Check OSPA Rights --------------------------------------------------------------------------------------------------------------
        private bool CheckOSPA(string username)
        {
            string query = "SELECT COUNT(*) as [1] FROM [OSPA_Users] WHERE [User] = @User AND [Active] = '1'";
            bool check = false;
            int count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                count = (int)reader["1"];
                            }
                        }
                    }

                    conn.Close();
                }

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[CheckOSPA]", $"FAILED ( {ex.Message} )");
            }

            switch (count)
            {
                case > 0: check = true; break;
                default: check = false; break;
            }

            return check;
        }

        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Putaway Button --------------------------------------------------------------------------------------------------------------
        private void btnPutaway_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnPutaway);
        }
        private void btnPutaway_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnPutaway);
        }

        // Barcode Checker Button --------------------------------------------------------------------------------------------------------------
        private void btnBcodeCheck_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnBcodeCheck);
        }

        private void btnBcodeCheck_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnBcodeCheck);
        }

        // Close Button --------------------------------------------------------------------------------------------------------------
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnClose);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnClose);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Putaway Button Click --------------------------------------------------------------------------------------------------------------
        private void btnPutaway_Click(object sender, EventArgs e)
        {
            if (CheckOSPA(userName))
            {
                PutawayForm putawayForm = new PutawayForm();
                putawayForm.sessionId = sessionId;
                putawayForm.userName = userName;
                putawayForm.Show();
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"You do not have access to this form!");
                SessionMaintenance.LogBook("", "[MenuForm]", "[btnPutaway_Click]", "Access Denied!");
                return;
            }
        }

        // Barcode Checker Button Click --------------------------------------------------------------------------------------------------------------
        private void btnBcodeCheck_Click(object sender, EventArgs e)
        {
            BcodeCheck bcodeCheck = new BcodeCheck();
            bcodeCheck.sessionId = sessionId;
            bcodeCheck.userName = userName;
            bcodeCheck.Show();
        }

        // Close Button --------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MenuForm]", "[FormClose]", "Form Closed");
            this.Close();
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnPutaway.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnBcodeCheck.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose.PerformClick();
            }
        }
    }
}
