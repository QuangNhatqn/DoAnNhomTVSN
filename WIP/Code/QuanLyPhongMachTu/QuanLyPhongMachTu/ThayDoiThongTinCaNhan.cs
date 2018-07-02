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
using BUS;
using System.Data.SqlClient;

namespace QuanLyPhongMachTu
{
    public partial class ThayDoiThongTinCaNhan : Form
    {
        private NHANVIEN bs;

        public NHANVIEN Bs
        {
            get
            {
                return bs;
            }

            set
            {
                bs = value;
                ChangeAccount(bs);
            }
        }

        public ThayDoiThongTinCaNhan(NHANVIEN bs) : this()
        {
            Bs = bs;


        }
        public ThayDoiThongTinCaNhan()
        {
            InitializeComponent();
            

        }

        void ChangeAccount(NHANVIEN bacsi)
        {
            
            txb_Ma.Text = bacsi.MaNV1.ToString();
            txb_Ten.Text = bacsi.TenNV1;
            txb_TenDangNhap.Text= bacsi.TenDangNhap1;
        }

        private event EventHandler<DOITHONGTINEvent> capNhat;
        public event EventHandler<DOITHONGTINEvent> CapNhat
        {
            add { capNhat += value; }
            remove { capNhat -= value; }
        }

        public class DOITHONGTINEvent : EventArgs
        {
            
            private NHANVIEN bACSI;
            public NHANVIEN BACSI
            {
                get
                {
                    return bACSI;
                }

                set
                {
                    bACSI = value;
                }
            }
            public DOITHONGTINEvent(NHANVIEN bACSI)
            {
                this.BACSI = bACSI;
            }
        }

        // cap nhat thong tin
        void CapNhatThongTin()
        {
            int MaBS = int.Parse(txb_Ma.Text);
            string TenBS = txb_Ten.Text;
            string TenDangNhap = txb_TenDangNhap.Text;
            string MatKhauCu = txb_MatKhauCu.Text;
            string MatKhauMoi = txb_MatKhauMoi.Text;
            string NhapLaiMKM = txb_NhapLaiMatKhauMoi.Text;

            // neu nhap lai mat khau khac voi mat khau moi thi ko thuc hien
            if(!MatKhauMoi.Equals(NhapLaiMKM))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới đúng với mật khẩu mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (NHANVIEN_BUS.Instance.CapNhatThongTin(MaBS, TenBS, TenDangNhap, MatKhauCu, MatKhauMoi))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if(capNhat != null)
                    {
                        capNhat(this, new DOITHONGTINEvent(NHANVIEN_BUS.Instance.GetAccountByUserName(TenDangNhap)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu cũ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
        }

       

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_SUA_Click(object sender, EventArgs e)
        {

            CapNhatThongTin();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ketqua = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ketqua == DialogResult.OK)
            {
                this.Hide();
    
            }
            else
            {

                return;
            }

        }

        private void DOITHONGTIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

                e.Cancel = true;

            }
            else
            {
                
                this.Hide();
               
            }
        }
    }
}
