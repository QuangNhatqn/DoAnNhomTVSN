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
using static QuanLyPhongMachTu.DOITHONGTIN;

namespace QuanLyPhongMachTu
{
    public partial class Form_Chinh : Form
    {

        private BACSI bs;

        private Form_Chinh chinh;

        public BACSI Bs
        {
            get
            {
                return bs;
            }

            set
            {
                bs = value;
                ChangeAccount();
            }
        }

        public Form_Chinh Chinh
        {
            get
            {
                return chinh;
            }

            set
            {
                chinh = value;
            }
        }

        public Form_Chinh(BACSI bs) : this()
        {
            Bs = bs;
            

        }
        public Form_Chinh()
        {
            InitializeComponent();
            
        }
        void ChangeAccount()
        {
           // adminToolStripMenuItem.Enabled = type == 1;
            //thôngTinToolStripMenuItem.Text += " (" + Bs.TenDangNhap1 + ")";
            thToolStripMenuItem.Text += " (" + Bs.TenDangNhap1 + ")";
        }


        private void Form_Chinh_Load(object sender, EventArgs e)
        {

        }



        private void thôngTinPhầnMềmVàHướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thêmBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void thToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thêmBệnhNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThemThongTinBenhNhan x = new ThemThongTinBenhNhan();
            x.ShowDialog();
        }

        private void lậpPhiếuKhámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LapPhieuKhamBenh_GUI a = new LapPhieuKhamBenh_GUI();
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ThemThongTinBenhNhan f = new ThemThongTinBenhNhan();
            this.Hide();
            f.ShowDialog();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void tìmKiếmLịchSửKhámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    fKiemTraHoSoBenhAn a = new fKiemTraHoSoBenhAn();
        //    this.Hide();
        //    a.ShowDialog();
        //}

        private void themTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan_GUI x = new ThemTaiKhoan_GUI();
            this.Hide();
            x.ShowDialog();
        }

        private void Form_Chinh_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DOITHONGTIN x = new DOITHONGTIN(Bs);
            x.CapNhat += x_CapNhat;
           // this.Hide();
            x.Show();
        }

        void x_CapNhat(object sender, DOITHONGTINEvent e)
        {
            thToolStripMenuItem.Text = "Thông tin tài khoản (" + e.BACSI.TenDangNhap1 + ")";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            QuanLyThuoc thuoc = new QuanLyThuoc();
            this.Hide();
            thuoc.ShowDialog();

        }

        private void thêmThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThuoc thuoc = new QuanLyThuoc();
            thuoc.ShowDialog();
            this.Hide();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chỉnhSửaThôngTinThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThuoc thuoc = new QuanLyThuoc();
            thuoc.ShowDialog();
            this.Hide();
        }

        private void xóaThuốcKhỏiDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThuoc thuoc = new QuanLyThuoc();
            thuoc.ShowDialog();
            this.Hide();
        }

        private void chỉnhSửaThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DOITHONGTIN x = new DOITHONGTIN();
            this.Hide();
            x.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ThemTaiKhoan_GUI x = new ThemTaiKhoan_GUI();
            this.Hide();
            x.ShowDialog();
        }
    }
}
