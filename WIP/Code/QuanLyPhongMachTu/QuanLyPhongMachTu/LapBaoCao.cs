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
    public partial class LapBaoCao : Form
    {
        public LapBaoCao()
        {
            InitializeComponent();
        }

        DataView dv;
        private void LapBaoCao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLKBDataSet.BAOCAO' table. You can move, or remove it, as needed.
            this.BAOCAOTableAdapter.Fill(this.QLKBDataSet.BAOCAO);

            //this.reportViewer1.RefreshReport();
            dv = new DataView(this.QLKBDataSet.BAOCAO);
            this.BAOCAOBindingSource.DataSource = dv;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("thang = '" + txtThang.Text + "' and nam = '" + txtNam.Text + "'");
            this.reportViewer1.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form_Chinh f = new Form_Chinh();
            this.Hide();
            f.ShowDialog();
        }

        private void LapBaoCao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát!", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                this.Hide();
                Form_Chinh f = new Form_Chinh();
                f.ShowDialog();
            }
        }
    }
}
