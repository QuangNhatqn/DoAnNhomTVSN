using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QuanLyThongTinNhanVien_BUS
    {
        public static List<NHANVIEN> LoadNhanVien()
        {
            return QuanLyThongTinNhanVien_DAO.Instance.LoadNHANVIEN();
        }

        ////////////////////////
        // THEM - SUA - XOA
        public static DataTable BangKiemTraTonTai(NHANVIEN bnDTO)
        {
            return QuanLyThongTinNhanVien_DAO.BangKiemTraTonTai(bnDTO);
        }
        public static bool KiemTraTonTai(NHANVIEN bnDTO)
        {
            return QuanLyThongTinNhanVien_DAO.Instance.KiemTraTonTai(bnDTO);
        }
        public static bool ThemNhanVien(NHANVIEN bnDTO)
        {
            return QuanLyThongTinNhanVien_DAO.Instance.ThemNHANVIEN(bnDTO);
        }
        public static bool SuaThongTinNhanVien(NHANVIEN bnDTO)
        {
            return QuanLyThongTinNhanVien_DAO.Instance.SuaNHANVIEN(bnDTO);
        }

        public static bool XoaNhanVien(NHANVIEN bnDTO)
        {

            return QuanLyThongTinNhanVien_DAO.Instance.XoaNHANVIEN(bnDTO);
        }

    }
}
