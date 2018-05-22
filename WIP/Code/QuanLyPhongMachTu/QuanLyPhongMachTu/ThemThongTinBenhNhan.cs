
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Text.RegularExpressions;
using System.Data;

namespace QuanLyPhongMachTu
{
    public partial class ThemThongTinBenhNhan : Form
    {

        
        private object DataGirdViewRow;

        public ThemThongTinBenhNhan()
        {
            InitializeComponent();
           
        }
        private void ThemThongTinBenhNhan_Load(object sender, EventArgs e)
        {
            TaiDuLieuVaoDataGirdView();
            TaoBang();
        }
        public void TaiDuLieuVaoDataGirdView()
        {
            List<BENHNHAN> dsBN = BenhNhanBUS.LoadBenhNhan();
        
            dgv_ThongTinBenhNhan.DataSource = dsBN;

        }


        private void button_Them_Click(object sender, EventArgs e)
        {
            // kiem tra du lieu dau vao
            if (txb_MaBN.Text == "" || (txb_MaBN.Text).Length > 5)
            {
                MessageBox.Show("Mã bệnh nhân không được trống và không quá 5 ký tự. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsNumber(txb_DienThoai.Text)== false || txb_DienThoai.Text =="")
            {
                MessageBox.Show("Số điện thoại không đúng. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txb_HoTen.Text == "" )
            {
                MessageBox.Show(" Vui lòng nhập tên bệnh nhân lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txb_HoTen.Text == "")
            {
                MessageBox.Show(". Vui lòng nhập tên bệnh nhân lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // khoi tao doi tuong DTO
            BENHNHAN bnDTO = new BENHNHAN();
            bnDTO.MaBN1 = txb_MaBN.Text;
            bnDTO.TenBN1 = txb_HoTen.Text;
            bnDTO.NgaySinh1 = DateTime.Parse(  dtp_NgaySinh.Text);
            bnDTO.DiaChi1 = txb_DiaChi.Text;
            bnDTO.DienThoai1 = txb_DienThoai.Text.ToString();
            //bnDTO.GioiTinh1=
            if(rdb_Nam.Checked == true)
            {
                bnDTO.GioiTinh1 = "Nam";
            }
            else
            {
                bnDTO.GioiTinh1 = "Nữ";
            }


            // goi lop nghiep vu BENHNHAN_BUS
            if(BenhNhanBUS.ThemBenhNhan(bnDTO)==true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // TaiDuLieuVaoDataGirdView();
                return;
            }
            MessageBox.Show("Không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
       

        }

        private static bool IsNumber(string val)
        {
            if (val != "")
                return Regex.IsMatch(val, @"^[0-9]\d*\.?[0]*$");
            else return true;
        }
        // Sua Benh Nhan
        private void button5_Click(object sender, EventArgs e)
        {
            // kiem tra du lieu dau vao
            if (txb_MaBN.Text == "" || (txb_MaBN.Text).Length > 5)
            {
                MessageBox.Show("Mã bệnh nhân không được trống và không quá 5 ký tự. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsNumber(txb_DienThoai.Text) == false || txb_DienThoai.Text == "")
            {
                MessageBox.Show("Số điện thoại không đúng. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txb_HoTen.Text == "")
            {
                MessageBox.Show(" Vui lòng nhập tên bệnh nhân lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txb_HoTen.Text == "")
            {
                MessageBox.Show(". Vui lòng nhập tên bệnh nhân lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // khoi tao doi tuong DTO
            BENHNHAN bnDTO = new BENHNHAN();
            bnDTO.MaBN1 = txb_MaBN.Text;
            bnDTO.TenBN1 = txb_HoTen.Text;
            bnDTO.NgaySinh1 = DateTime.Parse(dtp_NgaySinh.Text);
            bnDTO.DiaChi1 = txb_DiaChi.Text;
            bnDTO.DienThoai1 = txb_DienThoai.Text.ToString();
            //bnDTO.GioiTinh1=
            if (rdb_Nam.Checked == true)
            {
                bnDTO.GioiTinh1 = "Nam";
            }
            else
            {
                bnDTO.GioiTinh1 = "Nữ";
            }
            // goi lop nghiep vu BENHNHAN_BUS
            if (BenhNhanBUS.SuaBenhNhan(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                return;
            }
            MessageBox.Show(" Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgv_ThongTinBenhNhan_Click(object sender, EventArgs e)
        {
            // dua du lieu tu DataGirdView len textbox, combobox,..
            if (dgv_ThongTinBenhNhan.SelectedRows.Count < 0)
            {
                return;
            }
            DataGridViewRow dr = dgv_ThongTinBenhNhan.SelectedRows[0];
            
            txb_MaBN.Text = dr.Cells["MaBN1"].Value.ToString();
            txb_HoTen.Text = dr.Cells["TenBN1"].Value.ToString();
            //ngay sinh
            dtp_NgaySinh.Text = dr.Cells["NgaySinh1"].Value.ToString();
            txb_DiaChi.Text = dr.Cells["DiaChi1"].Value.ToString();
            txb_DienThoai.Text = dr.Cells["DienThoai1"].Value.ToString();
            if (dr.Cells["GioiTinh1"].Value.ToString() == "Nam")
            {
                rdb_Nam.Checked = true;
            }
            else
            {
                rdb_Nu.Checked = true;
            }
        }
        // xoa benh nhan
        private void button1_Click(object sender, EventArgs e)
        {
            if(txb_MaBN.Text == "")
            {
                MessageBox.Show("Hãy chọn bệnh nhân cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            BENHNHAN bnDTO = new BENHNHAN();
            bnDTO.MaBN1 = txb_MaBN.Text;
            if (BenhNhanBUS.XoaBenhNhan(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // nut Lap phiếu khám bệnh
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dlr == DialogResult.Yes)
            {
                Form_Chinh x = new Form_Chinh();

                this.Hide();

                x.ShowDialog();
            }



            //if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            //{

            //    e.Cancel = true;

            //}
            //else
            //{

            //    Form_Chinh x = new Form_Chinh();
            //    this.Hide();
            //    x.ShowDialog();
            //}

        }

        private void ThemThongTinBenhNhan_FormClosing(object sender, FormClosingEventArgs e)
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
        // nhan nut lap phieu kham benh, goi form LapPhieuKham
        private void button4_Click(object sender, EventArgs e)
        {
            LapPhieuKhamBenh_GUI x = new LapPhieuKhamBenh_GUI(txb_MaBN.Text);
            this.Hide();
            x.ShowDialog();
        }
         
        void TaoBang()
        {
            
            BENHNHAN bnDTO = new BENHNHAN();
            bnDTO.MaBN1 = "BN007";
            DataTable dsBN = BenhNhanBUS.TaoBang(bnDTO);

            dgv_Test.DataSource = dsBN;

        }
        
    }
}
