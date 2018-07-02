
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QuanLyPhongMachTu
{
    public partial class DangNhap : Form
    {
        
           
        public DangNhap()
        {
            InitializeComponent();
        }

      


        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

                e.Cancel = true;

            }


        }

        private void buton_DangNhap_Click(object sender, EventArgs e)
        {
            string TenDangNhap = this.txb_TenDangNhap.Text;
            string MatKhau = txb_MatKhau.Text;

            if (NHANVIEN_BUS.Instance.LoginBUS(TenDangNhap, MatKhau))
            {

                NHANVIEN bs = NHANVIEN_BUS.Instance.GetAccountByUserName(TenDangNhap);

                Form_Chinh f = new Form_Chinh(bs);
                this.Hide();
                f.ShowDialog();
               
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
        private void buton_Thoat(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
