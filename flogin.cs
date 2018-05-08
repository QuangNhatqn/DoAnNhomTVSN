using Login.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
        }

        private void flogin_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        


        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?","Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

                e.Cancel = true;
              
            }


        }


        //private void buton_Login_Click(object sender, EventArgs e)
        //{
        //    string TenDangNhap = tboxUseName.Text;
        //    string MatKhau = txb_MatKhau.Text;
        //    if (Login(TenDangNhap, MatKhau))
        //    {
        //        fManager f = new fManager();
        //        this.Hide();
        //        f.ShowDialog();
        //        // this.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
        //    }

        //}


        private void buton_DangNhap_Click(object sender, EventArgs e)
        {
            string TenDangNhap = tboxUseName.Text;
            string MatKhau = txb_MatKhau.Text;
            if (Login(TenDangNhap, MatKhau))
            {
                fManager f = new fManager();
                this.Hide();
                f.ShowDialog();
                // this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        bool Login(string TenDangNhap, string MatKhau)
        {

            //return DAO.TaiKhoanDAO.Instance.DangNhap(TenDangNhap,MatKhau);
            return TaiKhoanDAO.Instance.DangNhap(TenDangNhap, MatKhau);

        }

        private void buton_Thoat(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
