namespace OneStock
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            cbClient = new ComboBox();
            txbSearch = new TextBox();
            panel1 = new Panel();
            lblAttr2 = new Label();
            lblAttr1 = new Label();
            lblObsCode = new Label();
            lblStatus = new Label();
            lblDescription = new Label();
            lblSku = new Label();
            lblFreeStock = new Label();
            panel2 = new Panel();
            lblGoodsIn = new Label();
            lblQuar = new Label();
            lblAloc = new Label();
            lblDemand = new Label();
            lblDesp = new Label();
            lblOnOrder = new Label();
            lblOnHand = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dgStock = new DataGridView();
            label8 = new Label();
            label1 = new Label();
            btnExit = new Button();
            dgPoBreak = new DataGridView();
            dgScripts = new DataGridView();
            label2 = new Label();
            lblLogBook = new Label();
            btnClear = new Button();
            lblDueDate = new Label();
            label3 = new Label();
            txbSku = new TextBox();
            lblUsername = new Label();
            pbBorga = new PictureBox();
            btnMove = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgPoBreak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgScripts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBorga).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, -33);
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
            cbClient.Location = new Point(12, 112);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(314, 22);
            cbClient.TabIndex = 4;
            cbClient.Enter += cbClient_Enter;
            cbClient.Leave += cbClient_Leave;
            // 
            // txbSearch
            // 
            txbSearch.CharacterCasing = CharacterCasing.Upper;
            txbSearch.Location = new Point(12, 154);
            txbSearch.MaxLength = 50;
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(314, 21);
            txbSearch.TabIndex = 5;
            txbSearch.Enter += txbSearch_Enter;
            txbSearch.Leave += txbSearch_Leave;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(lblAttr2);
            panel1.Controls.Add(lblAttr1);
            panel1.Controls.Add(lblObsCode);
            panel1.Controls.Add(lblStatus);
            panel1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(12, 234);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 63);
            panel1.TabIndex = 6;
            // 
            // lblAttr2
            // 
            lblAttr2.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblAttr2.Location = new Point(148, 42);
            lblAttr2.Name = "lblAttr2";
            lblAttr2.Size = new Size(163, 21);
            lblAttr2.TabIndex = 0;
            lblAttr2.Text = "Attr2";
            // 
            // lblAttr1
            // 
            lblAttr1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblAttr1.Location = new Point(0, 42);
            lblAttr1.Name = "lblAttr1";
            lblAttr1.Size = new Size(142, 21);
            lblAttr1.TabIndex = 0;
            lblAttr1.Text = "Attr1";
            // 
            // lblObsCode
            // 
            lblObsCode.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblObsCode.Location = new Point(0, 0);
            lblObsCode.Name = "lblObsCode";
            lblObsCode.Size = new Size(314, 21);
            lblObsCode.TabIndex = 0;
            lblObsCode.Text = "ObsCode";
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(0, 21);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(126, 21);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status";
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.Location = new Point(12, 200);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(314, 31);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // lblSku
            // 
            lblSku.Cursor = Cursors.IBeam;
            lblSku.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSku.Location = new Point(12, 196);
            lblSku.Name = "lblSku";
            lblSku.Size = new Size(287, 22);
            lblSku.TabIndex = 0;
            lblSku.Text = "SKU - Barcode";
            lblSku.Visible = false;
            // 
            // lblFreeStock
            // 
            lblFreeStock.BackColor = Color.Black;
            lblFreeStock.Font = new Font("Arial Rounded MT Bold", 22F, FontStyle.Regular, GraphicsUnit.Point);
            lblFreeStock.ForeColor = Color.White;
            lblFreeStock.Location = new Point(12, 315);
            lblFreeStock.Name = "lblFreeStock";
            lblFreeStock.Size = new Size(93, 70);
            lblFreeStock.TabIndex = 0;
            lblFreeStock.Text = "QTY";
            lblFreeStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(lblGoodsIn);
            panel2.Controls.Add(lblQuar);
            panel2.Controls.Add(lblAloc);
            panel2.Controls.Add(lblDemand);
            panel2.Controls.Add(lblDesp);
            panel2.Controls.Add(lblOnOrder);
            panel2.Controls.Add(lblOnHand);
            panel2.Font = new Font("Arial Rounded MT Bold", 7F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(111, 300);
            panel2.Name = "panel2";
            panel2.Size = new Size(215, 104);
            panel2.TabIndex = 6;
            // 
            // lblGoodsIn
            // 
            lblGoodsIn.Location = new Point(3, 58);
            lblGoodsIn.Name = "lblGoodsIn";
            lblGoodsIn.Size = new Size(149, 15);
            lblGoodsIn.TabIndex = 0;
            lblGoodsIn.Text = "Goods In QTY";
            // 
            // lblQuar
            // 
            lblQuar.Location = new Point(3, 43);
            lblQuar.Name = "lblQuar";
            lblQuar.Size = new Size(149, 15);
            lblQuar.TabIndex = 0;
            lblQuar.Text = "QUAR QTY";
            // 
            // lblAloc
            // 
            lblAloc.Location = new Point(3, 15);
            lblAloc.Name = "lblAloc";
            lblAloc.Size = new Size(148, 14);
            lblAloc.TabIndex = 0;
            lblAloc.Text = "Allocation QTY";
            // 
            // lblDemand
            // 
            lblDemand.Location = new Point(3, 29);
            lblDemand.Name = "lblDemand";
            lblDemand.Size = new Size(148, 14);
            lblDemand.TabIndex = 0;
            lblDemand.Text = "Demand QTY";
            // 
            // lblDesp
            // 
            lblDesp.Location = new Point(3, 90);
            lblDesp.Name = "lblDesp";
            lblDesp.Size = new Size(148, 14);
            lblDesp.TabIndex = 0;
            lblDesp.Text = "In Desp QTY";
            // 
            // lblOnOrder
            // 
            lblOnOrder.Location = new Point(3, 73);
            lblOnOrder.Name = "lblOnOrder";
            lblOnOrder.Size = new Size(148, 14);
            lblOnOrder.TabIndex = 0;
            lblOnOrder.Text = "On Order QTY";
            // 
            // lblOnHand
            // 
            lblOnHand.Location = new Point(3, 0);
            lblOnHand.Name = "lblOnHand";
            lblOnHand.Size = new Size(153, 15);
            lblOnHand.TabIndex = 0;
            lblOnHand.Text = "On Hand QTY";
            // 
            // label5
            // 
            label5.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 407);
            label5.Name = "label5";
            label5.Size = new Size(195, 28);
            label5.TabIndex = 0;
            label5.Text = "Stock Breakdown";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 95);
            label6.Name = "label6";
            label6.Size = new Size(40, 14);
            label6.TabIndex = 7;
            label6.Text = "Client";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 137);
            label7.Name = "label7";
            label7.Size = new Size(48, 14);
            label7.TabIndex = 7;
            label7.Text = "Search";
            // 
            // dgStock
            // 
            dgStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgStock.BackgroundColor = Color.Black;
            dgStock.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.Black;
            dataGridViewCellStyle10.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.Black;
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.Black;
            dataGridViewCellStyle11.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.SelectionBackColor = Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = Color.White;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgStock.DefaultCellStyle = dataGridViewCellStyle11;
            dgStock.GridColor = Color.White;
            dgStock.Location = new Point(12, 438);
            dgStock.Name = "dgStock";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.Black;
            dataGridViewCellStyle12.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = Color.White;
            dataGridViewCellStyle12.SelectionBackColor = Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgStock.RowHeadersVisible = false;
            dgStock.RowTemplate.Height = 25;
            dgStock.Size = new Size(314, 164);
            dgStock.TabIndex = 8;
            // 
            // label8
            // 
            label8.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(12, 605);
            label8.Name = "label8";
            label8.Size = new Size(292, 22);
            label8.TabIndex = 0;
            label8.Text = "PO Breakdown";
            // 
            // label1
            // 
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 762);
            label1.Name = "label1";
            label1.Size = new Size(292, 22);
            label1.TabIndex = 0;
            label1.Text = "Scripts Breakdown";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(12, 868);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 39);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // dgPoBreak
            // 
            dgPoBreak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPoBreak.BackgroundColor = Color.Black;
            dgPoBreak.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.Black;
            dataGridViewCellStyle13.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = Color.White;
            dataGridViewCellStyle13.SelectionBackColor = Color.Black;
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgPoBreak.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgPoBreak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.Black;
            dataGridViewCellStyle14.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = Color.White;
            dataGridViewCellStyle14.SelectionBackColor = Color.Black;
            dataGridViewCellStyle14.SelectionForeColor = Color.White;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dgPoBreak.DefaultCellStyle = dataGridViewCellStyle14;
            dgPoBreak.GridColor = Color.White;
            dgPoBreak.Location = new Point(12, 630);
            dgPoBreak.Name = "dgPoBreak";
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.Black;
            dataGridViewCellStyle15.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = Color.White;
            dataGridViewCellStyle15.SelectionBackColor = Color.Black;
            dataGridViewCellStyle15.SelectionForeColor = Color.White;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dgPoBreak.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dgPoBreak.RowHeadersVisible = false;
            dgPoBreak.RowTemplate.Height = 25;
            dgPoBreak.Size = new Size(314, 129);
            dgPoBreak.TabIndex = 8;
            // 
            // dgScripts
            // 
            dgScripts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgScripts.BackgroundColor = Color.Black;
            dgScripts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.Black;
            dataGridViewCellStyle16.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle16.ForeColor = Color.White;
            dataGridViewCellStyle16.SelectionBackColor = Color.Black;
            dataGridViewCellStyle16.SelectionForeColor = Color.White;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            dgScripts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dgScripts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = Color.Black;
            dataGridViewCellStyle17.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle17.ForeColor = Color.White;
            dataGridViewCellStyle17.SelectionBackColor = Color.Black;
            dataGridViewCellStyle17.SelectionForeColor = Color.White;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.False;
            dgScripts.DefaultCellStyle = dataGridViewCellStyle17;
            dgScripts.GridColor = Color.White;
            dgScripts.Location = new Point(12, 787);
            dgScripts.Name = "dgScripts";
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = Color.Black;
            dataGridViewCellStyle18.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle18.ForeColor = Color.White;
            dataGridViewCellStyle18.SelectionBackColor = Color.Black;
            dataGridViewCellStyle18.SelectionForeColor = Color.White;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
            dgScripts.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            dgScripts.RowHeadersVisible = false;
            dgScripts.RowTemplate.Height = 25;
            dgScripts.Size = new Size(314, 75);
            dgScripts.TabIndex = 8;
            dgScripts.CellClick += dgScripts_CellClick;
            // 
            // label2
            // 
            label2.BackColor = Color.Black;
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 300);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 0;
            label2.Text = "Free Stock";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogBook
            // 
            lblLogBook.BackColor = Color.FromArgb(224, 224, 224);
            lblLogBook.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogBook.ForeColor = Color.Silver;
            lblLogBook.Location = new Point(12, 910);
            lblLogBook.Name = "lblLogBook";
            lblLogBook.Size = new Size(314, 14);
            lblLogBook.TabIndex = 9;
            lblLogBook.Text = "LogBook";
            lblLogBook.Click += lblLogBook_Click;
            lblLogBook.MouseEnter += lblLogBook_MouseEnter;
            lblLogBook.MouseLeave += lblLogBook_MouseLeave;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(226, 868);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 39);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // lblDueDate
            // 
            lblDueDate.BackColor = Color.Black;
            lblDueDate.ForeColor = Color.White;
            lblDueDate.Location = new Point(12, 366);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(93, 19);
            lblDueDate.TabIndex = 0;
            lblDueDate.Text = "DueDate";
            lblDueDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.Black;
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 385);
            label3.Name = "label3";
            label3.Size = new Size(93, 19);
            label3.TabIndex = 0;
            label3.Text = " ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbSku
            // 
            txbSku.BackColor = Color.White;
            txbSku.BorderStyle = BorderStyle.None;
            txbSku.CharacterCasing = CharacterCasing.Upper;
            txbSku.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbSku.Location = new Point(12, 178);
            txbSku.MaxLength = 255;
            txbSku.Name = "txbSku";
            txbSku.ReadOnly = true;
            txbSku.Size = new Size(314, 19);
            txbSku.TabIndex = 5;
            txbSku.Text = "SKU - BARCODE";
            txbSku.Enter += txbSearch_Enter;
            txbSku.Leave += txbSearch_Leave;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(77, 14);
            lblUsername.TabIndex = 10;
            lblUsername.Text = "USERNAME";
            // 
            // pbBorga
            // 
            pbBorga.Cursor = Cursors.Hand;
            pbBorga.Image = Properties.Resources.OnestockBorgaBlack;
            pbBorga.Location = new Point(286, 12);
            pbBorga.Name = "pbBorga";
            pbBorga.Size = new Size(40, 40);
            pbBorga.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBorga.TabIndex = 11;
            pbBorga.TabStop = false;
            pbBorga.Click += pbBorga_Click;
            pbBorga.MouseEnter += pbBorga_MouseEnter;
            pbBorga.MouseLeave += pbBorga_MouseLeave;
            // 
            // btnMove
            // 
            btnMove.BackColor = Color.Black;
            btnMove.Cursor = Cursors.Hand;
            btnMove.FlatStyle = FlatStyle.Flat;
            btnMove.Font = new Font("Arial Rounded MT Bold", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btnMove.ForeColor = Color.White;
            btnMove.Location = new Point(213, 410);
            btnMove.Name = "btnMove";
            btnMove.Size = new Size(113, 22);
            btnMove.TabIndex = 12;
            btnMove.Text = "Movements";
            btnMove.UseVisualStyleBackColor = false;
            btnMove.Click += btnMove_Click;
            btnMove.MouseEnter += btnMove_MouseEnter;
            btnMove.MouseLeave += btnMove_MouseLeave;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(338, 929);
            Controls.Add(btnMove);
            Controls.Add(pbBorga);
            Controls.Add(lblUsername);
            Controls.Add(lblLogBook);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Controls.Add(dgScripts);
            Controls.Add(dgPoBreak);
            Controls.Add(dgStock);
            Controls.Add(lblDescription);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(lblDueDate);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(lblFreeStock);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(lblSku);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(txbSku);
            Controls.Add(txbSearch);
            Controls.Add(cbClient);
            Controls.Add(pictureBox1);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgPoBreak).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgScripts).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBorga).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox cbClient;
        private Panel panel1;
        private Label lblAttr2;
        private Label lblAttr1;
        private Label lblObsCode;
        private Label lblStatus;
        private Label lblDescription;
        private Label lblSku;
        private Label lblFreeStock;
        private Panel panel2;
        private Label lblGoodsIn;
        private Label lblQuar;
        private Label lblAloc;
        private Label lblDemand;
        private Label lblOnOrder;
        private Label lblOnHand;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dgStock;
        private Label label8;
        private Label label1;
        private Button btnExit;
        private DataGridView dgPoBreak;
        private DataGridView dgScripts;
        private Label label2;
        private Label lblLogBook;
        private Button btnClear;
        private Label lblDesp;
        private Label lblDueDate;
        private Label label3;
        public TextBox txbSearch;
        public TextBox txbSku;
        private Label lblUsername;
        private PictureBox pbBorga;
        private Button btnMove;
    }
}