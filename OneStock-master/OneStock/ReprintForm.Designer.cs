namespace OneStock
{
    partial class ReprintForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReprintForm));
            dgPutaway = new DataGridView();
            btnClose = new Button();
            btnReprint = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgPutaway).BeginInit();
            SuspendLayout();
            // 
            // dgPutaway
            // 
            dgPutaway.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPutaway.BackgroundColor = Color.Black;
            dgPutaway.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgPutaway.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgPutaway.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgPutaway.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgPutaway.DefaultCellStyle = dataGridViewCellStyle2;
            dgPutaway.GridColor = Color.White;
            dgPutaway.Location = new Point(14, 66);
            dgPutaway.Name = "dgPutaway";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgPutaway.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgPutaway.RowHeadersVisible = false;
            dgPutaway.RowTemplate.Height = 25;
            dgPutaway.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPutaway.Size = new Size(659, 308);
            dgPutaway.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(14, 379);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 36);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // btnReprint
            // 
            btnReprint.BackColor = Color.Black;
            btnReprint.Cursor = Cursors.Hand;
            btnReprint.FlatStyle = FlatStyle.Flat;
            btnReprint.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnReprint.ForeColor = Color.White;
            btnReprint.Location = new Point(559, 380);
            btnReprint.Name = "btnReprint";
            btnReprint.Size = new Size(114, 36);
            btnReprint.TabIndex = 10;
            btnReprint.Text = "Reprint";
            btnReprint.UseVisualStyleBackColor = false;
            btnReprint.Click += btnReprint_Click;
            btnReprint.MouseEnter += btnReprint_MouseEnter;
            btnReprint.MouseLeave += btnReprint_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 26F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(155, 40);
            label1.TabIndex = 11;
            label1.Text = "Re-Print";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 49);
            label2.Name = "label2";
            label2.Size = new Size(162, 14);
            label2.TabIndex = 12;
            label2.Text = "Select a putaway to reprint";
            // 
            // ReprintForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(685, 427);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnReprint);
            Controls.Add(btnClose);
            Controls.Add(dgPutaway);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReprintForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReprintForm";
            FormClosing += ReprintForm_FormClosing;
            Load += ReprintForm_Load;
            KeyDown += ReprintForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgPutaway).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgPutaway;
        private Button btnClose;
        private Button btnReprint;
        private Label label1;
        private Label label2;
    }
}