namespace OneStock
{
    partial class ScriptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptForm));
            lblSku = new Label();
            lblDates = new Label();
            label1 = new Label();
            btnClose = new Button();
            lblNotes = new Label();
            lblSummary = new Label();
            SuspendLayout();
            // 
            // lblSku
            // 
            lblSku.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSku.Location = new Point(14, 37);
            lblSku.Name = "lblSku";
            lblSku.Size = new Size(541, 21);
            lblSku.TabIndex = 0;
            lblSku.Text = "SKU - Barcode";
            // 
            // lblDates
            // 
            lblDates.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDates.Location = new Point(561, 37);
            lblDates.Name = "lblDates";
            lblDates.Size = new Size(263, 21);
            lblDates.TabIndex = 0;
            lblDates.Text = "XX/XX/XX - XX/XX/XX";
            lblDates.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 8);
            label1.Name = "label1";
            label1.Size = new Size(810, 21);
            label1.TabIndex = 0;
            label1.Text = "Part Scripts";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 247);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // lblNotes
            // 
            lblNotes.BackColor = Color.Black;
            lblNotes.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNotes.ForeColor = Color.White;
            lblNotes.Location = new Point(14, 104);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(810, 140);
            lblNotes.TabIndex = 0;
            lblNotes.Text = "Notes";
            // 
            // lblSummary
            // 
            lblSummary.BackColor = Color.Black;
            lblSummary.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummary.ForeColor = Color.White;
            lblSummary.Location = new Point(14, 71);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(810, 21);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "Summary";
            // 
            // ScriptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(838, 291);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(lblSummary);
            Controls.Add(lblNotes);
            Controls.Add(lblSku);
            Controls.Add(lblDates);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ScriptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScriptForm";
            TopMost = true;
            Load += ScriptForm_Load;
            KeyDown += ScriptForm_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Label lblSku;
        private Label lblSummary;
        private Label label3;
        private Label label4;
        private Label lblDates;
        private Label label1;
        private Button btnClose;
        private Label lblNotes;
    }
}