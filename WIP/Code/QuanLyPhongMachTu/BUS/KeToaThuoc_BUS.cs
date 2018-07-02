using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
   public class KeToaThuoc_BUS
    {
        public static List<CTTT> LoadCTTT(int MaPK)
        {
            return KeToaThuoc_DAO.LoadCTTT(MaPK);
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
