using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Windows.Forms;

namespace DAO
{
  public  class Them_Xoa_Sua_Thong_Tin_Benh_Nhan_DAO
    {
        public List<BENHNHAN> Xem()
        {
            List<BENHNHAN> benhnhan = new List<BENHNHAN>();

            string query = "select * from BENHNHAN";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataGridViewRow item in data.Rows)
            {
                int MaBN = (int)item.Cells["MaBN"].Value;
                string TenBN = item.Cells["TenBN"].Value.ToString();
                DateTime NgaySinh =(DateTime) item.Cells["NgaySinh"].Value;
                string DiaChi = item.Cells["DiaChi"].Value.ToString();
                string DienThoai = item.Cells["DienThoai"].Value.ToString();
                string GioiTinh = item.Cells["GioiTinh"].Value.ToString();

                BENHNHAN BnMoi = new BENHNHAN(MaBN,TenBN,NgaySinh,DiaChi,DienThoai,GioiTinh);

                benhnhan.Add(BnMoi);

            }
            return benhnhan;
        }
        private Them_Xoa_Sua_Thong_Tin_Benh_Nhan_DAO() { }

        private static Them_Xoa_Sua_Thong_Tin_Benh_Nhan_DAO instance;

        public static Them_Xoa_Sua_Thong_Tin_Benh_Nhan_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Them_Xoa_Sua_Thong_Tin_Benh_Nhan_DAO();
                return instance;
            }

        }
    }
}
