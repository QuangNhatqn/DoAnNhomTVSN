using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;

namespace BUS
{
   public class Them_Sua_Xoa_ThongTinBenhNhanBUS
    {
        private static Them_Sua_Xoa_ThongTinBenhNhanBUS instance;

        private Them_Sua_Xoa_ThongTinBenhNhanBUS() { }

        public static Them_Sua_Xoa_ThongTinBenhNhanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new Them_Sua_Xoa_ThongTinBenhNhanBUS();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public void Xem(DataGridView data)
        {
            data.DataSource = Them_Xoa_Sua_Thong_Tin_Benh_Nhan_DAO.Instance.Xem();
        }
       
    }
}
