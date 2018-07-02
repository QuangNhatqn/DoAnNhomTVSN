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
    public partial class frmGhiKetQuaVaoPK : Form
    {
        private GhiKQVaoPKBUS gkqBus;
        private GhiKQVaoPKDTO LayDTO = new GhiKQVaoPKDTO();
        public frmGhiKetQuaVaoPK()
        {
            InitializeComponent();
        }

        private void lblCachDung_Click(object sender, EventArgs e)
        {

        }

        private static bool IsNumber(string val)
        {
            if (val != "")
                return Regex.IsMatch(val, @"^[0-9]\d*\.?[0]*$");
            else return true;
        }
        private bool KiemTraMaPK()
        {
            GhiKQVaoPKDTO a = new GhiKQVaoPKDTO();
            if (IsNumber(txtMaPK.Text) == false || txtMaPK.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã phiếu khám là số!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            a.Mapk = int.Parse(txtMaPK.Text);
            if (gkqBus.KtMaPK(a) == false)
            {
                MessageBox.Show("Mã phiếu khám không tồn tại hoặc đã bị xóa!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void LuuKetQua()
        {
            GhiKQVaoPKDTO a = new GhiKQVaoPKDTO();
            if (txtKetQua.Text == "" || txtMaPK.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (KiemTraMaPK() == false) return;
            a.Mapk = int.Parse(txtMaPK.Text);
            a.Ketqua = txtKetQua.Text;

            if (gkqBus.updateKetQua(a) == true)
            {
                MessageBox.Show("Ghi kết quả thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void loadTenThuoc()
        {
            if (gkqBus.loadTenThuoc() == null)
            {
                return;
            }
            List<GhiKQVaoPKDTO> lshTenThuoc = new List<GhiKQVaoPKDTO>();
            lshTenThuoc = gkqBus.loadTenThuoc();
            cbbTenThuoc.DataSource = lshTenThuoc;
            cbbTenThuoc.DisplayMember = "Tenthuoc";
        }


        private void btnNhapKQ_Click(object sender, EventArgs e)
        {
            this.LuuKetQua();
            XuatChiTiet();

        }

        private void frmGhiKetQuaVaoPK_Load(object sender, EventArgs e)
        {
            this.gkqBus = new GhiKQVaoPKBUS();
            this.loadTenThuoc();
        }

        public void TaiDuLieuVaoDataGirdView()
        {
            if (KiemTraMaPK() == false) return;
            GhiKQVaoPKDTO a = new GhiKQVaoPKDTO();
            a.Mapk = int.Parse(txtMaPK.Text);
            if (GhiKQVaoPKBUS.LoadCTTT(a) == null)
            {
                MessageBox.Show("Không có dữ liệu chi tiết toa thuốc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvCTTT.Columns.Clear();
                return;
            }

            this.dgvCTTT.Columns.Clear();
            this.dgvCTTT.DataSource = null;

            this.dgvCTTT.AutoGenerateColumns = false;
            this.dgvCTTT.AllowUserToAddRows = false;
            this.dgvCTTT.DataSource = GhiKQVaoPKBUS.LoadCTTT(a);

            DataGridViewTextBoxColumn tenthuocCol = new DataGridViewTextBoxColumn();
            tenthuocCol.Name = "TenThuoc";
            tenthuocCol.HeaderText = "Tên thuốc";
            tenthuocCol.DataPropertyName = "TenThuoc";
            tenthuocCol.Width = 130;
            this.dgvCTTT.Columns.Add(tenthuocCol);

            DataGridViewTextBoxColumn soluongCol = new DataGridViewTextBoxColumn();
            soluongCol.Name = "SoLuong";
            soluongCol.HeaderText = "Số lượng";
            soluongCol.DataPropertyName = "SoLuong";
            soluongCol.Width = 80;
            this.dgvCTTT.Columns.Add(soluongCol);

            DataGridViewTextBoxColumn donvitinhCol = new DataGridViewTextBoxColumn();
            donvitinhCol.Name = "DonViTinh";
            donvitinhCol.HeaderText = "Đơn vị tính";
            donvitinhCol.DataPropertyName = "DonViTinh";
            this.dgvCTTT.Columns.Add(donvitinhCol);

            DataGridViewTextBoxColumn cachdungCol = new DataGridViewTextBoxColumn();
            cachdungCol.Name = "CachDung";
            cachdungCol.HeaderText = "Cách dùng";
            cachdungCol.DataPropertyName = "CachDung";
            cachdungCol.Width = 500;
            this.dgvCTTT.Columns.Add(cachdungCol);


            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.dgvCTTT.DataSource];
            myCurrencyManager.Refresh();

        }

        private void SuaCTTTDaTonTai(GhiKQVaoPKDTO a)
        {
            if (GhiKQVaoPKBUS.SuaCTTTDaTonTai(a) == true)
            {
                return;
            }
        }
        // THÊM CTTT

        private void btnThem_Click(object sender, EventArgs e)
        {
            GhiKQVaoPKDTO gkqDTO = new GhiKQVaoPKDTO();
            if (txtCachDung.Text == "" || nudSoLuong.Text == "0")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraMaPK() == false) return;
            gkqDTO.Mapk = int.Parse(txtMaPK.Text);
            gkqDTO.Tenthuoc = cbbTenThuoc.Text;
            //gkqDTO.Trangthai = 1;
            gkqDTO.Soluong = int.Parse(nudSoLuong.Text);
            gkqDTO.Cachdung = txtCachDung.Text;

            if (gkqBus.LayGiaThuoc(gkqDTO) == null)
            {
                MessageBox.Show("Vui lòng nhập đúng Tên thuốc!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            float x = gkqBus.LayGiaThuoc(gkqDTO).Gia;
            float y = x * gkqDTO.Soluong;
            gkqDTO.Dongia = y;
            if (GhiKQVaoPKBUS.ThemCTTT(gkqDTO) == false)
            {
                SuaCTTTDaTonTai(gkqDTO);
            }

            MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            TaiDuLieuVaoDataGirdView();

        }





        private void frmGhiKetQuaVaoPK_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát!", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                this.Hide();
                Form_Chinh f = new Form_Chinh();
                f.ShowDialog();
            }
        }


        private void SuaCTTT()
        {
            GhiKQVaoPKDTO SuaDTO = new GhiKQVaoPKDTO();
            if (txtCachDung.Text == "" || nudSoLuong.Text == "0")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SuaDTO.Tenthuoc = cbbTenThuoc.Text;
            SuaDTO.Soluong = int.Parse(nudSoLuong.Text);
            if (gkqBus.LayGiaThuoc(SuaDTO) == null)
            {
                MessageBox.Show("Vui lòng nhập đúng Tên thuốc!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            float x = gkqBus.LayGiaThuoc(SuaDTO).Gia;
            float y = x * SuaDTO.Soluong;
            SuaDTO.Dongia = y;
            SuaDTO.Cachdung = txtCachDung.Text;
            if (LayDTO.Tenthuoc == null)
            {
                MessageBox.Show("Bạn phải chọn chi tiết toa thuốc trước!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (GhiKQVaoPKBUS.SuaCTTT(LayDTO, SuaDTO) == false)
            {
                XoaCTTT();
                SuaDTO.Mapk = int.Parse(txtMaPK.Text);
                SuaCTTTDaTonTai(SuaDTO);
            }

            MessageBox.Show("Sửa chi tiết toa thuốc thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDuLieuVaoDataGirdView();
        }

        private bool XoaCTTT()
        {
            if (LayDTO.Tenthuoc == null)
            {
                MessageBox.Show("Bạn phải chọn chi tiết toa thuốc trước!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (GhiKQVaoPKBUS.XoaCTTT(LayDTO) == true)
            {
                return true;
            }
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaCTTT();
        }


        private void dgvCTTT_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraMaPK() == false)
                return;
            else
            {
                XuatChiTiet();
                TaiDuLieuVaoDataGirdView();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XoaCTTT() == false) return;
            MessageBox.Show("Bạn đã xóa thành công chi tiết toa thuốc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDuLieuVaoDataGirdView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form_Chinh f = new Form_Chinh();
            this.Hide();
            f.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTenBN_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {

        }
        private void XuatChiTiet()
        {
            KiemTraHoSoBenhAnDTO a = new KiemTraHoSoBenhAnDTO();

           // KiemTraHoSoBenhAnDTO x 
                a.Mapk = int.Parse(txtMaPK.Text);
                if (gkqBus.XuatCTPK(a) == null)
                {
                    MessageBox.Show("Không có dữ liệu chi tiết phiếu khám!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtpNgayKham.Value = gkqBus.XuatCTPK(a).Ngaykham;
                txtTenBN.Text = gkqBus.XuatCTPK(a).Tenbn;
                dtpNgaySinh.Value = gkqBus.XuatCTPK(a).Ngaysinh;
                if (gkqBus.XuatCTPK(a).Gioitinh == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else rdbNu.Checked = true;
                txtBacSiKham.Text = gkqBus.XuatCTPK(a).Bacsi;
                txtTrieuChung.Text = gkqBus.XuatCTPK(a).Trieuchung;
                txtChuanDoan.Text = gkqBus.XuatCTPK(a).Chuandoan;
            
        }

        private void dgvCTTT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvCTTT.SelectedRows[0];
                cbbTenThuoc.Text = dr.Cells["TenThuoc"].Value.ToString();
                nudSoLuong.Text = dr.Cells["SoLuong"].Value.ToString();
                txtCachDung.Text = dr.Cells["CachDung"].Value.ToString();
                LayDTO.Mapk = int.Parse(txtMaPK.Text);
                LayDTO.Tenthuoc = cbbTenThuoc.Text;
            }
            catch { return; }
        }
    }
}
