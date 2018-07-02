using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class BenhNhanBUS
    {
        public static List<BENHNHAN> LoadBenhNhan()
        {
            return BenhNhanDAO.LoadBenhNhan();
        }

      
        //Them Hoc Sinh
        public static bool ThemBenhNhan(BENHNHAN bnDTO)
        {
            return BenhNhanDAO.ThemBenhNhan(bnDTO);
        }
        public static bool SuaBenhNhan(BENHNHAN bnDTO)
        {
            return BenhNhanDAO.SuaBenhNhan(bnDTO);
        }

        public static bool XoaBenhNhan(BENHNHAN bnDTO)
        {
            //return XoaBenhNhan(bnDTO);
            return BenhNhanDAO.XoaBenhNhan(bnDTO);
        }
        public static bool XoaBenhNhanCu(BENHNHAN bnDTO)
        {
            //return XoaBenhNhan(bnDTO);
            return BenhNhanDAO.XoaBenhNhanCu(bnDTO);
        }

        public static DataTable TaoBang(BENHNHAN bnDTO)
        {
            return BenhNhanDAO.TaoBang(bnDTO);
        }

        public static bool KiemTraTonTai(BENHNHAN bnDTO)
        {
            return BenhNhanDAO.KiemTraTonTai(bnDTO);
        }

        public static DataTable BangKiemTraTonTai(BENHNHAN bnDTO)
        {
            return BenhNhanDAO.BangKiemTraTonTai(bnDTO);
        }
    }
}
