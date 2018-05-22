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
    public partial class DOITHONGTIN : Form
    {
        private BACSI bs;

        public BACSI Bs
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

        public DOITHONGTIN(BACSI bs) : this()
        {
            Bs = bs;


        }
        public DOITHONGTIN()
        {
            InitializeComponent();
            

        }

        void ChangeAccount(BACSI bacsi)
        {
            txb_Ma.Text = bacsi.MaBS1;
            txb_Ten.Text = bacsi.TenBS1;
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
            //private DOITHONGTIN thongtincanhan;
            private BACSI bACSI;

            //public DOITHONGTIN Thongtincanhan
            //{
            //    get
            //    {
            //        return thongtincanhan;
            //    }

            //    set
            //    {
            //        thongtincanhan = value;
            //    }
            //}

            public BACSI BACSI
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

            //public DOITHONGTINEvent(DOITHONGTIN thongtincanhan)
            //{
            //    this. bACSI = thongtincanhan;
            //}

            public DOITHONGTINEvent(BACSI bACSI)
            {
                this.BACSI = bACSI;
            }
        }

        // cap nhat thong tin
        void CapNhatThongTin()
        {
            string MaBS = txb_Ma.Text;
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
                if (BACSI_BUS.Instance.CapNhatThongTin(MaBS, TenBS, TenDangNhap, MatKhauCu, MatKhauMoi))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if(capNhat != null)
                    {
                        capNhat(this, new DOITHONGTINEvent(BACSI_BUS.Instance.GetAccountByUserName(TenDangNhap)));
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

                //Form_Chinh x = new Form_Chinh(Bs);
                this.Hide();
               // x.ShowDialog();

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
                Form_Chinh x = new Form_Chinh(Bs);
                this.Hide();
                x.ShowDialog();
            }
        }
    }
}
