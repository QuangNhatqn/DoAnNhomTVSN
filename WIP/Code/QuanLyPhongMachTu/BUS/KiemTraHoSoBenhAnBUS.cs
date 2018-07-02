using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KiemTraHoSoBenhAnBUS
    {
        private KiemTraHoSoBenhAnDAO KtDao;
        public KiemTraHoSoBenhAnBUS()
        {
            KtDao = new KiemTraHoSoBenhAnDAO();
        }
        public List<KiemTraHoSoBenhAnDTO> XuatLichSuKham(KiemTraHoSoBenhAnDTO a)
        {
            return KtDao.XuatLichSuKham(a);
        }
        public KiemTraHoSoBenhAnDTO XuatCTPK(KiemTraHoSoBenhAnDTO a)
        {
            return KtDao.XuatCTPK(a);
        }
        public List<KiemTraHoSoBenhAnDTO> XuatCTTT(KiemTraHoSoBenhAnDTO a)
        {
            return KtDao.XuatCTTT(a);
        }
    }
}
