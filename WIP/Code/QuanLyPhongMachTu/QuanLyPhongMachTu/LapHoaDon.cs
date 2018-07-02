using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyPhongMachTu
{
    public partial class frmLapHoaDon : Form
    {
        private LapHoaDonBUS lhdBus;
        public frmLapHoaDon()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lhdBus = new LapHoaDonBUS();

            List<LapHoaDonDTO> lshMaPK = new List<LapHoaDonDTO>();
            lshMaPK = lhdBus.LoadMaPK();
            cmbMaPhieuKham.DataSource = lshMaPK;
            cmbMaPhieuKham.DisplayMember = "Mapk";

            loadHoaDon();

        }
        //loadHoaDon
        private void loadHoaDon()
        {

            if (lhdBus.loadHoaDon() == null)
            {
                MessageBox.Show("Không có thông tin hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvThongTinHoaDon.Columns.Clear();
            }
            else
            {

                this.dgvThongTinHoaDon.Columns.Clear();
                this.dgvThongTinHoaDon.DataSource = null;
                this.dgvThongTinHoaDon.AutoGenerateColumns = false;
                this.dgvThongTinHoaDon.AllowUserToAddRows = false;


                dgvThongTinHoaDon.DataSource = lhdBus.loadHoaDon();

                DataGridViewTextBoxColumn mahdCol = new DataGridViewTextBoxColumn();
                mahdCol.Name = "MaHD";
                mahdCol.HeaderText = "Mã hóa đơn";
                mahdCol.DataPropertyName = "MaHD";
                mahdCol.Width = 150;
                this.dgvThongTinHoaDon.Columns.Add(mahdCol);

                DataGridViewTextBoxColumn mapkCol = new DataGridViewTextBoxColumn();
                mapkCol.Name = "MaPK";
                mapkCol.HeaderText = "Mã phiếu khám";
                mapkCol.DataPropertyName = "MaPK";
                mapkCol.Width = 150;
                this.dgvThongTinHoaDon.Columns.Add(mapkCol);


                DataGridViewTextBoxColumn tienkhamCol = new DataGridViewTextBoxColumn();
                tienkhamCol.Name = "ChiPhiKham";
                tienkhamCol.HeaderText = "Chi phí khám";
                tienkhamCol.DataPropertyName = "ChiPhiKham";
                tienkhamCol.Width = 150;
                this.dgvThongTinHoaDon.Columns.Add(tienkhamCol);

                DataGridViewTextBoxColumn tienthuocCol = new DataGridViewTextBoxColumn();
                tienthuocCol.Name = "ChiPhiThuoc";
                tienthuocCol.HeaderText = "Chi phí thuốc";
                tienthuocCol.DataPropertyName = "ChiPhiThuoc";
                tienthuocCol.Width = 150;
                this.dgvThongTinHoaDon.Columns.Add(tienthuocCol);

                DataGridViewTextBoxColumn tongtienCol = new DataGridViewTextBoxColumn();
                tongtienCol.Name = "TongTien";
                tongtienCol.HeaderText = "Tổng tiền";
                tongtienCol.DataPropertyName = "TongTien";
                tongtienCol.Width = 150;
                this.dgvThongTinHoaDon.Columns.Add(tongtienCol);

                CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.dgvThongTinHoaDon.DataSource];
                myCurrencyManager.Refresh();



            }
        }

        private void loadThongTin()
        {
            LapHoaDonDTO a = new LapHoaDonDTO();
            a.Mapk = int.Parse(cmbMaPhieuKham.Text);
            if (lhdBus.KtMaPK(a) == null)
            {
                MessageBox.Show("Không tồn tại mã phiếu khám", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lhdBus.loadThongTin(a) == null)
            {
                MessageBox.Show("Không có thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else txtTenBenhNhan.Text = lhdBus.loadThongTin(a).Tenbn;

            if (lhdBus.loadCTTT(a) == null)
            {
                MessageBox.Show("Không có chi tiết toa thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvThongTinChiTiet.Columns.Clear();
            }
            else
            {
                this.dgvThongTinChiTiet.Columns.Clear();
                this.dgvThongTinChiTiet.DataSource = null;
                this.dgvThongTinChiTiet.AutoGenerateColumns = false;
                this.dgvThongTinChiTiet.AllowUserToAddRows = false;

                dgvThongTinChiTiet.DataSource = lhdBus.loadCTTT(a);
                DataGridViewTextBoxColumn tenthuocCol = new DataGridViewTextBoxColumn();
                tenthuocCol.Name = "TenThuoc";
                tenthuocCol.HeaderText = "Tên thuốc";
                tenthuocCol.DataPropertyName = "TenThuoc";
                tenthuocCol.Width = 200;
                this.dgvThongTinChiTiet.Columns.Add(tenthuocCol);

                DataGridViewTextBoxColumn soluongCol = new DataGridViewTextBoxColumn();
                soluongCol.Name = "SoLuong";
                soluongCol.HeaderText = "Số lượng";
                soluongCol.DataPropertyName = "SoLuong";
                soluongCol.Width = 200;
                this.dgvThongTinChiTiet.Columns.Add(soluongCol);

                DataGridViewTextBoxColumn donvitinhCol = new DataGridViewTextBoxColumn();
                donvitinhCol.Name = "DonViTinh";
                donvitinhCol.HeaderText = "Đơn vị tính";
                donvitinhCol.DataPropertyName = "DonViTinh";
                donvitinhCol.Width = 200;
                this.dgvThongTinChiTiet.Columns.Add(donvitinhCol);

                DataGridViewTextBoxColumn dongiaCol = new DataGridViewTextBoxColumn();
                dongiaCol.Name = "DonGia";
                dongiaCol.HeaderText = "Đơn giá";
                dongiaCol.DataPropertyName = "DonGia";
                dongiaCol.Width = 200;
                this.dgvThongTinChiTiet.Columns.Add(dongiaCol);

                CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.dgvThongTinChiTiet.DataSource];
                myCurrencyManager.Refresh();

                txtChiPhiThuoc.Text = lhdBus.TinhTienThuoc(a).Chiphithuoc.ToString();
                txtTongTien.Text = (float.Parse(txtChiPhiThuoc.Text) + float.Parse(txtChiPhiKham.Text)).ToString();
            }

        }
        private void hienthi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MaPK_Click(object sender, EventArgs e)
        {

        }

        private void tenBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void mahoadon_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblChiPhiKham_Click(object sender, EventArgs e)
        {

        }

        private void lblMaHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }



        private void btnNhap_Click(object sender, EventArgs e)
        {
            this.loadThongTin();
            txtMaHoaDon.Text = "";
        }

        private void cbbChiPhiKham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void luu()
        {
            LapHoaDonDTO a = new LapHoaDonDTO();
            if (cmbMaPhieuKham.Text == "" || txtChiPhiKham.Text == "" || txtChiPhiThuoc.Text == "" || txtTongTien.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đủ thông tin", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            a.Mapk = int.Parse(cmbMaPhieuKham.Text);
            a.Chiphikham = float.Parse(txtChiPhiKham.Text);
            a.Chiphithuoc = float.Parse(txtChiPhiThuoc.Text);
            a.Tongtien = float.Parse(txtTongTien.Text);
            if (lhdBus.luu(a) == false)
            {
                MessageBox.Show("Bạn nhập sai thông tin", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã lưu thành công với mã hóa đơn là:" + lhdBus.LayMaHD().Mahd.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHoaDon.Text = lhdBus.LayMaHD().Mahd.ToString();
                loadHoaDon();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.luu();
        }

        private void cbbChiPhiKham_TextChanged(object sender, EventArgs e)
        {
            if (txtChiPhiThuoc.Text != "" && txtChiPhiKham.Text != "")
            {
                txtTongTien.Text = (float.Parse(txtChiPhiThuoc.Text) + float.Parse(txtChiPhiKham.Text)).ToString();
            }
            else MessageBox.Show("Bạn cần nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form_Chinh f = new Form_Chinh();
            this.Hide();
            f.ShowDialog();
        }

        private void frmLapHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void lblChiPhiThuoc_Click(object sender, EventArgs e)
        {

        }

        private void grbThongTinChiTiet_Enter(object sender, EventArgs e)
        {

        }

        private void txtChiPhiThuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbChiPhiKham_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void grbThaoTac_Enter(object sender, EventArgs e)
        {

        }

        private void lblTenBenhNhan_Click(object sender, EventArgs e)
        {

        }

        private void grbNhapThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void cbbMaPhieuKham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            LapHoaDonDTO a = new LapHoaDonDTO();
            try
            {
                DataGridViewRow dr = dgvThongTinHoaDon.SelectedRows[0];
                a.Mahd = int.Parse(dr.Cells["MaHD"].Value.ToString());
                if (lhdBus.xoa(a) == false)
                {
                    MessageBox.Show("Xóa không thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bạn đã xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadHoaDon();
                }
            }

            catch
            {
                MessageBox.Show("Bạn cần chọn mã hóa đơn cần xóa", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


    }
}
