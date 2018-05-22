namespace QuanLyPhongMachTu
{
    partial class QuanLyThuoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbb_DVT = new System.Windows.Forms.ComboBox();
            this.txb_Gia = new System.Windows.Forms.TextBox();
            this.txb_TenThuoc = new System.Windows.Forms.TextBox();
            this.txb_MaThuoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_Thuoc = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Thuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbb_DVT);
            this.panel1.Controls.Add(this.txb_Gia);
            this.panel1.Controls.Add(this.txb_TenThuoc);
            this.panel1.Controls.Add(this.txb_MaThuoc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(32, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 268);
            this.panel1.TabIndex = 0;
            // 
            // cbb_DVT
            // 
            this.cbb_DVT.FormattingEnabled = true;
            this.cbb_DVT.Items.AddRange(new object[] {
            "Viên",
            "Hộp",
            "Vỉ",
            "Chai"});
            this.cbb_DVT.Location = new System.Drawing.Point(279, 164);
            this.cbb_DVT.Name = "cbb_DVT";
            this.cbb_DVT.Size = new System.Drawing.Size(100, 21);
            this.cbb_DVT.TabIndex = 2;
            this.cbb_DVT.Text = "Viên";
            // 
            // txb_Gia
            // 
            this.txb_Gia.Location = new System.Drawing.Point(279, 221);
            this.txb_Gia.Name = "txb_Gia";
            this.txb_Gia.Size = new System.Drawing.Size(100, 20);
            this.txb_Gia.TabIndex = 0;
            // 
            // txb_TenThuoc
            // 
            this.txb_TenThuoc.Location = new System.Drawing.Point(279, 89);
            this.txb_TenThuoc.Name = "txb_TenThuoc";
            this.txb_TenThuoc.Size = new System.Drawing.Size(100, 20);
            this.txb_TenThuoc.TabIndex = 0;
            // 
            // txb_MaThuoc
            // 
            this.txb_MaThuoc.Location = new System.Drawing.Point(279, 27);
            this.txb_MaThuoc.Name = "txb_MaThuoc";
            this.txb_MaThuoc.Size = new System.Drawing.Size(100, 20);
            this.txb_MaThuoc.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Đơn Vị Tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Thuốc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Thuốc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Thuốc";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 64);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sửa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Thuoc);
            this.panel2.Location = new System.Drawing.Point(512, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 254);
            this.panel2.TabIndex = 3;
            // 
            // dgv_Thuoc
            // 
            this.dgv_Thuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Thuoc.Location = new System.Drawing.Point(42, 30);
            this.dgv_Thuoc.Name = "dgv_Thuoc";
            this.dgv_Thuoc.Size = new System.Drawing.Size(391, 202);
            this.dgv_Thuoc.TabIndex = 0;
            this.dgv_Thuoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Thuoc_CellContentClick);
            this.dgv_Thuoc.Click += new System.EventHandler(this.dgv_Thuoc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(657, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 64);
            this.button2.TabIndex = 2;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(356, 392);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 64);
            this.button3.TabIndex = 2;
            this.button3.Text = "Thêm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // QuanLyThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "QuanLyThuoc";
            this.Text = "QuanLyThuoc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyThuoc_FormClosing);
            this.Load += new System.EventHandler(this.QuanLyThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Thuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txb_Gia;
        private System.Windows.Forms.TextBox txb_TenThuoc;
        private System.Windows.Forms.TextBox txb_MaThuoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_Thuoc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbb_DVT;
    }
}