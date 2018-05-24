using BUS;
using DTO;
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
    public partial class QuanLyThuoc : Form
    {
        public QuanLyThuoc()
        {
            InitializeComponent();
        }

        private object DataGirdViewRow;

        private void dgv_Thuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuanLyThuoc_Load(object sender, EventArgs e)
        {
            TaiDuLieuVaoDataGirdView();
        }

        public void TaiDuLieuVaoDataGirdView()
        {
            List<THUOC> dsBN = THUOC_BUS.LoadTHUOC();

            dgv_Thuoc.DataSource = dsBN;

        }
        // THEM THUOC
        private void button3_Click(object sender, EventArgs e)
        {
            THUOC bnDTO = new THUOC();
          
            bnDTO.TenThuoc1 = txb_TenThuoc.Text;
           
            bnDTO.Gia1 =float.Parse( txb_Gia.Text);

            cbb_DVT.ValueMember = "DonViTinh1";

            bnDTO.DonViTinh1 = cbb_DVT.SelectedItem.ToString();
            

            // goi lop nghiep vu BENHNHAN_BUS
            if (THUOC_BUS.ThemThuoc(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TaiDuLieuVaoDataGirdView();
                return;
            }
            MessageBox.Show("Không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        // Đưa dữ liệu lên datagridview
        private void dgv_Thuoc_Click(object sender, EventArgs e)
        {
            if (dgv_Thuoc.SelectedRows.Count < 0)
            {
                return;
            }
            DataGridViewRow dr = dgv_Thuoc.SelectedRows[0];

            txb_MaThuoc.Text = dr.Cells["Mathuoc1"].Value.ToString();
            txb_TenThuoc.Text = dr.Cells["TenThuoc1"].Value.ToString();

            txb_Gia.Text = dr.Cells["Gia1"].Value.ToString();
            cbb_DVT.Text = dr.Cells["DonViTinh1"].Value.ToString();
           
        }
        // sua thuoc
        private void button1_Click(object sender, EventArgs e)
        {
            if (txb_MaThuoc.Text == "" || (txb_MaThuoc.Text).Length > 5)
            {
                MessageBox.Show("CHON THUỐC CẦN SỬA!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            // khoi tao doi tuong DTO
            THUOC bnDTO = new THUOC();
            bnDTO.Mathuoc1 = int.Parse(txb_MaThuoc.Text);

            bnDTO.TenThuoc1 = txb_TenThuoc.Text;

            bnDTO.Gia1 = float.Parse(txb_Gia.Text);

            bnDTO.DonViTinh1 = cbb_DVT.SelectedItem.ToString();
            // goi lop nghiep vu BENHNHAN_BUS
            if (THUOC_BUS.SuaTHUOC(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txb_MaThuoc.Text == "")
            {
                MessageBox.Show("Hãy chọn THUỐC cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            THUOC bnDTO = new THUOC();

            bnDTO.Mathuoc1 = int.Parse(txb_MaThuoc.Text);

            if (THUOC_BUS.XoaTHUOC(bnDTO) == true)
            {
                TaiDuLieuVaoDataGirdView();

                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            MessageBox.Show(" Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void QuanLyThuoc_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
