namespace OneStock
{
    partial class CompleteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompleteForm));
            btnExit = new Button();
            txbRef = new TextBox();
            dgPutaway = new DataGridView();
            btnConfirm = new Button();
            cntHeaders = new Panel();
            lblClient = new Label();
            lblClient__ = new Label();
            label5 = new Label();
            label7 = new Label();
            lblWalks = new Label();
            lblUnits = new Label();
            label8 = new Label();
            lblLines = new Label();
            label9 = new Label();
            lblStatus = new Label();
            label2 = new Label();
            lblPutaway = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            lblUsername = new Label();
            btnClear = new Button();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgPutaway).BeginInit();
            cntHeaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(12, 440);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(165, 36);
            btnExit.TabIndex = 2;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // txbRef
            // 
            txbRef.CharacterCasing = CharacterCasing.Upper;
            txbRef.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txbRef.Location = new Point(12, 127);
            txbRef.MaxLength = 50;
            txbRef.Name = "txbRef";
            txbRef.Size = new Size(513, 24);
            txbRef.TabIndex = 0;
            txbRef.Enter += txbRef_Enter;
            txbRef.Leave += txbRef_Leave;
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
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgPutaway.DefaultCellStyle = dataGridViewCellStyle2;
            dgPutaway.GridColor = Color.White;
            dgPutaway.Location = new Point(12, 226);
            dgPutaway.Name = "dgPutaway";
            dgPutaway.ReadOnly = true;
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
            dgPutaway.Size = new Size(513, 208);
            dgPutaway.TabIndex = 9;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Black;
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(360, 440);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(165, 36);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm Putaway";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfrim_Click;
            btnConfirm.MouseEnter += btnConfrim_MouseEnter;
            btnConfirm.MouseLeave += btnConfrim_MouseLeave;
            // 
            // cntHeaders
            // 
            cntHeaders.BackColor = Color.Black;
            cntHeaders.Controls.Add(lblClient);
            cntHeaders.Controls.Add(lblClient__);
            cntHeaders.Controls.Add(label5);
            cntHeaders.Controls.Add(label7);
            cntHeaders.Controls.Add(lblWalks);
            cntHeaders.Controls.Add(lblUnits);
            cntHeaders.Controls.Add(label8);
            cntHeaders.Controls.Add(lblLines);
            cntHeaders.Controls.Add(label9);
            cntHeaders.Controls.Add(lblStatus);
            cntHeaders.Controls.Add(label2);
            cntHeaders.Controls.Add(lblPutaway);
            cntHeaders.Location = new Point(12, 154);
            cntHeaders.Name = "cntHeaders";
            cntHeaders.Size = new Size(513, 66);
            cntHeaders.TabIndex = 16;
            cntHeaders.Visible = false;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.BackColor = Color.White;
            lblClient.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblClient.ForeColor = Color.Black;
            lblClient.Location = new Point(339, 34);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(71, 16);
            lblClient.TabIndex = 18;
            lblClient.Text = "XXXXXXXX";
            // 
            // lblClient__
            // 
            lblClient__.AutoSize = true;
            lblClient__.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblClient__.ForeColor = Color.White;
            lblClient__.Location = new Point(281, 34);
            lblClient__.Name = "lblClient__";
            lblClient__.Size = new Size(54, 16);
            lblClient__.TabIndex = 17;
            lblClient__.Text = "Client: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(281, 16);
            label5.Name = "label5";
            label5.Size = new Size(52, 16);
            label5.TabIndex = 16;
            label5.Text = "Walks:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(151, 34);
            label7.Name = "label7";
            label7.Size = new Size(47, 16);
            label7.TabIndex = 16;
            label7.Text = "Units:";
            // 
            // lblWalks
            // 
            lblWalks.BackColor = Color.White;
            lblWalks.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblWalks.ForeColor = Color.Black;
            lblWalks.Location = new Point(339, 16);
            lblWalks.Name = "lblWalks";
            lblWalks.Size = new Size(71, 16);
            lblWalks.TabIndex = 16;
            lblWalks.Text = "XXXXXXXX";
            // 
            // lblUnits
            // 
            lblUnits.BackColor = Color.White;
            lblUnits.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblUnits.ForeColor = Color.Black;
            lblUnits.Location = new Point(204, 34);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(71, 16);
            lblUnits.TabIndex = 16;
            lblUnits.Text = "XXXXXXXX";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(151, 16);
            label8.Name = "label8";
            label8.Size = new Size(47, 16);
            label8.TabIndex = 16;
            label8.Text = "Lines:";
            // 
            // lblLines
            // 
            lblLines.BackColor = Color.White;
            lblLines.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblLines.ForeColor = Color.Black;
            lblLines.Location = new Point(204, 16);
            lblLines.Name = "lblLines";
            lblLines.Size = new Size(71, 16);
            lblLines.TabIndex = 16;
            lblLines.Text = "XXXXXXXX";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(0, 34);
            label9.Name = "label9";
            label9.Size = new Size(58, 16);
            label9.TabIndex = 16;
            label9.Text = "Status: ";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.White;
            lblStatus.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(74, 34);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(71, 16);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "XXXXXXXX";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 16);
            label2.Name = "label2";
            label2.Size = new Size(68, 16);
            label2.TabIndex = 16;
            label2.Text = "Putaway:";
            // 
            // lblPutaway
            // 
            lblPutaway.BackColor = Color.White;
            lblPutaway.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPutaway.ForeColor = Color.Black;
            lblPutaway.Location = new Point(74, 16);
            lblPutaway.Name = "lblPutaway";
            lblPutaway.Size = new Size(71, 16);
            lblPutaway.TabIndex = 16;
            lblPutaway.Text = "XXXXXXXX";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, -23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 110);
            label6.Name = "label6";
            label6.Size = new Size(120, 14);
            label6.TabIndex = 18;
            label6.Text = "Putaway Reference";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(77, 14);
            lblUsername.TabIndex = 19;
            lblUsername.Text = "USERNAME";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(183, 440);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(171, 36);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_Enter;
            btnClear.MouseLeave += btnClear_Leave;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 128, 0);
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(311, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 18);
            label1.TabIndex = 20;
            label1.Text = "CAUTION!";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(311, 27);
            label3.Name = "label3";
            label3.Size = new Size(214, 86);
            label3.TabIndex = 21;
            label3.Text = "Only use this screen to confirm a Putaway once you have physically returned the stock. This screen will update live stock levels and these actions cannot be undone!";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CompleteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(537, 493);
            ControlBox = false;
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lblUsername);
            Controls.Add(label6);
            Controls.Add(txbRef);
            Controls.Add(cntHeaders);
            Controls.Add(btnConfirm);
            Controls.Add(dgPutaway);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Controls.Add(pictureBox1);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CompleteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CompleteForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgPutaway).EndInit();
            cntHeaders.ResumeLayout(false);
            cntHeaders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private TextBox txbRef;
        private DataGridView dgPutaway;
        private Button btnConfirm;
        private Panel cntHeaders;
        private Label lblClient__;
        private Label label5;
        private Label label7;
        private Label lblWalks;
        private Label lblUnits;
        private Label label8;
        private Label lblLines;
        private Label label9;
        private Label lblStatus;
        private Label label2;
        private Label lblPutaway;
        private PictureBox pictureBox1;
        private Label label6;
        private Label lblUsername;
        private Label lblClient;
        private Button btnClear;
        private Label label1;
        private Label label3;
    }
}