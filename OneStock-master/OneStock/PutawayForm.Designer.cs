namespace OneStock
{
    partial class PutawayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PutawayForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblUsername = new Label();
            pictureBox1 = new PictureBox();
            cbClient = new ComboBox();
            label6 = new Label();
            btnClose = new Button();
            btnClear = new Button();
            btnFun = new Button();
            btnPutaway = new Button();
            txbSku = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label3 = new Label();
            label7 = new Label();
            lblWalks = new Label();
            lblUnits = new Label();
            label8 = new Label();
            lblLines = new Label();
            label9 = new Label();
            lblStatus = new Label();
            label2 = new Label();
            lblPutaway = new Label();
            dgPutaway = new DataGridView();
            rbtnInput = new RadioButton();
            rbtnEdit = new RadioButton();
            msPutaway = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            reprintToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            editModeToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            completeToolStripMenuItem = new ToolStripMenuItem();
            overridesToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPutaway).BeginInit();
            msPutaway.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(8, 35);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(77, 14);
            lblUsername.TabIndex = 10;
            lblUsername.Text = "USERNAME";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // cbClient
            // 
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.FormattingEnabled = true;
            cbClient.Location = new Point(8, 146);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(314, 22);
            cbClient.TabIndex = 0;
            cbClient.Enter += cbClient_Enter;
            cbClient.Leave += cbClient_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 129);
            label6.Name = "label6";
            label6.Size = new Size(40, 14);
            label6.TabIndex = 7;
            label6.Text = "Client";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(8, 395);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 39);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btClose_Click;
            btnClose.MouseEnter += btClose_MouseEnter;
            btnClose.MouseLeave += btClose_MouseLeave;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(114, 395);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 39);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // btnFun
            // 
            btnFun.BackColor = Color.Black;
            btnFun.Cursor = Cursors.Hand;
            btnFun.FlatStyle = FlatStyle.Flat;
            btnFun.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnFun.ForeColor = Color.White;
            btnFun.Location = new Point(553, 395);
            btnFun.Name = "btnFun";
            btnFun.Size = new Size(100, 39);
            btnFun.TabIndex = 5;
            btnFun.Text = "Function";
            btnFun.UseVisualStyleBackColor = false;
            btnFun.Click += btnFun_Click;
            btnFun.MouseEnter += btnFun_MouseEnter;
            btnFun.MouseLeave += btnFun_MouseLeave;
            // 
            // btnPutaway
            // 
            btnPutaway.BackColor = Color.Black;
            btnPutaway.Cursor = Cursors.Hand;
            btnPutaway.FlatStyle = FlatStyle.Flat;
            btnPutaway.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnPutaway.ForeColor = Color.White;
            btnPutaway.Location = new Point(328, 146);
            btnPutaway.Name = "btnPutaway";
            btnPutaway.Size = new Size(100, 65);
            btnPutaway.TabIndex = 2;
            btnPutaway.Text = "Putaway";
            btnPutaway.UseVisualStyleBackColor = false;
            btnPutaway.Click += btnPutaway_Click;
            btnPutaway.MouseEnter += btnPutaway_MouseEnter;
            btnPutaway.MouseLeave += btnPutaway_MouseLeave;
            // 
            // txbSku
            // 
            txbSku.CharacterCasing = CharacterCasing.Upper;
            txbSku.Location = new Point(8, 190);
            txbSku.MaxLength = 50;
            txbSku.Name = "txbSku";
            txbSku.Size = new Size(314, 21);
            txbSku.TabIndex = 1;
            txbSku.Enter += txbSku_Enter;
            txbSku.Leave += txbSku_Leave;
            txbSku.PreviewKeyDown += txbSku_PreviewKeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 173);
            label1.Name = "label1";
            label1.Size = new Size(86, 14);
            label1.TabIndex = 13;
            label1.Text = "SKU/Barcode";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lblWalks);
            panel1.Controls.Add(lblUnits);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblLines);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblPutaway);
            panel1.Location = new Point(434, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 173);
            panel1.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 88);
            label5.Name = "label5";
            label5.Size = new Size(60, 18);
            label5.TabIndex = 16;
            label5.Text = "Walks:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 91);
            label3.Name = "label3";
            label3.Size = new Size(60, 18);
            label3.TabIndex = 16;
            label3.Text = "Walks:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(0, 70);
            label7.Name = "label7";
            label7.Size = new Size(54, 18);
            label7.TabIndex = 16;
            label7.Text = "Units:";
            // 
            // lblWalks
            // 
            lblWalks.AutoSize = true;
            lblWalks.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblWalks.ForeColor = Color.White;
            lblWalks.Location = new Point(88, 88);
            lblWalks.Name = "lblWalks";
            lblWalks.Size = new Size(88, 18);
            lblWalks.TabIndex = 16;
            lblWalks.Text = "XXXXXXXX";
            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUnits.ForeColor = Color.White;
            lblUnits.Location = new Point(88, 70);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(88, 18);
            lblUnits.TabIndex = 16;
            lblUnits.Text = "XXXXXXXX";
            lblUnits.TextChanged += lblUnits_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 52);
            label8.Name = "label8";
            label8.Size = new Size(56, 18);
            label8.TabIndex = 16;
            label8.Text = "Lines:";
            // 
            // lblLines
            // 
            lblLines.AutoSize = true;
            lblLines.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLines.ForeColor = Color.White;
            lblLines.Location = new Point(88, 52);
            lblLines.Name = "lblLines";
            lblLines.Size = new Size(88, 18);
            lblLines.TabIndex = 16;
            lblLines.Text = "XXXXXXXX";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(0, 34);
            label9.Name = "label9";
            label9.Size = new Size(69, 18);
            label9.TabIndex = 16;
            label9.Text = "Status: ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(88, 34);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(88, 18);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "XXXXXXXX";
            lblStatus.TextChanged += lblStatus_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 16);
            label2.Name = "label2";
            label2.Size = new Size(82, 18);
            label2.TabIndex = 16;
            label2.Text = "Putaway:";
            // 
            // lblPutaway
            // 
            lblPutaway.AutoSize = true;
            lblPutaway.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPutaway.ForeColor = Color.White;
            lblPutaway.Location = new Point(88, 16);
            lblPutaway.Name = "lblPutaway";
            lblPutaway.Size = new Size(88, 18);
            lblPutaway.TabIndex = 16;
            lblPutaway.Text = "XXXXXXXX";
            lblPutaway.TextChanged += lblPutaway_TextChanged;
            // 
            // dgPutaway
            // 
            dgPutaway.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPutaway.BackgroundColor = Color.Black;
            dgPutaway.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgPutaway.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgPutaway.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgPutaway.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgPutaway.DefaultCellStyle = dataGridViewCellStyle2;
            dgPutaway.GridColor = Color.White;
            dgPutaway.Location = new Point(8, 219);
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
            dgPutaway.Size = new Size(645, 170);
            dgPutaway.TabIndex = 8;
            // 
            // rbtnInput
            // 
            rbtnInput.AutoSize = true;
            rbtnInput.Location = new Point(373, 38);
            rbtnInput.Name = "rbtnInput";
            rbtnInput.Size = new Size(55, 18);
            rbtnInput.TabIndex = 16;
            rbtnInput.TabStop = true;
            rbtnInput.Text = "Input";
            rbtnInput.UseVisualStyleBackColor = true;
            rbtnInput.CheckedChanged += rbtnInput_CheckedChanged;
            rbtnInput.Click += rbtnInput_Click;
            // 
            // rbtnEdit
            // 
            rbtnEdit.AutoSize = true;
            rbtnEdit.Location = new Point(373, 56);
            rbtnEdit.Name = "rbtnEdit";
            rbtnEdit.Size = new Size(48, 18);
            rbtnEdit.TabIndex = 16;
            rbtnEdit.TabStop = true;
            rbtnEdit.Text = "Edit";
            rbtnEdit.UseVisualStyleBackColor = true;
            rbtnEdit.CheckedChanged += rbtnEdit_CheckedChanged;
            rbtnEdit.Click += rbtnEdit_Click;
            // 
            // msPutaway
            // 
            msPutaway.BackColor = Color.Transparent;
            msPutaway.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            msPutaway.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            msPutaway.Location = new Point(0, 0);
            msPutaway.Name = "msPutaway";
            msPutaway.Size = new Size(665, 24);
            msPutaway.TabIndex = 17;
            msPutaway.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reprintToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(39, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // reprintToolStripMenuItem
            // 
            reprintToolStripMenuItem.Name = "reprintToolStripMenuItem";
            reprintToolStripMenuItem.Size = new Size(180, 22);
            reprintToolStripMenuItem.Text = "Reprint";
            reprintToolStripMenuItem.Click += reprintToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(180, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editModeToolStripMenuItem, clearToolStripMenuItem, completeToolStripMenuItem, overridesToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(42, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // editModeToolStripMenuItem
            // 
            editModeToolStripMenuItem.Name = "editModeToolStripMenuItem";
            editModeToolStripMenuItem.Size = new Size(183, 22);
            editModeToolStripMenuItem.Text = "Edit Mode";
            editModeToolStripMenuItem.Click += editModeToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(183, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // completeToolStripMenuItem
            // 
            completeToolStripMenuItem.Name = "completeToolStripMenuItem";
            completeToolStripMenuItem.Size = new Size(183, 22);
            completeToolStripMenuItem.Text = "Complete Putaway";
            completeToolStripMenuItem.Click += completeToolStripMenuItem_Click;
            // 
            // overridesToolStripMenuItem
            // 
            overridesToolStripMenuItem.Name = "overridesToolStripMenuItem";
            overridesToolStripMenuItem.Size = new Size(183, 22);
            overridesToolStripMenuItem.Text = "Overrides";
            overridesToolStripMenuItem.Click += overridesToolStripMenuItem_Click;
            // 
            // PutawayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(665, 446);
            ControlBox = false;
            Controls.Add(rbtnEdit);
            Controls.Add(rbtnInput);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(txbSku);
            Controls.Add(btnPutaway);
            Controls.Add(btnFun);
            Controls.Add(dgPutaway);
            Controls.Add(btnClear);
            Controls.Add(btnClose);
            Controls.Add(lblUsername);
            Controls.Add(cbClient);
            Controls.Add(label6);
            Controls.Add(msPutaway);
            Controls.Add(pictureBox1);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msPutaway;
            Name = "PutawayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PutawayForm";
            FormClosing += PutawayForm_FormClosing;
            Load += PutawayForm_Load;
            KeyDown += PutawayForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgPutaway).EndInit();
            msPutaway.ResumeLayout(false);
            msPutaway.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private PictureBox pictureBox1;
        private ComboBox cbClient;
        private Label label6;
        private Button btnClose;
        private Button btnClear;
        private Button btnFun;
        private Button btnPutaway;
        private TextBox txbSku;
        private Label label1;
        private Panel panel1;
        private Label lblWalks;
        private Label lblUnits;
        private Label lblLines;
        private Label lblStatus;
        private Label lblPutaway;
        private Label label2;
        private Label label5;
        private Label label3;
        private Label label7;
        private Label label8;
        private Label label9;
        private DataGridView dgPutaway;
        private RadioButton rbtnInput;
        private RadioButton rbtnEdit;
        private MenuStrip msPutaway;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem reprintToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem editModeToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem completeToolStripMenuItem;
        private ToolStripMenuItem overridesToolStripMenuItem;
    }
}