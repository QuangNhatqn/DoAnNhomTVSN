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
  public  class BACSI_BUS
    {
        private static BACSI_BUS instance;

        private BACSI_BUS() { }

        public static BACSI_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new BACSI_BUS();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

       public bool LoginBUS(string TenDangNhap, string MatKhau)
        {

            //return DAO.TaiKhoanDAO.Instance.DangNhap(TenDangNhap,MatKhau);
            return TaiKhoanDAO.Instance.DangNhap(TenDangNhap, MatKhau);

        }

        public static List<BACSI> LoadBacSi()
         {
            return BACSI_DAO.Instance.LoadBacSi();
         }

        public BACSI GetAccountByUserName(string userName)
        {
            return BACSI_DAO.Instance.GetAccountByUserName(userName);

        }

        public bool CapNhatThongTin(string ma, string ten, string tendangnhap, string matkhau, string matkhaumoi)
        {

            return BACSI_DAO.Instance.CapNhatThongTin(ma, ten, tendangnhap, matkhau, matkhaumoi);
        }

        ////////////////////////
        // THEM - SUA - XOA
        public static DataTable BangKiemTraTonTai(BACSI bnDTO)
        {
            return BACSI_DAO.BangKiemTraTonTai(bnDTO);
        }
        public static bool KiemTraTonTai(BACSI bnDTO)
        {
            return BACSI_DAO.Instance.KiemTraTonTai( bnDTO);
        }
        public static bool ThemBacSi(BACSI bnDTO)
        {
            return BACSI_DAO.Instance.ThemBacSi(bnDTO);
        }
        public static bool SuaThongTinBacSi(BACSI bnDTO)
        {
            return BACSI_DAO.Instance.SuaBacSi(bnDTO);
        }

        public static bool XoaBacSi(BACSI bnDTO)
        {

            return BACSI_DAO.Instance.XoaBacSi(bnDTO);
        }


    }
}
