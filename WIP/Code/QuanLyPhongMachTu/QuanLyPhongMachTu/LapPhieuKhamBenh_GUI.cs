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
        private int MaBN;
        public LapPhieuKhamBenh_GUI(int mabn) : this()
        {
            MaBN = mabn;
            txb_MaBN.Text = MaBN.ToString();

        }
        //private object DataGirdViewRow;
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
            if(dsBN == null)
            {
                return;
            }
            dgv_PhieuKham.DataSource = dsBN;

            dgv_PhieuKham.Columns[0].HeaderText = "Mã Phiếu Khám";
            dgv_PhieuKham.Columns[1].HeaderText = "Mã Bác Sỹ";
            dgv_PhieuKham.Columns[2].HeaderText = "Mã Bệnh Nhân";
            dgv_PhieuKham.Columns[3].HeaderText = "Ngày Khám";
            dgv_PhieuKham.Columns[4].HeaderText = "Triệu Chứng";

            dgv_PhieuKham.Columns[5].Visible = false;
            dgv_PhieuKham.Columns[3].Width = 110;
            dgv_PhieuKham.Columns[4].Width = 300;

        }

        public void TaiDuLieuVaoCombobox()
        {
            List<NHANVIEN> dsBs = NHANVIEN_BUS.LoadNHANVIENThamGiaKhamBenh();
            comboBox_MaBS.DataSource = dsBs;
            comboBox_MaBS.DisplayMember = "TenNV1";//gia tri hien thi
            comboBox_MaBS.ValueMember = "MaNV1";//luu gia tri

            // dgv_PhieuKham.DataSource = dsBN;

        }

        public void DuaDuLieuTudgv_Combobox(int Ma)
        {

            List<NHANVIEN> dsBs = NHANVIEN_BUS.LoadNHANVIENCanTim(Ma);
            comboBox_MaBS.DataSource = dsBs;
            comboBox_MaBS.DisplayMember = "TenNV1";
            comboBox_MaBS.ValueMember = "MaNV1";

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

       

        // đưa dữ liệu lên textbox

        private void dgv_PhieuKham_Click_1(object sender, EventArgs e)
        {
            // dua du lieu tu DataGirdView len textbox, combobox,..

            try
            {
                DataGridViewRow dr = dgv_PhieuKham.SelectedRows[0];

                txb_MaPK.Text = dr.Cells["MaPK1"].Value.ToString();
                // ma bs
                //comboBox_MaBS.DisplayMember = dr.Cells["MaBS1"].Value.ToString();
                //xem lai
                //TaiDuLieuVaoCombobox();
                // DuaDuLieuTudgv_Combobox(int.Parse( dr.Cells["MaBS1"].Value.ToString()));

                txb_MaBN.Text = dr.Cells["MaBN1"].Value.ToString();
                dtp_NgayKham.Text = dr.Cells["NgayKham1"].Value.ToString();
                txb_TrieuChung.Text = dr.Cells["TrieuChung1"].Value.ToString();



                //txb_KetQua.Text = dr.Cells["KetQua1"].Value.ToString();
                // cbb_DVT.Text = dr.Cells["DonViTinh1"].Value.ToString();
                //comboBox_MaBS.Text = dr.Cells["MaNHANVIEN1"].Value.ToString();
            }
            catch { return; }
        }

        // them phieu kham
        private void button1_Click(object sender, EventArgs e)
        {
            PHIEUKHAM bnDTO = new PHIEUKHAM();
            //bnDTO.MaPK1 = txb_MaPK.Text;
            // MaBS sử dụng combobox
            bnDTO.MaNV1 = int.Parse(comboBox_MaBS.SelectedValue.ToString());
            // ma benh nhan lay tu form themthongtinbenhnhan
            if (txb_MaBN.Text == null || txb_MaBN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txb_TrieuChung.Text == null || txb_TrieuChung.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bnDTO.MaBN1 = int.Parse(txb_MaBN.Text);
            bnDTO.NgayKham1 = DateTime.Parse(dtp_NgayKham.Text);
            bnDTO.TrieuChung1 = txb_TrieuChung.Text;
            //bnDTO.KetQua1 = txb_KetQua.Text;

            // goi lop nghiep vu PHIEUKHAM_BUS
            if (LapPhieuKB_BUS.ThemPhieuKham(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                string x;

                int y = dgv_PhieuKham.Rows.Count;
                int q = y - 1;

                DataGridViewRow dr = dgv_PhieuKham.Rows[q];

                txb_MaPK.Text = dr.Cells["MaPK1"].Value.ToString();

                x = txb_MaPK.Text;

                //  x = dt.Rows[0][0].ToString();

                MessageBox.Show("Bạn vừa thêm phiếu khám với mã  " + x + "  thành công!" , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TaiDuLieuVaoDataGirdView();
                return;
            }
            MessageBox.Show("Không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

     
        // sua phieu kham
        private void button1_Click_1(object sender, EventArgs e)
        {
            PHIEUKHAM bnDTO = new PHIEUKHAM();
            bnDTO.MaPK1 = int.Parse(txb_MaPK.Text);
            
            // MaBS sử dụng combobox
            bnDTO.MaNV1 = int.Parse(comboBox_MaBS.SelectedValue.ToString());
            // ma benh nhan lay tu form themthongtinbenhnhan
            bnDTO.MaBN1 = int.Parse(txb_MaBN.Text);
            bnDTO.NgayKham1 = DateTime.Parse(dtp_NgayKham.Text);
            bnDTO.TrieuChung1 = txb_TrieuChung.Text;
            //bnDTO.KetQua1 = txb_KetQua.Text;

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
       
        //private void button2_Click_1(object sender, EventArgs e)
        //{
        //    if (txb_MaPK.Text == "")
        //    {
        //        MessageBox.Show("Hãy chọn phiếu khám cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return;
        //    }
        //    CTTT_GUI x = new CTTT_GUI(txb_MaPK.Text);
    
        //    x.ShowDialog();
        //    x.Hide();
            
        //    //if (txb_MaPK.Text == "")
        //    //{
        //    //    MessageBox.Show("Hãy chọn phiếu khám cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    //    return;
        //    //}
        //    PHIEUKHAM bnDTO = new PHIEUKHAM();
        //    bnDTO.MaPK1 = int.Parse(txb_MaPK.Text);
        //    if (LapPhieuKB_BUS.XoaPhieuKham(bnDTO) == true)
        //    {
        //        TaiDuLieuVaoDataGirdView();

        //        MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    this.Show();            

        //}

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (txb_MaPK.Text == "")
            {
                MessageBox.Show("Hãy chọn phiếu khám cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
           
            //if (txb_MaPK.Text == "")
            //{
            //    MessageBox.Show("Hãy chọn phiếu khám cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}
            PHIEUKHAM bnDTO = new PHIEUKHAM();
            bnDTO.MaPK1 = int.Parse(txb_MaPK.Text);
            
            // ma benh nhan lay tu form themthongtinbenhnhan
            bnDTO.MaBN1 = int.Parse(txb_MaBN.Text);
            bnDTO.NgayKham1 = DateTime.Parse(dtp_NgayKham.Text);
            bnDTO.TrieuChung1 = txb_TrieuChung.Text;

            if (LapPhieuKB_BUS.XoaPhieuKham(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Show();

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlr == DialogResult.Yes)
            {

                Form_Chinh x = new Form_Chinh();
                this.Hide();
                x.ShowDialog();
               
            }

        }

        private void button_KeToaThuoc_Click(object sender, EventArgs e)
        {
            frmGhiKetQuaVaoPK f = new frmGhiKetQuaVaoPK();
            this.Hide();
            f.ShowDialog();
        }
    }
}
