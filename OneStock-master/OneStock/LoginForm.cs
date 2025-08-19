
using System.Data.SqlClient;

namespace OneStock
{
    public partial class LoginForm : Form
    {

        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//



        public string sessionId = SessionMaintenance.GetSessionID();

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public LoginForm()
        {
            SessionMaintenance.sessionId = sessionId;
            SessionMaintenance.userName = "UNDEFINED";
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            this.MaximizeBox = false;
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
            txbUsername.KeyPress += txbUsername_KeyPress;
            txbUsername.KeyDown += txbUsername_KeyDown;
            Text = $"Login - {Environment.UserName.ToUpper()}";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (SessionMaintenance.debugMode == 1)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowMessage($"This is not a live version of the application\nFeatures or function may still be in development which could cause bugs, crashes or unexpected behaviour", "Warning");
                lblVersion.Text = $"Build: DEBUG MODE";
                SessionMaintenance.LogBook("", "[LoginForm]", "[FormLoad]", $"Debug Mode Enabled - Initialization");
            }
            else
            {
                SessionMaintenance.LogBook("", "[LoginForm]", "[FormLoad]", $"Initialization");
                SessionMaintenance.CheckVersion();
                SessionMaintenance.CheckSessionID(sessionId);
                lblVersion.Text = $"Build: v{SessionMaintenance.currentVersion}";
            }
        }

        // Exit Application Method --------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowExitDialog();
                if (result == true)
                {
                    SessionMaintenance.LogBook("", "[LoginForm]", "[FormClosing]", $"Termination");

                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        // Application Closed -----------------------------------------------------------------------------------------------------------------------
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SessionMaintenance.ClearSessionID(sessionId);
        }

        // Check Username ------------------------------------------------------------------------------------------------------------------------
        private bool CheckUser()
        {
            string username = txbUsername.Text;
            string query = "SELECT COUNT(*) FROM APP_USERS WHERE Username = @Username";
            bool checkUser = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)cmd.ExecuteScalar();

                        if (count != 1)
                        {
                            checkUser = false;
                        }
                        else
                        {
                            checkUser = true;
                        }
                    }
                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred verifying Username: {ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[LoginForm]", "[CheckUser]", $"FAILED ( {ex.Message} )");
            }

            return checkUser;
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
        private void FocusEnter(TextBox textBox)
        {
            textBox.ForeColor = Color.White;
            textBox.BackColor = Color.Black;
        }

        private void FocusLeave(TextBox textBox)
        {
            textBox.ForeColor = Color.Black;
            textBox.BackColor = Color.White;
        }

        // Login Button --------------------------------------------------------------------------------------------------------------
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnLogin);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnLogin);
        }

        // Exit Button --------------------------------------------------------------------------------------------------------------
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnExit);
        }

        // Username Textbox --------------------------------------------------------------------------------------------------------------
        private void txbUsername_Enter(object sender, EventArgs e)
        {
            FocusEnter(txbUsername);
        }

        private void txbUsername_Leave(object sender, EventArgs e)
        {
            FocusLeave(txbUsername);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Exit Button --------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();
            bool result = messageBox.ShowExitDialog();
            if (result == true)
            {
                SessionMaintenance.LogBook("", "[LoginForm]", "[FormClosing]", $"Termination");
                SessionMaintenance.ClearSessionID(sessionId);
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        // Login Button --------------------------------------------------------------------------------------------------------------
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text.ToUpper();

            if (string.IsNullOrEmpty(userName))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Please enter a username.");
                return;
            }
            else
            {
                if (CheckUser())
                {
                    MainForm mainForm = new MainForm();
                    mainForm.userName = userName;
                    mainForm.sessionId = sessionId;
                    SessionMaintenance.userName = userName;
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"The Username entered is not a valid Elucid username, Please enter your Elucid Username");
                    return;
                }
            }
        }

        // Logo Click --------------------------------------------------------------------------------------------------------------
        private void pbLogo_Click(object sender, EventArgs e)
        {
            SessionMaintenance.ShowFact();
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//
        // ctrl + V Event (txbUsername) --------------------------------------------------------------------------------------------------------------
        private void txbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbUsername.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
        }

        // Keyboard Shortcuts --------------------------------------------------------------------------------------------------------------
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbUsername.Text = "";
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }


    }
}