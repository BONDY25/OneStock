namespace OneStock
{
    partial class CustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            btnNo = new Button();
            btnYesOk = new Button();
            lblSummary = new Label();
            lblDescription = new Label();
            SuspendLayout();
            // 
            // btnNo
            // 
            btnNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNo.BackColor = Color.Black;
            btnNo.Cursor = Cursors.Hand;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnNo.ForeColor = Color.White;
            btnNo.Location = new Point(12, 186);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(100, 39);
            btnNo.TabIndex = 1;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            btnNo.MouseEnter += btnNo_MouseEnter;
            btnNo.MouseLeave += btnNo_MouseLeave;
            // 
            // btnYesOk
            // 
            btnYesOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnYesOk.BackColor = Color.Black;
            btnYesOk.Cursor = Cursors.Hand;
            btnYesOk.FlatStyle = FlatStyle.Flat;
            btnYesOk.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnYesOk.ForeColor = Color.White;
            btnYesOk.Location = new Point(252, 186);
            btnYesOk.Name = "btnYesOk";
            btnYesOk.Size = new Size(100, 39);
            btnYesOk.TabIndex = 1;
            btnYesOk.Text = "Yes/Ok";
            btnYesOk.UseVisualStyleBackColor = false;
            btnYesOk.Click += btnYesOk_Click;
            btnYesOk.MouseEnter += btnYesOk_MouseEnter;
            btnYesOk.MouseLeave += btnYesOk_MouseLeave;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSummary.Font = new Font("Arial Rounded MT Bold", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummary.Location = new Point(5, 9);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(347, 39);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "Summary";
            lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.BackColor = Color.Black;
            lblDescription.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(12, 62);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(340, 121);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(364, 237);
            ControlBox = false;
            Controls.Add(btnYesOk);
            Controls.Add(btnNo);
            Controls.Add(lblDescription);
            Controls.Add(lblSummary);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CustomMessageBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomMessageBox";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Button btnNo;
        private Button btnYesOk;
        private Label lblSummary;
        private Label lblDescription;
    }
}