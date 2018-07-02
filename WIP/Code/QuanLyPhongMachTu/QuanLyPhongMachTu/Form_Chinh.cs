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
using static QuanLyPhongMachTu.ThayDoiThongTinCaNhan;

namespace QuanLyPhongMachTu
{
    public partial class Form_Chinh : Form
    {

        private NHANVIEN bs;

        private Form_Chinh chinh;

        public NHANVIEN Bs
        {
            get
            {
                return bs;
            }

            set
            {
                bs = value;
                //ChangeAccount(bs.Loai1);
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

        public Form_Chinh(NHANVIEN bs) : this()
        {
            Bs = bs;
            ChangeAccount(Bs.LoaiNV1);
        }
        public Form_Chinh()
        {
            InitializeComponent();
            
        }
        void ChangeAccount(int Loai)
        {
            thToolStripMenuItem.Text += " (" + Bs.TenDangNhap1 + ")";
            adminToolStripMenuItem.Enabled = Loai == 1;
            button_Admin.Enabled = Loai == 1;
            button_BaoCao.Enabled = Loai == 1;
            qToolStripMenuItem.Enabled = Loai == 1;

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

            //ThemThongTinBenhNhan f = new ThemThongTinBenhNhan();
            //this.Hide();
            //f.ShowDialog();
            MenuQuanLyKhamBenh ql = new MenuQuanLyKhamBenh();
            this.Hide();
            ql.ShowDialog();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void themTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLiThongTinNhanVien_GUI x = new QuanLiThongTinNhanVien_GUI();
            this.Hide();
            x.ShowDialog();
        }

        //private void Form_Chinh_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
        //    {

        //        e.Cancel = true;
        //        return;
        //    }

        //    Application.Exit();
        //}

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThayDoiThongTinCaNhan x = new ThayDoiThongTinCaNhan(Bs);
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
            this.Hide();
            DangNhap x = new DangNhap();
            x.ShowDialog();
            
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
            ThayDoiThongTinCaNhan x = new ThayDoiThongTinCaNhan();
            this.Hide();
            x.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            QuanLiThongTinNhanVien_GUI x = new QuanLiThongTinNhanVien_GUI();
            this.Hide();
            x.ShowDialog();
        }

        private void tìmKiếmLịchSửKhámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKiemTraHoSoBenhAn x = new frmKiemTraHoSoBenhAn();
            this.Hide();
            x.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThuoc Thuoc = new QuanLyThuoc();
            this.Hide();
            Thuoc.ShowDialog();
        }

        private void Form_Chinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            //{

            //    e.Cancel = true;
            //    return;
            //}
            //DangNhap a = new DangNhap();
            //this.Hide();
            //a.ShowDialog();
            //Application.Exit();
        }

        private void thayĐổiTiềnKhámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuyDinhTienKhamGUI f = new QuyDinhTienKhamGUI();
            this.Hide();
            f.ShowDialog();
        }

        private void button_BaoCao_Click(object sender, EventArgs e)
        {
            LapBaoCao f = new LapBaoCao();
            this.Hide();
            f.ShowDialog();
        }
    }
}
