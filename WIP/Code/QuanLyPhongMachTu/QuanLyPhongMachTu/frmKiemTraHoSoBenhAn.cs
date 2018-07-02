using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyPhongMachTu
{
    public partial class frmKiemTraHoSoBenhAn : Form
    {
        private KiemTraHoSoBenhAnBUS KtBus;
        public frmKiemTraHoSoBenhAn()
        {
            InitializeComponent();
        }

        private void KiemTraHoSoBenhAn_Load(object sender, EventArgs e)
        {
            this.KtBus = new KiemTraHoSoBenhAnBUS();
        }

        private static bool IsNumber(string val)
        {
            if (val != "")
                return Regex.IsMatch(val, @"^[0-9]\d*\.?[0]*$");
            else return true;
        }
        private void XuatLichSuKham()
        {
            KiemTraHoSoBenhAnDTO a = new KiemTraHoSoBenhAnDTO();
            if (IsNumber(txtMaBenhNhan.Text) == false || txtMaBenhNhan.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã bệnh nhân là số!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            a.Mabn = int.Parse(txtMaBenhNhan.Text);
            if (KtBus.XuatLichSuKham(a) == null)
            {
                MessageBox.Show("Mã bệnh nhân không tồn tại! Vui lòng nhập lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.dgvLichSuKhamBenh.Columns.Clear();
            this.dgvLichSuKhamBenh.DataSource = null;


            this.dgvLichSuKhamBenh.AutoGenerateColumns = false;
            this.dgvLichSuKhamBenh.AllowUserToAddRows = false;
            this.dgvLichSuKhamBenh.DataSource = KtBus.XuatLichSuKham(a);


            DataGridViewTextBoxColumn mapkCol = new DataGridViewTextBoxColumn();
            mapkCol.Name = "MaPK";
            mapkCol.HeaderText = "Mã phiếu khám";
            mapkCol.DataPropertyName = "MaPK";
            mapkCol.Width = 120;
            this.dgvLichSuKhamBenh.Columns.Add(mapkCol);


            DataGridViewTextBoxColumn ngaykhamCol = new DataGridViewTextBoxColumn();
            ngaykhamCol.Name = "NgayKham";
            ngaykhamCol.HeaderText = "Ngày Khám";
            ngaykhamCol.DataPropertyName = "NgayKham";
            ngaykhamCol.Width = 130;
            this.dgvLichSuKhamBenh.Columns.Add(ngaykhamCol);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.dgvLichSuKhamBenh.DataSource];
            myCurrencyManager.Refresh();
        }

        private void XuatChiTiet()
        {
            KiemTraHoSoBenhAnDTO a = new KiemTraHoSoBenhAnDTO();
            try
            {
                DataGridViewRow dr = dgvLichSuKhamBenh.SelectedRows[0];
                a.Mapk = int.Parse(dr.Cells["MaPK"].Value.ToString());
                if (KtBus.XuatCTPK(a) == null)
                {
                    MessageBox.Show("Không có dữ liệu chi tiết phiếu khám!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtpNgayKham.Value = KtBus.XuatCTPK(a).Ngaykham;
                txtTenBN.Text = KtBus.XuatCTPK(a).Tenbn;
                dtpNgaySinh.Value = KtBus.XuatCTPK(a).Ngaysinh;
                if (KtBus.XuatCTPK(a).Gioitinh == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else rdbNu.Checked = true;
                txtBacSiKham.Text = KtBus.XuatCTPK(a).Bacsi;
                txtTrieuChung.Text = KtBus.XuatCTPK(a).Trieuchung;
                txtChuanDoan.Text = KtBus.XuatCTPK(a).Chuandoan;

                if (KtBus.XuatCTTT(a) == null)
                {
                    MessageBox.Show("Không có dữ liệu chi tiết toa thuốc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgvThongTinToaThuoc.Columns.Clear();
                    return;
                }

                this.dgvThongTinToaThuoc.Columns.Clear();
                this.dgvThongTinToaThuoc.DataSource = null;

                this.dgvThongTinToaThuoc.AutoGenerateColumns = false;
                this.dgvThongTinToaThuoc.AllowUserToAddRows = false;
                this.dgvThongTinToaThuoc.DataSource = KtBus.XuatCTTT(a);

                DataGridViewTextBoxColumn tenthuocCol = new DataGridViewTextBoxColumn();
                tenthuocCol.Name = "TenThuoc";
                tenthuocCol.HeaderText = "Tên thuốc";
                tenthuocCol.DataPropertyName = "TenThuoc";
                tenthuocCol.Width = 130;
                this.dgvThongTinToaThuoc.Columns.Add(tenthuocCol);

                DataGridViewTextBoxColumn soluongCol = new DataGridViewTextBoxColumn();
                soluongCol.Name = "SoLuong";
                soluongCol.HeaderText = "Số lượng";
                soluongCol.DataPropertyName = "SoLuong";
                soluongCol.Width = 80;
                this.dgvThongTinToaThuoc.Columns.Add(soluongCol);

                DataGridViewTextBoxColumn donvitinhCol = new DataGridViewTextBoxColumn();
                donvitinhCol.Name = "DonViTinh";
                donvitinhCol.HeaderText = "Đơn vị tính";
                donvitinhCol.DataPropertyName = "DonViTinh";
                this.dgvThongTinToaThuoc.Columns.Add(donvitinhCol);

                DataGridViewTextBoxColumn dongiaCol = new DataGridViewTextBoxColumn();
                dongiaCol.Name = "DonGia";
                dongiaCol.HeaderText = "Đơn giá";
                dongiaCol.DataPropertyName = "DonGia";
                this.dgvThongTinToaThuoc.Columns.Add(dongiaCol);

                DataGridViewTextBoxColumn cachdungCol = new DataGridViewTextBoxColumn();
                cachdungCol.Name = "CachDung";
                cachdungCol.HeaderText = "Cách dùng";
                cachdungCol.DataPropertyName = "CachDung";
                cachdungCol.Width = 500;
                this.dgvThongTinToaThuoc.Columns.Add(cachdungCol);


                CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.dgvThongTinToaThuoc.DataSource];
                myCurrencyManager.Refresh();
            }
            catch { return; }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            this.XuatLichSuKham();
        }

        private void frmKiemTraHoSoBenhAn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát!", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                Form_Chinh f = new Form_Chinh();
                this.Hide();
                f.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form_Chinh f = new Form_Chinh();
            this.Hide();
            f.ShowDialog();
        }

       

        private void dgvLichSuKhamBenh_Click(object sender, EventArgs e)
        {
            this.XuatChiTiet();
        }
    }
}
