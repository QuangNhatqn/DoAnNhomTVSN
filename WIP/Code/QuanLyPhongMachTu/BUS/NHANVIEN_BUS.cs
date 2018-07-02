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
  public  class NHANVIEN_BUS
    {
        private static NHANVIEN_BUS instance;

        private NHANVIEN_BUS() { }

        public static NHANVIEN_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NHANVIEN_BUS();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

       public bool LoginBUS(string TenDangNhap, string MatKhau)
        {

            return NHANVIEN_DAO.Instance.DangNhap(TenDangNhap, MatKhau);

        }

        public static List<NHANVIEN> LoadNHANVIEN()
         {
            return NHANVIEN_DAO.Instance.LoadNHANVIEN();
         }

        public static List<NHANVIEN> LoadNHANVIENThamGiaKhamBenh()
        {
            return NHANVIEN_DAO.Instance.LoadNHANVIENThamGiaKhamBenh();
        }
        
        public static List<NHANVIEN> LoadNHANVIENCanTim(int Ma)
        {
            return NHANVIEN_DAO.Instance.LoadNHANVIENCanTim(Ma);
        }
        public NHANVIEN LayThongTinNHANVIEN(int MaNV)
        { 
            return NHANVIEN_DAO.Instance.LayThongTinNhanVien(MaNV);

        }
        public NHANVIEN GetAccountByUserName(string userName)
        {
            return NHANVIEN_DAO.Instance.GetAccountByUserName(userName);

        }

        public bool CapNhatThongTin(int ma, string ten, string tendangnhap, string matkhau, string matkhaumoi)
        {

            return NHANVIEN_DAO.Instance.CapNhatThongTin(ma, ten, tendangnhap, matkhau, matkhaumoi);
        }

    }
}
