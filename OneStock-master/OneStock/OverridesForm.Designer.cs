namespace OneStock
{
    partial class OverridesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverridesForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cbClient = new ComboBox();
            pictureBox1 = new PictureBox();
            cbxOverride = new CheckBox();
            label6 = new Label();
            dgPutaway = new DataGridView();
            txbSku = new TextBox();
            label1 = new Label();
            btnClose = new Button();
            txbStore = new TextBox();
            txbBin = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            label4 = new Label();
            btnImport = new Button();
            pBarImport = new ProgressBar();
            lblProgress = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgPutaway).BeginInit();
            SuspendLayout();
            // 
            // cbClient
            // 
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.FormattingEnabled = true;
            cbClient.Location = new Point(12, 145);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(362, 22);
            cbClient.TabIndex = 0;
            cbClient.TextChanged += cbClient_TextChanged;
            cbClient.Enter += cbClient_Enter;
            cbClient.Leave += cbClient_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, -21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // cbxOverride
            // 
            cbxOverride.AutoSize = true;
            cbxOverride.Location = new Point(380, 147);
            cbxOverride.Name = "cbxOverride";
            cbxOverride.Size = new Size(121, 18);
            cbxOverride.TabIndex = 1;
            cbxOverride.Text = "Enable Override";
            cbxOverride.UseVisualStyleBackColor = true;
            cbxOverride.Click += cbxOverride_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 128);
            label6.Name = "label6";
            label6.Size = new Size(40, 14);
            label6.TabIndex = 8;
            label6.Text = "Client";
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
            dgPutaway.Location = new Point(12, 217);
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
            dgPutaway.Size = new Size(548, 205);
            dgPutaway.TabIndex = 9;
            // 
            // txbSku
            // 
            txbSku.CharacterCasing = CharacterCasing.Upper;
            txbSku.Location = new Point(12, 187);
            txbSku.MaxLength = 24;
            txbSku.Name = "txbSku";
            txbSku.Size = new Size(159, 21);
            txbSku.TabIndex = 2;
            txbSku.Enter += txbSku_Enter;
            txbSku.Leave += txbSku_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 170);
            label1.Name = "label1";
            label1.Size = new Size(31, 14);
            label1.TabIndex = 14;
            label1.Text = "Part";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 428);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 39);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // txbStore
            // 
            txbStore.CharacterCasing = CharacterCasing.Upper;
            txbStore.Location = new Point(177, 187);
            txbStore.MaxLength = 24;
            txbStore.Name = "txbStore";
            txbStore.Size = new Size(159, 21);
            txbStore.TabIndex = 3;
            txbStore.Enter += txbStore_Enter;
            txbStore.Leave += txbStore_Leave;
            // 
            // txbBin
            // 
            txbBin.CharacterCasing = CharacterCasing.Upper;
            txbBin.Location = new Point(342, 187);
            txbBin.MaxLength = 24;
            txbBin.Name = "txbBin";
            txbBin.Size = new Size(159, 21);
            txbBin.TabIndex = 4;
            txbBin.Enter += txbBin_Enter;
            txbBin.Leave += txbBin_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 170);
            label2.Name = "label2";
            label2.Size = new Size(38, 14);
            label2.TabIndex = 18;
            label2.Text = "Store";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 170);
            label3.Name = "label3";
            label3.Size = new Size(26, 14);
            label3.TabIndex = 19;
            label3.Text = "Bin";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Black;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(507, 183);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(53, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += btnAdd_MouseEnter;
            btnAdd.MouseLeave += btnAdd_MouseLeave;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Black;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(459, 428);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 39);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Remove";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseEnter += btnDelete_MouseEnter;
            btnDelete.MouseLeave += btnDelete_MouseLeave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(206, 56);
            label4.Name = "label4";
            label4.Size = new Size(365, 34);
            label4.TabIndex = 22;
            label4.Text = "Part Location Overrides";
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.Black;
            btnImport.Cursor = Cursors.Hand;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(118, 428);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(100, 39);
            btnImport.TabIndex = 23;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            btnImport.MouseEnter += btnImport_MouseEnter;
            btnImport.MouseLeave += btnImport_MouseLeave;
            // 
            // pBarImport
            // 
            pBarImport.Location = new Point(12, 12);
            pBarImport.Name = "pBarImport";
            pBarImport.Size = new Size(547, 10);
            pBarImport.TabIndex = 24;
            pBarImport.Visible = false;
            // 
            // lblProgress
            // 
            lblProgress.Location = new Point(12, 25);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(547, 14);
            lblProgress.TabIndex = 25;
            lblProgress.Text = "XXXX/XXXX";
            lblProgress.TextAlign = ContentAlignment.MiddleRight;
            lblProgress.Visible = false;
            // 
            // OverridesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(571, 479);
            ControlBox = false;
            Controls.Add(lblProgress);
            Controls.Add(pBarImport);
            Controls.Add(btnImport);
            Controls.Add(label4);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txbBin);
            Controls.Add(txbStore);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(txbSku);
            Controls.Add(dgPutaway);
            Controls.Add(label6);
            Controls.Add(cbxOverride);
            Controls.Add(cbClient);
            Controls.Add(pictureBox1);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OverridesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OverridesForm";
            FormClosing += OverridesForm_FormClosing;
            Load += OverridesForm_Load;
            KeyDown += OverridesForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgPutaway).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbClient;
        private PictureBox pictureBox1;
        private CheckBox cbxOverride;
        private Label label6;
        private DataGridView dgPutaway;
        private TextBox txbSku;
        private Label label1;
        private Button btnClose;
        private TextBox txbStore;
        private TextBox txbBin;
        private Label label2;
        private Label label3;
        private Button btnAdd;
        private Button btnDelete;
        private Label label4;
        private Button btnImport;
        private ProgressBar pBarImport;
        private Label lblProgress;
    }
}