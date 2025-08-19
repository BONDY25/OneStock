namespace OneStock
{
    partial class Movements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movements));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            btnExit = new Button();
            btnSearch = new Button();
            label7 = new Label();
            label6 = new Label();
            txbSearch = new TextBox();
            cbClient = new ComboBox();
            pictureBox1 = new PictureBox();
            btnClear = new Button();
            dgStock = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgStock).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(12, 554);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 39);
            btnExit.TabIndex = 4;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(626, 554);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 39);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            btnSearch.MouseEnter += btnSearch_MouseEnter;
            btnSearch.MouseLeave += btnSearch_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 135);
            label7.Name = "label7";
            label7.Size = new Size(48, 14);
            label7.TabIndex = 10;
            label7.Text = "Search";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 93);
            label6.Name = "label6";
            label6.Size = new Size(40, 14);
            label6.TabIndex = 11;
            label6.Text = "Client";
            // 
            // txbSearch
            // 
            txbSearch.CharacterCasing = CharacterCasing.Upper;
            txbSearch.Location = new Point(12, 152);
            txbSearch.MaxLength = 50;
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(314, 21);
            txbSearch.TabIndex = 1;
            txbSearch.Enter += txbSearch_Enter;
            txbSearch.Leave += txbSearch_Leave;
            // 
            // cbClient
            // 
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.FormattingEnabled = true;
            cbClient.Location = new Point(12, 110);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(314, 22);
            cbClient.TabIndex = 0;
            cbClient.Enter += cbClient_Enter;
            cbClient.Leave += cbClient_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, -42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(520, 554);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 39);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // dgStock
            // 
            dgStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgStock.BackgroundColor = Color.Black;
            dgStock.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.White;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgStock.DefaultCellStyle = dataGridViewCellStyle5;
            dgStock.GridColor = Color.White;
            dgStock.Location = new Point(12, 179);
            dgStock.Name = "dgStock";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgStock.RowHeadersVisible = false;
            dgStock.RowTemplate.Height = 25;
            dgStock.Size = new Size(714, 369);
            dgStock.TabIndex = 20;
            // 
            // Movements
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(738, 605);
            ControlBox = false;
            Controls.Add(dgStock);
            Controls.Add(btnClear);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txbSearch);
            Controls.Add(cbClient);
            Controls.Add(btnSearch);
            Controls.Add(btnExit);
            Controls.Add(pictureBox1);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Movements";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movements";
            Load += Movements_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Button btnSearch;
        private Label label7;
        private Label label6;
        public TextBox txbSearch;
        private ComboBox cbClient;
        private PictureBox pictureBox1;
        private Button btnClear;
        private DataGridView dgStock;
    }
}