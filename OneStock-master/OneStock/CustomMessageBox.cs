using System.Data.SqlClient;

namespace OneStock
{
    public partial class CustomMessageBox : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        private string GetError(string code)
        {
            string query = "SELECT RTRIM(Error) as [Error] FROM Appz_Errors WHERE code = @Code";
            string error = "Unknown Error!";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", code);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                error = reader["Error"].ToString(); // Populate variable
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured with the custom message box.\nApplication will now close.");
                Application.Exit();
            }
            return error;
        }

        // Show Default Error
        public void ShowDefError(string code, string additional)
        {
            ClientSize = new Size(380, 276);
            string error = GetError(code);

            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Error!";
            Text = "Error!";
            lblDescription.Text = $"Error {code}: \n{error} {additional}";
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show Default Warning
        public void ShowDefWarning(string code, string additional)
        {
            ClientSize = new Size(380, 276);
            string error = GetError(code);

            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Warning!";
            Text = "Warning!";
            lblDescription.Text = $"Warning {code}: \n{error} {additional}";
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show An Error
        public void ShowError(string error)
        {
            ClientSize = new Size(380, 276);
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Error!";
            Text = "Error!";
            lblDescription.Text = error;
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show LogBook
        public void ShowLogBook(string message)
        {
            ClientSize = new Size(380, 276);
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "LogBook";
            Text = "LogBook";
            lblDescription.Text = $"Last LogBook Activity Recorded: \n{message}";
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show A Warning
        public void ShowWarning(string Warning)
        {
            ClientSize = new Size(380, 276);
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Warning!";
            Text = "Warning!";
            lblDescription.Text = Warning;
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show A Warning
        public void ShowMisc(string Message, string summary, int x, int y)
        {
            ClientSize = new Size(x, y);
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = summary;
            Text = summary;
            lblDescription.Text = Message;
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show Exit
        public bool ShowExitDialog()
        {
            ClientSize = new Size(380, 200);
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Exit?";
            Text = "Exit?";
            lblDescription.Text = "Are you sure you want to Exit the application?";
            btnNo.Visible = true;
            btnYesOk.Text = "Yes";
            btnYesOk.Click += btnYesOk_Click;
            btnNo.Click += btnNo_Click;
            this.ShowDialog();

            return DialogResult == DialogResult.Yes;
        }

        // Show Misc Question
        public bool ShowQuestion(string summary, string message)
        {
            ClientSize = new Size(380, 276);
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = summary;
            Text = summary;
            lblDescription.Text = message;
            btnNo.Visible = true;
            btnYesOk.Text = "Yes";
            btnYesOk.Click += btnYesOk_Click;
            btnNo.Click += btnNo_Click;
            this.ShowDialog();

            return DialogResult == DialogResult.Yes;
        }

        // Show Message
        public void ShowMessage(string message, string summary)
        {
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = $"{summary}";
            Text = $"{summary}";
            lblDescription.Text = $"{message}";
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
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

        // Yes/Ok Button --------------------------------------------------------------------------------------------------------------
        private void btnYesOk_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnYesOk);
        }

        private void btnYesOk_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnYesOk);
        }

        // No Button --------------------------------------------------------------------------------------------------------------
        private void btnNo_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnNo);
        }

        private void btnNo_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnNo);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // No Button Click Event
        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        // Yes/Ok Button Click Event
        private void btnYesOk_Click(object sender, EventArgs e)
        {
            if (btnYesOk.Text == "Ok")
            {
                this.Close();
            }
            else if (btnYesOk.Text == "Yes")
            {
                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
