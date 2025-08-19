namespace OneStock
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            btnPutaway = new Button();
            btnBcodeCheck = new Button();
            btnClose = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnPutaway
            // 
            btnPutaway.BackColor = Color.Black;
            btnPutaway.Cursor = Cursors.Hand;
            btnPutaway.FlatStyle = FlatStyle.Flat;
            btnPutaway.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPutaway.ForeColor = Color.White;
            btnPutaway.Location = new Point(12, 41);
            btnPutaway.Name = "btnPutaway";
            btnPutaway.Size = new Size(241, 40);
            btnPutaway.TabIndex = 12;
            btnPutaway.Text = "Putaway";
            btnPutaway.UseVisualStyleBackColor = false;
            btnPutaway.Click += btnPutaway_Click;
            btnPutaway.MouseEnter += btnPutaway_MouseEnter;
            btnPutaway.MouseLeave += btnPutaway_MouseLeave;
            // 
            // btnBcodeCheck
            // 
            btnBcodeCheck.BackColor = Color.Black;
            btnBcodeCheck.Cursor = Cursors.Hand;
            btnBcodeCheck.FlatStyle = FlatStyle.Flat;
            btnBcodeCheck.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnBcodeCheck.ForeColor = Color.White;
            btnBcodeCheck.Location = new Point(12, 87);
            btnBcodeCheck.Name = "btnBcodeCheck";
            btnBcodeCheck.Size = new Size(241, 40);
            btnBcodeCheck.TabIndex = 13;
            btnBcodeCheck.Text = "Barcode Checker";
            btnBcodeCheck.UseVisualStyleBackColor = false;
            btnBcodeCheck.Click += btnBcodeCheck_Click;
            btnBcodeCheck.MouseEnter += btnBcodeCheck_MouseEnter;
            btnBcodeCheck.MouseLeave += btnBcodeCheck_MouseLeave;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 133);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(241, 40);
            btnClose.TabIndex = 14;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // label5
            // 
            label5.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(241, 29);
            label5.TabIndex = 15;
            label5.Text = "Modules";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(269, 182);
            ControlBox = false;
            Controls.Add(label5);
            Controls.Add(btnClose);
            Controls.Add(btnBcodeCheck);
            Controls.Add(btnPutaway);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            Load += MenuForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnPutaway;
        private Button btnBcodeCheck;
        private Button btnClose;
        private Label label5;
    }
}