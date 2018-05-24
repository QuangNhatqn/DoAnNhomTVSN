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
    public partial class ThemTaiKhoan_GUI : Form
    {
        public ThemTaiKhoan_GUI()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        // THEM TAI KHOAN

        bool KiemTraTonTai(BACSI bn)
        {
            if (BACSI_BUS.KiemTraTonTai(bn) == true)
            {
                DataTable dt = BACSI_BUS.BangKiemTraTonTai(bn);
                if (dt == null)
                {
                    return false;
                }
                else
                {
                   
                    MessageBox.Show("TÀI KHOẢN ĐÃ TỒN TẠI ", "Thông báo");
                    return true;
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (txb_Ten.Text == "")
            {
                MessageBox.Show(" Vui lòng nhập Họ và Tên lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txb_TenDangNhap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // khoi tao doi tuong DTO
           BACSI bnDTO = new BACSI();
            // bnDTO.MaBN1 = txb_MaBN.Text;
            bnDTO.TenBS1 = txb_Ten.Text;
            bnDTO.TenDangNhap1 = txb_TenDangNhap.Text;
            bnDTO.Matkhau = txb_MatKhauCu.Text;

            if (KiemTraTonTai(bnDTO) == false)
            {
                // goi lop nghiep vu BENHNHAN_BUS
                if (BACSI_BUS.ThemBacSi(bnDTO) == true)
                {
                  
         

                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TaiDuLieuVaoDataGirdView();
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
            BACSI bnDTO = new BACSI();
            bnDTO.TenBS1 = txb_Ten.Text;
            bnDTO.TenDangNhap1 = txb_TenDangNhap.Text;
            bnDTO.Matkhau = txb_MatKhauCu.Text;
            // goi lop nghiep vu BENHNHAN_BUS
            if (BACSI_BUS.SuaThongTinBacSi(bnDTO) == true)
            {
                
                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // XOA THONG TIN TAI KHOAN
        private void button_SUA_Click(object sender, EventArgs e)
        {
            BACSI bnDTO = new BACSI();
            bnDTO.TenBS1 = txb_Ten.Text;
            bnDTO.TenDangNhap1 = txb_TenDangNhap.Text;
            bnDTO.Matkhau = txb_MatKhauCu.Text;
            // goi lop nghiep vu BENHNHAN_BUS
            if (BACSI_BUS.XoaBacSi(bnDTO) == true)
            {

                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
