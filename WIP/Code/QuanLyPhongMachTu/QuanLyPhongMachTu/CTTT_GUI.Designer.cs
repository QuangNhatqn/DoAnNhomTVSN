namespace QuanLyPhongMachTu
{
    partial class CTTT_GUI
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
            this.components = new System.ComponentModel.Container();
            this.button_XoaCTTT = new System.Windows.Forms.Button();
            this.button_XOAHOADON = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txb_MaPK = new System.Windows.Forms.TextBox();
            this.dgv_HoaDon = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maPKDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maThuocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donGiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cachDungDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTTTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanlikhambenhDataSet1 = new QuanLyPhongMachTu.QuanlikhambenhDataSet1();
            this.maHDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maPKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienKhamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienThuocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanlikhambenhDataSet = new QuanLyPhongMachTu.QuanlikhambenhDataSet();
            this.hOADONTableAdapter = new QuanLyPhongMachTu.QuanlikhambenhDataSetTableAdapters.HOADONTableAdapter();
            this.cTTTTableAdapter = new QuanLyPhongMachTu.QuanlikhambenhDataSet1TableAdapters.CTTTTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTTTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlikhambenhDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlikhambenhDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button_XoaCTTT
            // 
            this.button_XoaCTTT.Location = new System.Drawing.Point(15, 453);
            this.button_XoaCTTT.Name = "button_XoaCTTT";
            this.button_XoaCTTT.Size = new System.Drawing.Size(145, 69);
            this.button_XoaCTTT.TabIndex = 1;
            this.button_XoaCTTT.Text = "Xóa CTTT";
            this.button_XoaCTTT.UseVisualStyleBackColor = true;
            this.button_XoaCTTT.Click += new System.EventHandler(this.button_XoaCTTT_Click);
            // 
            // button_XOAHOADON
            // 
            this.button_XOAHOADON.Location = new System.Drawing.Point(192, 453);
            this.button_XOAHOADON.Name = "button_XOAHOADON";
            this.button_XOAHOADON.Size = new System.Drawing.Size(145, 69);
            this.button_XOAHOADON.TabIndex = 1;
            this.button_XOAHOADON.Text = "Xóa HOADON";
            this.button_XOAHOADON.UseVisualStyleBackColor = true;
            this.button_XOAHOADON.Click += new System.EventHandler(this.button_XOAHOADON_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(982, 453);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 69);
            this.button3.TabIndex = 1;
            this.button3.Text = "THOÁT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txb_MaPK
            // 
            this.txb_MaPK.Location = new System.Drawing.Point(242, 51);
            this.txb_MaPK.Name = "txb_MaPK";
            this.txb_MaPK.Size = new System.Drawing.Size(854, 20);
            this.txb_MaPK.TabIndex = 2;
            // 
            // dgv_HoaDon
            // 
            this.dgv_HoaDon.AutoGenerateColumns = false;
            this.dgv_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHDDataGridViewTextBoxColumn,
            this.maPKDataGridViewTextBoxColumn,
            this.tienKhamDataGridViewTextBoxColumn,
            this.tienThuocDataGridViewTextBoxColumn,
            this.tongTienDataGridViewTextBoxColumn});
            this.dgv_HoaDon.DataSource = this.hOADONBindingSource;
            this.dgv_HoaDon.Location = new System.Drawing.Point(242, 287);
            this.dgv_HoaDon.Name = "dgv_HoaDon";
            this.dgv_HoaDon.Size = new System.Drawing.Size(854, 150);
            this.dgv_HoaDon.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maPKDataGridViewTextBoxColumn1,
            this.maThuocDataGridViewTextBoxColumn,
            this.soLuongDataGridViewTextBoxColumn,
            this.donGiaDataGridViewTextBoxColumn,
            this.cachDungDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cTTTBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(242, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(854, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // maPKDataGridViewTextBoxColumn1
            // 
            this.maPKDataGridViewTextBoxColumn1.DataPropertyName = "MaPK";
            this.maPKDataGridViewTextBoxColumn1.HeaderText = "MaPK";
            this.maPKDataGridViewTextBoxColumn1.Name = "maPKDataGridViewTextBoxColumn1";
            // 
            // maThuocDataGridViewTextBoxColumn
            // 
            this.maThuocDataGridViewTextBoxColumn.DataPropertyName = "MaThuoc";
            this.maThuocDataGridViewTextBoxColumn.HeaderText = "MaThuoc";
            this.maThuocDataGridViewTextBoxColumn.Name = "maThuocDataGridViewTextBoxColumn";
            // 
            // soLuongDataGridViewTextBoxColumn
            // 
            this.soLuongDataGridViewTextBoxColumn.DataPropertyName = "SoLuong";
            this.soLuongDataGridViewTextBoxColumn.HeaderText = "SoLuong";
            this.soLuongDataGridViewTextBoxColumn.Name = "soLuongDataGridViewTextBoxColumn";
            // 
            // donGiaDataGridViewTextBoxColumn
            // 
            this.donGiaDataGridViewTextBoxColumn.DataPropertyName = "DonGia";
            this.donGiaDataGridViewTextBoxColumn.HeaderText = "DonGia";
            this.donGiaDataGridViewTextBoxColumn.Name = "donGiaDataGridViewTextBoxColumn";
            // 
            // cachDungDataGridViewTextBoxColumn
            // 
            this.cachDungDataGridViewTextBoxColumn.DataPropertyName = "CachDung";
            this.cachDungDataGridViewTextBoxColumn.HeaderText = "CachDung";
            this.cachDungDataGridViewTextBoxColumn.Name = "cachDungDataGridViewTextBoxColumn";
            // 
            // cTTTBindingSource
            // 
            this.cTTTBindingSource.DataMember = "CTTT";
            this.cTTTBindingSource.DataSource = this.quanlikhambenhDataSet1;
            // 
            // quanlikhambenhDataSet1
            // 
            this.quanlikhambenhDataSet1.DataSetName = "QuanlikhambenhDataSet1";
            this.quanlikhambenhDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // maHDDataGridViewTextBoxColumn
            // 
            this.maHDDataGridViewTextBoxColumn.DataPropertyName = "MaHD";
            this.maHDDataGridViewTextBoxColumn.HeaderText = "MaHD";
            this.maHDDataGridViewTextBoxColumn.Name = "maHDDataGridViewTextBoxColumn";
            // 
            // maPKDataGridViewTextBoxColumn
            // 
            this.maPKDataGridViewTextBoxColumn.DataPropertyName = "MaPK";
            this.maPKDataGridViewTextBoxColumn.HeaderText = "MaPK";
            this.maPKDataGridViewTextBoxColumn.Name = "maPKDataGridViewTextBoxColumn";
            // 
            // tienKhamDataGridViewTextBoxColumn
            // 
            this.tienKhamDataGridViewTextBoxColumn.DataPropertyName = "TienKham";
            this.tienKhamDataGridViewTextBoxColumn.HeaderText = "TienKham";
            this.tienKhamDataGridViewTextBoxColumn.Name = "tienKhamDataGridViewTextBoxColumn";
            // 
            // tienThuocDataGridViewTextBoxColumn
            // 
            this.tienThuocDataGridViewTextBoxColumn.DataPropertyName = "TienThuoc";
            this.tienThuocDataGridViewTextBoxColumn.HeaderText = "TienThuoc";
            this.tienThuocDataGridViewTextBoxColumn.Name = "tienThuocDataGridViewTextBoxColumn";
            // 
            // tongTienDataGridViewTextBoxColumn
            // 
            this.tongTienDataGridViewTextBoxColumn.DataPropertyName = "TongTien";
            this.tongTienDataGridViewTextBoxColumn.HeaderText = "TongTien";
            this.tongTienDataGridViewTextBoxColumn.Name = "tongTienDataGridViewTextBoxColumn";
            // 
            // hOADONBindingSource
            // 
            this.hOADONBindingSource.DataMember = "HOADON";
            this.hOADONBindingSource.DataSource = this.quanlikhambenhDataSet;
            // 
            // quanlikhambenhDataSet
            // 
            this.quanlikhambenhDataSet.DataSetName = "QuanlikhambenhDataSet";
            this.quanlikhambenhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hOADONTableAdapter
            // 
            this.hOADONTableAdapter.ClearBeforeFill = true;
            // 
            // cTTTTableAdapter
            // 
            this.cTTTTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thông Tin chi tiết về hòa đơn và chi tiết phiếu khám";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "CHI TIẾT TOA THUỐC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "HÓA ĐƠN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "MÃ PHIẾU KHÁM";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(366, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(572, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "XÓA TẤT CẢ THÔNG TIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CTTT_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgv_HoaDon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_MaPK);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_XOAHOADON);
            this.Controls.Add(this.button_XoaCTTT);
            this.Name = "CTTT_GUI";
            this.Text = "CTTT_GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CTTT_GUI_FormClosing);
        
            this.Load += new System.EventHandler(this.CTTT_GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTTTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlikhambenhDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlikhambenhDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_XoaCTTT;
        private System.Windows.Forms.Button button_XOAHOADON;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txb_MaPK;
        private System.Windows.Forms.DataGridView dgv_HoaDon;
        private QuanlikhambenhDataSet quanlikhambenhDataSet;
        private System.Windows.Forms.BindingSource hOADONBindingSource;
        private QuanlikhambenhDataSetTableAdapters.HOADONTableAdapter hOADONTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienKhamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienThuocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private QuanlikhambenhDataSet1 quanlikhambenhDataSet1;
        private System.Windows.Forms.BindingSource cTTTBindingSource;
        private QuanlikhambenhDataSet1TableAdapters.CTTTTableAdapter cTTTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPKDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maThuocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn donGiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cachDungDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}