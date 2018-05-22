using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;

namespace DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        private TaiKhoanDAO() { }

        public static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool DangNhap(string TenDangNhap, string MatKhau)
        {
            string query = " USP_DANGNHAP @TenDangNhap , @MatKhau";

            DataTable Result = DataProvider.Instance.ExecuteQuery(query, new object[] { TenDangNhap, MatKhau });
            return Result.Rows.Count > 0;

        }




    }
}
