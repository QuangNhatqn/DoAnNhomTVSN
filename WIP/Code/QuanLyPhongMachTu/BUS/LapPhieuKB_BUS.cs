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
   public class LapPhieuKB_BUS
    {
        public static List<PHIEUKHAM> LoadPHIEUKHAM()
        {
            return LapPhieuKhamBenh_DAO.LoadPhieuKham();
        }

        public static bool ThemPhieuKham(PHIEUKHAM bnDTO)
        {
            return LapPhieuKhamBenh_DAO.ThemPHIEUKHAM(bnDTO);
        }

        public static bool SuaPhieuKham(PHIEUKHAM bnDTO)
        {
            return LapPhieuKhamBenh_DAO.SuaPHIEUKHAM(bnDTO);
        }

        public static bool XoaPhieuKham(PHIEUKHAM bnDTO)
        {
            return LapPhieuKhamBenh_DAO.XOAPHIEUKHAM(bnDTO);
        }

     

    }
}
