using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class THUOC_BUS
    {
        public static List<THUOC> LoadTHUOC()
        {
            return THUOC_DAO.LoadTHUOC();
        }

        //Them Hoc Sinh
        public static bool ThemThuoc(THUOC bnDTO)
        {
            return THUOC_DAO.ThemTHUOC(bnDTO);
        }
        public static bool SuaTHUOC(THUOC bnDTO)
        {
            return THUOC_DAO.SuaTHUOC(bnDTO);
        }

        public static bool XoaTHUOC(THUOC bnDTO)
        {
            return THUOC_DAO.XoaTHUOC(bnDTO);
        }

        public static bool KiemTraTonTai(THUOC Thuoc)
        {
            return THUOC_DAO.KiemTraTonTai(Thuoc);
        }
    }
}
