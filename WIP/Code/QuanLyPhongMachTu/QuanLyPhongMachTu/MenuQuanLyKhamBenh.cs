using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongMachTu
{
    public partial class MenuQuanLyKhamBenh : Form
    {
        public MenuQuanLyKhamBenh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemThongTinBenhNhan bn = new ThemThongTinBenhNhan();
            bn.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LapPhieuKhamBenh_GUI pk = new LapPhieuKhamBenh_GUI();
            pk.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmGhiKetQuaVaoPK f = new frmGhiKetQuaVaoPK();
            this.Hide();
            f.ShowDialog();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmKiemTraHoSoBenhAn x = new frmKiemTraHoSoBenhAn();
            this.Hide();
            x.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlr == DialogResult.Yes)
            {

                Form_Chinh x = new Form_Chinh();
                this.Hide();
                x.ShowDialog();

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLapHoaDon f = new frmLapHoaDon();
            this.Hide();
            f.ShowDialog();
        }

        private void MenuQuanLyKhamBenh_Load(object sender, EventArgs e)
        {

        }

        private void MenuQuanLyKhamBenh_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form_Chinh f = new Form_Chinh();
            f.ShowDialog();
        }
    }
}
