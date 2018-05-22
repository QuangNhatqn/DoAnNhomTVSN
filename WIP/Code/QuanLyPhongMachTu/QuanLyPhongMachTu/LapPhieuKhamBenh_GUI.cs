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
    public partial class LapPhieuKhamBenh_GUI : Form
    {
        // LỢi dụng tích chất hàm dựng để lấy dữ liệu từ form ThemThongTinBenhNhan về form LapPhieuKhamBenh.
        private string MaBN;
        public LapPhieuKhamBenh_GUI(string mabn) : this()
        {
            MaBN = mabn;
            txb_MaBN.Text = MaBN;

        }
        private object DataGirdViewRow;
        public LapPhieuKhamBenh_GUI()
        {
            InitializeComponent();
        }

        // tai du lieu len bang lap phieu kham

        private void LapPhieuKhamBenh_GUI_Load(object sender, EventArgs e)
        {
            TaiDuLieuVaoDataGirdView();
            TaiDuLieuVaoCombobox();
        }

      
        public void TaiDuLieuVaoDataGirdView()
        {
            List<PHIEUKHAM> dsBN = LapPhieuKB_BUS.LoadPHIEUKHAM();

            dgv_PhieuKham.DataSource = dsBN;
        }

        public void TaiDuLieuVaoCombobox()
        {
            List<BACSI> dsBs = BACSI_BUS.LoadBacSi();
            comboBox_MaBS.DataSource = dsBs;
            comboBox_MaBS.DisplayMember = "TenBS1";//gia tri hien thi
            comboBox_MaBS.ValueMember = "MaBS1";//luu gia tri

            // dgv_PhieuKham.DataSource = dsBN;

        }
      


        private void LapPhieuKhamBenh_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

                e.Cancel = true;

            }
            else
            {

                Form_Chinh x = new Form_Chinh();
                this.Hide();
                x.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

                QuanLyThuoc x = new QuanLyThuoc();
                this.Hide();
                x.ShowDialog();


        }

        // đưa dữ liệu lên textbox

        private void dgv_PhieuKham_Click_1(object sender, EventArgs e)
        {
            // dua du lieu tu DataGirdView len textbox, combobox,..

            if (dgv_PhieuKham.SelectedRows.Count < 0)
            {
                return;
            }
            DataGridViewRow dr = dgv_PhieuKham.SelectedRows[0];

            txb_MaPK.Text = dr.Cells["MaPK1"].Value.ToString();
            // ma bs
            comboBox_MaBS.SelectedValue = dr.Cells["MaBS1"].Value.ToString();

            txb_MaBN.Text = dr.Cells["MaBN1"].Value.ToString();
            dtp_NgayKham.Text = dr.Cells["NgayKham1"].Value.ToString();
            txb_TrieuChung.Text = dr.Cells["TrieuChung1"].Value.ToString();
            txb_KetQua.Text = dr.Cells["KetQua1"].Value.ToString();
            
        }

        // them phieu kham
        private void button1_Click(object sender, EventArgs e)
        {
            PHIEUKHAM bnDTO = new PHIEUKHAM();
            bnDTO.MaPK1 = txb_MaPK.Text;
            // MaBS sử dụng combobox
            bnDTO.MaBS1 = comboBox_MaBS.SelectedValue.ToString();
            // ma benh nhan lay tu form themthongtinbenhnhan
            bnDTO.MaBN1 = txb_MaBN.Text;
            bnDTO.NgayKham1 = DateTime.Parse(dtp_NgayKham.Text);
            bnDTO.TrieuChung1 = txb_TrieuChung.Text;
            bnDTO.KetQua1 = txb_KetQua.Text;

            // goi lop nghiep vu PHIEUKHAM_BUS
            if (LapPhieuKB_BUS.ThemPhieuKham(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();
                string x = bnDTO.MaPK1 = txb_MaPK.Text;
                MessageBox.Show("Bạn vừa thêm phiếu khám " +x+" thành công!" , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TaiDuLieuVaoDataGirdView();
                return;
            }
            MessageBox.Show("Không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

     
        // sua phieu kham
        private void button1_Click_1(object sender, EventArgs e)
        {
            PHIEUKHAM bnDTO = new PHIEUKHAM();
            bnDTO.MaPK1 = txb_MaPK.Text;
            // MaBS sử dụng combobox
            bnDTO.MaBS1 = comboBox_MaBS.SelectedValue.ToString();
            // ma benh nhan lay tu form themthongtinbenhnhan
            bnDTO.MaBN1 = txb_MaBN.Text;
            bnDTO.NgayKham1 = DateTime.Parse(dtp_NgayKham.Text);
            bnDTO.TrieuChung1 = txb_TrieuChung.Text;
            bnDTO.KetQua1 = txb_KetQua.Text;

            // goi lop nghiep vu PHIEUKHAM_BUS
            if (LapPhieuKB_BUS.SuaPhieuKham(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TaiDuLieuVaoDataGirdView();
                return;
            }
            MessageBox.Show("Không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txb_MaPK.Text == "")
            {
                MessageBox.Show("Hãy chọn phiếu khám cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            CTTT_GUI x = new CTTT_GUI(txb_MaPK.Text);
    
            x.ShowDialog();
            x.Hide();
            
            //if (txb_MaPK.Text == "")
            //{
            //    MessageBox.Show("Hãy chọn phiếu khám cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}
            PHIEUKHAM bnDTO = new PHIEUKHAM();
            bnDTO.MaPK1 = txb_MaPK.Text;
            if (LapPhieuKB_BUS.XoaPhieuKham(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Show();            

        }
    }
}
