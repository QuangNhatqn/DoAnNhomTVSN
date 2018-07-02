using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class GhiKQVaoPKBUS
    {
        private GhiKQVaoPKDAO gkqDao;

        public GhiKQVaoPKBUS()
        {
            gkqDao = new GhiKQVaoPKDAO();
        }
        public bool KtMaPK(GhiKQVaoPKDTO a)
        {
            return gkqDao.KtMaPK(a);
        }

        public bool updateKetQua(GhiKQVaoPKDTO a)
        {
            return gkqDao.updateKetQua(a);
        }

        public List<GhiKQVaoPKDTO> loadTenThuoc()
        {
            return gkqDao.loadTenThuoc();
        }

        ///////////////////

        public static List<GhiKQVaoPKDTO> LoadCTTT(GhiKQVaoPKDTO a)
        {
            return GhiKQVaoPKDAO.LoadCTTT(a);
        }
        // Thêm Thuốc
        public static bool ThemCTTT(GhiKQVaoPKDTO gkqDTO)
        {
            return GhiKQVaoPKDAO.ThemCTTT(gkqDTO);

        }
        public static bool SuaCTTT(GhiKQVaoPKDTO LayDTO, GhiKQVaoPKDTO SuaDTO)
        {
            return GhiKQVaoPKDAO.SuaCTTT(LayDTO, SuaDTO);
        }

        public static bool SuaCTTTDaTonTai(GhiKQVaoPKDTO SuaDTO)
        {
            return GhiKQVaoPKDAO.SuaCTTTDaTonTai(SuaDTO);
        }

        public GhiKQVaoPKDTO LayGiaThuoc(GhiKQVaoPKDTO a)
        {
            return gkqDao.LayGiaThuoc(a);
        }
        public static bool XoaCTTT(GhiKQVaoPKDTO a)
        {
            return GhiKQVaoPKDAO.XoaCTTT(a);
        }
        public KiemTraHoSoBenhAnDTO XuatCTPK(KiemTraHoSoBenhAnDTO a)
        {
            return gkqDao.XuatCTPK(a);
        }
    }
}
