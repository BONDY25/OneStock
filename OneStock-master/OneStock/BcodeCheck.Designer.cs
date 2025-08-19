namespace OneStock
{
    partial class BcodeCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BcodeCheck));
            label5 = new Label();
            lblOutput = new Label();
            rtbInput = new RichTextBox();
            btnClose = new Button();
            btnFun = new Button();
            cbClient = new ComboBox();
            label6 = new Label();
            lblInput = new Label();
            lblSku = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(487, 29);
            label5.TabIndex = 16;
            label5.Text = "Barcode Checker";
            // 
            // lblOutput
            // 
            lblOutput.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblOutput.Location = new Point(12, 177);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(487, 89);
            lblOutput.TabIndex = 17;
            lblOutput.Text = "Output";
            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtbInput
            // 
            rtbInput.Location = new Point(12, 100);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(487, 74);
            rtbInput.TabIndex = 1;
            rtbInput.Text = "";
            rtbInput.TextChanged += rtbInput_TextChanged;
            rtbInput.Enter += rtbInput_Enter;
            rtbInput.Leave += rtbInput_Leave;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 387);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // btnFun
            // 
            btnFun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFun.BackColor = Color.Black;
            btnFun.Cursor = Cursors.Hand;
            btnFun.FlatStyle = FlatStyle.Flat;
            btnFun.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnFun.ForeColor = Color.White;
            btnFun.Location = new Point(313, 387);
            btnFun.Name = "btnFun";
            btnFun.Size = new Size(186, 40);
            btnFun.TabIndex = 2;
            btnFun.Text = "Function";
            btnFun.UseVisualStyleBackColor = false;
            btnFun.Click += btnFun_Click;
            btnFun.MouseEnter += btnFun_MouseEnter;
            btnFun.MouseLeave += btnFun_MouseLeave;
            // 
            // cbClient
            // 
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.FormattingEnabled = true;
            cbClient.Location = new Point(12, 58);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(487, 22);
            cbClient.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 41);
            label6.Name = "label6";
            label6.Size = new Size(40, 14);
            label6.TabIndex = 22;
            label6.Text = "Client";
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Location = new Point(12, 83);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(37, 14);
            lblInput.TabIndex = 22;
            lblInput.Text = "Input";
            // 
            // lblSku
            // 
            lblSku.BackColor = Color.Black;
            lblSku.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSku.ForeColor = Color.White;
            lblSku.Location = new Point(12, 266);
            lblSku.Name = "lblSku";
            lblSku.Size = new Size(487, 118);
            lblSku.TabIndex = 17;
            // 
            // BcodeCheck
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(511, 439);
            ControlBox = false;
            Controls.Add(lblInput);
            Controls.Add(label6);
            Controls.Add(cbClient);
            Controls.Add(btnFun);
            Controls.Add(btnClose);
            Controls.Add(rtbInput);
            Controls.Add(lblSku);
            Controls.Add(lblOutput);
            Controls.Add(label5);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BcodeCheck";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BcodeCheck";
            Load += BcodeCheck_Load;
            KeyDown += BcodeCheck_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label lblOutput;
        private RichTextBox rtbInput;
        private Button btnClose;
        private Button btnFun;
        private ComboBox cbClient;
        private Label label6;
        private Label lblInput;
        private Label lblSku;
    }
}