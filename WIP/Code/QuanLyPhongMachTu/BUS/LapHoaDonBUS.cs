using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LapHoaDonBUS
    {

        private LapHoaDonDAO lhdDao;
        public LapHoaDonBUS()
        {
            lhdDao = new LapHoaDonDAO();
        }

        public List<LapHoaDonDTO> LoadMaPK()
        {
            return lhdDao.loadMaPK();
        }
        public List<LapHoaDonDTO> loadHoaDon()
        {
            return lhdDao.loadHoaDon();
        }

        public bool xoa(LapHoaDonDTO a)
        {
            return lhdDao.xoa(a);
        }

        public LapHoaDonDTO loadThongTin(LapHoaDonDTO a)
        {
            return lhdDao.loadThongTin(a);
        }
        public List<LapHoaDonDTO> loadCTTT(LapHoaDonDTO a)
        {
            return lhdDao.loadCTTT(a);
        }
        public LapHoaDonDTO KtMaPK(LapHoaDonDTO a)
        {
            return lhdDao.KtMaPK(a);
        }
        public LapHoaDonDTO TinhTienThuoc(LapHoaDonDTO a)
        {
            return lhdDao.TinhTienThuoc(a);
        }
        public bool luu(LapHoaDonDTO a)
        {
            return lhdDao.luu(a);
        }
        public LapHoaDonDTO LayMaHD()
        {
            return lhdDao.LayMaHD();
        }

    }
}
