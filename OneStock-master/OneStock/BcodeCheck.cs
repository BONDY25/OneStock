using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OneStock
{
    public partial class BcodeCheck : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        // Declare Global Variables
        public string userName { get; set; }
        public string sessionId { get; set; }

        public int status = 1;
        public string bcode = "";

        // Set SQL Connection String
        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance
        public BcodeCheck()
        {
            InitializeComponent();
            Text = $"Barcode Checker - {Environment.UserName.ToUpper()}";
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
        }

        private void BcodeCheck_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[BcodeCheck]", "[FormLoad]", "Form Loaded");
            PopulateComboBoxes(cbClient, "CLIENT");
            ResetForm();
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Populate Combo Boxes -----------------------------------------------------------------------------------------------------------------------
        private void PopulateComboBoxes(System.Windows.Forms.ComboBox comboBox, string field)
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
                SessionMaintenance.LogBook("ERROR", "[BcodeCheck]", "[PopulateComboBoxes]", $"FAILED ( {ex.Message} )");
                SessionMaintenance.LogBook("ERROR", "[BcodeCheck]", "[PopulateComboBoxes]", "Application Closed");
                Application.Exit();
            }
        }

        // Check Barcode is valid --------------------------------------------------------------------------------------------------------------
        private bool CheckValidBarcode(string barcode)
        {
            bool check = false;
            SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckValidBarcode]", $"Checking if {barcode} is a valid barcode format");

            // Remove non-printable ASCII characters (anything outside 32-126 in ASCII table)
            barcode = Regex.Replace(barcode, @"[^\x20-\x7E]", "");

            // Define regex: only allows alphanumeric characters, max length 13
            Regex barcodeRegex = new Regex(@"^[A-Za-z0-9]{1,13}$");

            if (!barcodeRegex.IsMatch(barcode) || barcode.EndsWith("00130010"))
            {
                lblOutput.Text = "Barcode is not in a valid format, please re-barcode product!";
                lblOutput.BackColor = Color.Red;
                rtbInput.Text = "";
                btnFun.Text = "";
                btnFun.Visible = false;
                status = 1;
                rtbInput.Focus();
                SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckValidBarcode]", $"Barcode {barcode} is not a valid format");
                check = false;
            }
            else
            {
                check = true;
                SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckValidBarcode]", $"Barcode {barcode} is a valid format");
            }

            return check;
        }



        // Check Barcode Elucid --------------------------------------------------------------------------------------------------------------
        private void CheckBarcodeE9(string client, string barcode)
        {
            SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckBarcodeE9]", $"Checking if {barcode} is valid exists on elucid for client {client}");
            string query = "EXECUTE OSBC_Check_Bcode @Client, @Bcode";
            string sku = "";
            string descr = "";
            int count = 0;
            bool check = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Bcode", barcode);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                count = (int)reader["1"];
                                sku = reader["2"].ToString();
                                descr = reader["3"].ToString();
                                if (string.IsNullOrEmpty(sku))
                                {
                                    lblOutput.Text = "Barcode is not in the Elucid system, Please enter a SKU to assign barcode to!";
                                    rtbInput.Focus();
                                    lblOutput.BackColor = Color.Yellow;
                                    status = 2;
                                    rtbInput.Text = "";
                                    btnFun.Text = "Assign Product";
                                    btnClose.Text = "Clear";
                                    btnFun.Visible = true;
                                    lblInput.Text = $"Input: {barcode}";
                                    lblInput.BackColor = Color.Aqua;
                                    SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckBarcodeE9]", $"Barcode {barcode} does not exist on elucid for client {client}");
                                    return;
                                }
                                else
                                {
                                    lblOutput.Text = $"Barcode '{barcode}' is assign to product '{sku}'";
                                    lblOutput.BackColor = Color.Lime;
                                    rtbInput.Text = "";
                                    rtbInput.Enabled = false;
                                    btnFun.Text = "Okay";
                                    btnClose.Text = "Close";
                                    btnFun.Visible = true;
                                    lblSku.Text = $"SKU: {sku}\nDescription: {descr}";
                                    status = 3;
                                    SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckBarcodeE9]", $"Barcode {barcode} does exist on elucid for part {sku} for client {client}");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred checking barcode: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[BcodeCheck]", "[CheckBarcodeE9]", $"FAILED ( {ex.Message} )");
            }
        }

        // Assign Product --------------------------------------------------------------------------------------------------------------
        private void AssignProduct()
        {
            string? client = "";
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            string input = rtbInput.Text;
            string output = "";
            if (!string.IsNullOrEmpty(input))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowQuestion("Update?", $"Are you sure you want to add barcode '{bcode}' to part '{input}'?");
                if (result == true)
                {
                    try
                    {
                        string query = "EXECUTE OSBC_Assign_Bcode @Client, @Sku, @Bcode, @User";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Client", client);
                                cmd.Parameters.AddWithValue("@Sku", input);
                                cmd.Parameters.AddWithValue("@Bcode", bcode);
                                cmd.Parameters.AddWithValue("@User", userName);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        output = reader["OUTPUT"].ToString();
                                    }
                                }
                            }
                        }

                        if (output == "0")
                        {
                            lblOutput.Text = $"Failed to assign barcode '{bcode}' to part '{input}', part does not exists.";
                            lblOutput.BackColor = Color.Red;
                            rtbInput.Text = "";
                            rtbInput.Enabled = false;
                            btnFun.Text = "Okay";
                            btnClose.Text = "Close";
                            btnFun.Visible = true;
                            status = 3;
                            SessionMaintenance.LogBook("", "[BcodeCheck]", "[AssignProduct]", $"Failed to assign barcode {bcode} to part {input} for client {client}");
                        }
                        else if (output == "1")
                        {
                            lblOutput.Text = "Barcode has been assigned to SKU!";
                            lblOutput.BackColor = Color.Lime;
                            rtbInput.Text = "";
                            rtbInput.Enabled = false;
                            btnFun.Text = "Okay";
                            btnClose.Text = "Close";
                            btnFun.Visible = true;
                            status = 3;
                            SessionMaintenance.LogBook("", "[BcodeCheck]", "[AssignProduct]", $"barcode {bcode} assigned to part {input} for client {client}");
                        }
                    }
                    catch (Exception ex) // Catch any errors
                    {
                        messageBox.ShowError($"An error occurred saving barcode: \n{ex.Message}");
                        SessionMaintenance.LogBook("ERROR", "[BcodeCheck]", "[AssignProduct]", $"FAILED ( {ex.Message} )");
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Please enter a part to assign barcode '{bcode}' to!");
                return;
            }
        }

        // Reset Form --------------------------------------------------------------------------------------------------------------
        private void ResetForm()
        {
            rtbInput.Text = "";
            lblOutput.Text = "Enter a barcode to check";
            lblOutput.BackColor = Color.White;
            btnFun.Text = "";
            btnFun.Visible = false;
            btnClose.Text = "Close";
            status = 1;
            bcode = "";
            lblInput.Text = "Input";
            lblSku.Text = "";
            lblInput.BackColor = Color.White;
            rtbInput.Enabled = true;
            rtbInput.Focus();
        }

        // Check Barcode Full --------------------------------------------------------------------------------------------------------------
        private void CheckBarcode()
        {
            SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckBarcode]", $"Method Started");
            string? client = "";
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            bcode = rtbInput.Text;
            if (!string.IsNullOrEmpty(bcode))
            {
                if (CheckValidBarcode(bcode))
                {
                    CheckBarcodeE9(client, bcode);
                }
                SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckBarcode]", $"checked barcode");
            }

            SessionMaintenance.LogBook("", "[BcodeCheck]", "[CheckBarcode]", $"Method Finished");
        }

        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Input Field --------------------------------------------------------------------------------------------------------------
        private void rtbInput_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.FocusEnter(rtbInput);
        }

        private void rtbInput_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[BcodeCheck]", "[rtbInput_Leave]", $"Field Left");
            SessionMaintenance.FocusLeave(rtbInput);
            switch (status)
            {
                case 1: CheckBarcode(); break;
                default: break;
            }
        }

        private void rtbInput_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = rtbInput.SelectionStart; // Store cursor position
            rtbInput.Text = rtbInput.Text.ToUpper(); // Convert to uppercase
            rtbInput.SelectionStart = selectionStart; // Restore cursor position
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

        // Function Button --------------------------------------------------------------------------------------------------------------
        private void btnFun_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.MouseEnter(btnFun);
        }

        private void btnFun_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.MouseLeave(btnFun);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Function Button Click --------------------------------------------------------------------------------------------------------------
        private void btnFun_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case 2: AssignProduct(); break;
                case 3: ResetForm(); break;
                default: break;
            }
        }

        // Close Button Click --------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case 2: ResetForm(); break;
                default:
                    SessionMaintenance.LogBook("", "[BcodeCheck]", "[FormClose]", "Form Closed");
                    this.Close(); break;
            }
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        private void BcodeCheck_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }

            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                ResetForm();
            }
        }


    }
}
