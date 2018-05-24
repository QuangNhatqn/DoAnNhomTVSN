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

namespace QuanLyPhongMachTu
{
    public partial class CTTT_GUI : Form
    {
        private string MaPK;
        public CTTT_GUI(string mapk) : this()
        {
            MaPK = mapk;
            txb_MaPK.Text = MaPK;

        }
       // private object DataGirdViewRow;
        public CTTT_GUI()
        {
            InitializeComponent();
            
        }
        public void TaiDuLieuVaoDataGirdView()
        {
            List<CTTT> dsBN = CTTT_BUS.LoadCTTT();

            //dgv_CTTT.DataSource = dsBN;
        }

        public void XoaCTTT()
        {

            if (txb_MaPK.Text == "")
            {
                MessageBox.Show("Hãy chọn Chi tiết phiếu khám bệnh cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            CTTT CTTTDTO = new CTTT();
            CTTTDTO.MaPK1 = int.Parse(txb_MaPK.Text);

            if (CTTT_BUS.XoaCTTT(CTTTDTO) == true)
            {
               

                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CTTT_GUI_Load(object sender, EventArgs e)
        {
       //ODO: This line of code loads data into the 'quanlikhambenhDataSet1.CTTT' table.You can move, or remove it, as needed.
            this.cTTTTableAdapter.Fill(this.quanlikhambenhDataSet1.CTTT, MaPK);
            //// TODO: This line of code loads data into the 'quanlikhambenhDataSet.HOADON' table. You can move, or remove it, as needed.
            this.hOADONTableAdapter.Fill(this.quanlikhambenhDataSet.HOADON, MaPK);
            //XoaDuLieu();
        }

       public void XoaDuLieu()
        {
            this.hOADONTableAdapter.DeleteHOADON(MaPK);
            this.hOADONTableAdapter.Fill(this.quanlikhambenhDataSet.HOADON, MaPK);

            this.cTTTTableAdapter.DeleteCTTT(MaPK);
            this.cTTTTableAdapter.Fill(this.quanlikhambenhDataSet1.CTTT, MaPK);
        }
        private void button_XOAHOADON_Click(object sender, EventArgs e)
        {
            this.hOADONTableAdapter.DeleteHOADON(MaPK);
            this.hOADONTableAdapter.Fill(this.quanlikhambenhDataSet.HOADON, MaPK);
        }

        private void button_XoaCTTT_Click(object sender, EventArgs e)
        {

            this.cTTTTableAdapter.DeleteCTTT(MaPK);
            this.cTTTTableAdapter.Fill(this.quanlikhambenhDataSet1.CTTT, MaPK);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult ketqua=MessageBox.Show("Bạn có muốn xóa hết toàn bộ thông tin trong HÓA ĐƠN và CHI TIẾT TOA THUỐC?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ketqua == DialogResult.OK)
            {
                // XOA CHI TIET TOA THUOC
                this.cTTTTableAdapter.DeleteCTTT(MaPK);
                this.cTTTTableAdapter.Fill(this.quanlikhambenhDataSet1.CTTT, MaPK);
                // XOA HOADON
                this.hOADONTableAdapter.DeleteHOADON(MaPK);
                this.hOADONTableAdapter.Fill(this.quanlikhambenhDataSet.HOADON, MaPK);
               
            }
            else
            {
                return;
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn trở về màn hình chính?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (kq == DialogResult.OK)
            {
                LapPhieuKhamBenh_GUI x = new LapPhieuKhamBenh_GUI();
                this.Hide();
                x.Show();
            }
            else
            {
                return;
            }
        }

        private void CTTT_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

                e.Cancel = true;

            }
            else
            {

                LapPhieuKhamBenh_GUI x = new LapPhieuKhamBenh_GUI();
                this.Hide();
                x.Show();
            }
        }

       
    }
  }

