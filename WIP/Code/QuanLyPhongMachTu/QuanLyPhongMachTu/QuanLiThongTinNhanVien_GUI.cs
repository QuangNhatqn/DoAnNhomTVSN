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
    public partial class QuanLiThongTinNhanVien_GUI : Form
    {
        public QuanLiThongTinNhanVien_GUI()
        {
            InitializeComponent();
        }
        private void QuanLiThongTinBacSi_GUI_Load(object sender, EventArgs e)
        {
            TaiDuLieuVaoDataGirdView();
        }
        public void TaiDuLieuVaoDataGirdView()
        {
            List<NHANVIEN> dsBN = QuanLyThongTinNhanVien_BUS.LoadNhanVien();

            dgv_ThongTinBacSi.DataSource = dsBN;

            dgv_ThongTinBacSi.Columns[0].HeaderText = "Mã Bác Sỹ";
            dgv_ThongTinBacSi.Columns[1].HeaderText = "Họ Và Tên";
            dgv_ThongTinBacSi.Columns[2].HeaderText = "Tên Đăng Nhập";
            dgv_ThongTinBacSi.Columns[3].HeaderText = "Mật Khẩu";
            dgv_ThongTinBacSi.Columns[4].HeaderText = "Phân Quyền";
            dgv_ThongTinBacSi.Columns[1].Width = 150;
            dgv_ThongTinBacSi.Columns[2].Width = 150;
            dgv_ThongTinBacSi.Columns[4].Width = 85;
            dgv_ThongTinBacSi.Columns[3].Width = 90;
            // lệnh ẩn cột tình trạng tồn tại
            dgv_ThongTinBacSi.Columns[5].Visible = false;
           
        }

        private void dgv_ThongTinBacSi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_ThongTinBacSi.SelectedRows.Count < 0)
            //{
            //    return;
            //}
            try
            {
                DataGridViewRow dr = dgv_ThongTinBacSi.SelectedRows[0];
                txb_Ma.Text = dr.Cells["MaNV1"].Value.ToString();
                txb_Ten.Text = dr.Cells["TenNV1"].Value.ToString();
                txb_TenDangNhap.Text = dr.Cells["TenDangNhap1"].Value.ToString();
                txb_MatKhauCu.Text = dr.Cells["Matkhau1"].Value.ToString();
                if (dr.Cells["LoaiNV1"].Value.ToString() == "1")
                {
                    rbt_Loai1.Checked = true;
                }
                else if (dr.Cells["LoaiNV1"].Value.ToString() == "2")
                {
                    rbt_Loai2.Checked = true;
                }
                else if (dr.Cells["LoaiNV1"].Value.ToString() == "3")
                {
                    rbt_Loai3.Checked = true;
                }
                else
                {
                    rbt_Loai4.Checked = true;
                }

            }
            catch { return; }
          }


        // THEM TAI KHOAN


        bool KiemTraTonTai(NHANVIEN bn)
        {
            if (QuanLyThongTinNhanVien_BUS.KiemTraTonTai(bn) == true)
            {
                DataTable dt = QuanLyThongTinNhanVien_BUS.BangKiemTraTonTai(bn);
                if (dt == null)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("TÀI KHOẢN ĐÃ TỒN TẠI, VUI LÒNG TẠO LẠI TÊN ĐĂNG NHẬP ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            else
            {
                return false;
            }
           
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (txb_Ten.Text == "")
            {
                MessageBox.Show(" Vui lòng nhập Họ và Tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txb_TenDangNhap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // khoi tao doi tuong DTO
            NHANVIEN bnDTO = new NHANVIEN();
           
            bnDTO.TenNV1 = txb_Ten.Text;
            bnDTO.TenDangNhap1 = txb_TenDangNhap.Text;
            bnDTO.Matkhau1 = txb_MatKhauCu.Text;
            
            if(rbt_Loai1.Checked == true)
            {
                bnDTO.LoaiNV1 = 1;
            }
            else if(rbt_Loai2.Checked == true)
            {
                bnDTO.LoaiNV1 = 2;
            }
            else if (rbt_Loai3.Checked == true)
            {
                bnDTO.LoaiNV1 = 3;
            }
            else
            {
                bnDTO.LoaiNV1 = 4;
            }

            if (KiemTraTonTai(bnDTO) == false)
            {
                // goi lop nghiep vu NHANVIEN_BUS
                if (QuanLyThongTinNhanVien_BUS.ThemNhanVien(bnDTO) == true)
                {
                    TaiDuLieuVaoDataGirdView();
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    return;
                }
                else
                {
                    MessageBox.Show("Không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        // SUA THONG TIN TAI KHOAN
        private void button3_Click(object sender, EventArgs e)
        {
            // khoi tao doi tuong DTO
            NHANVIEN bnDTO = new NHANVIEN();
            bnDTO.MaNV1 = int.Parse(txb_Ma.Text);
            bnDTO.TenNV1 = txb_Ten.Text;
            bnDTO.TenDangNhap1 = txb_TenDangNhap.Text;
            bnDTO.Matkhau1 = txb_MatKhauCu.Text;

            if (rbt_Loai1.Checked == true)
            {
                bnDTO.LoaiNV1 = 1;
            }
            else if (rbt_Loai2.Checked == true)
            {
                bnDTO.LoaiNV1 = 2;
            }
            else if (rbt_Loai3.Checked == true)
            {
                bnDTO.LoaiNV1 = 3;
            }
            else
            {
                bnDTO.LoaiNV1 = 4;
            }

            // goi lop nghiep vu BENHNHAN_BUS
            if (QuanLyThongTinNhanVien_BUS.SuaThongTinNhanVien(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();
                //int LayDong = dgv_ThongTinBacSi.Rows.Count;

                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // XOA THONG TIN TAI KHOAN

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            NHANVIEN bnDTO = new NHANVIEN();
            bnDTO.MaNV1 = int.Parse(txb_Ma.Text);
            bnDTO.TenNV1 = txb_Ten.Text;
            bnDTO.TenDangNhap1 = txb_TenDangNhap.Text;
            bnDTO.Matkhau1 = txb_MatKhauCu.Text;
            // goi lop nghiep vu BENHNHAN_BUS
            if (QuanLyThongTinNhanVien_BUS.XoaNhanVien(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();
                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlr == DialogResult.Yes)
            {

                Form_Chinh x = new Form_Chinh();
                this.Hide();
                x.ShowDialog();

            }
        }

        
    }
}
