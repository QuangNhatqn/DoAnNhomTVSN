
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace DAO
{
    public class BACSI_DAO
    {
        private static BACSI_DAO instance;

        private BACSI_DAO() { }

        public static BACSI_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BACSI_DAO();
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
        static SqlConnection Con;
        public  List<BACSI> LoadBacSi()
        {
            
            // khai bao truy van sql
            string sTruyVan = "select * from BACSI";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List PHIEUKHAM_DTO
            List<BACSI> listbs = new List<BACSI>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                BACSI bs = new BACSI();
                bs.MaBS1 = dt.Rows[i]["MaBS"].ToString();
                bs.TenBS1 = dt.Rows[i]["TenBS"].ToString();
                bs.TenDangNhap1 = dt.Rows[i]["TenDangNhap"].ToString();
                bs.Matkhau = dt.Rows[i]["MatKhau"].ToString();

                listbs.Add(bs);
            }
            DataProvider_1.DongKetNoi(Con);
            return listbs;
        }

        public BACSI GetAccountByUserName(string userName)                   
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from BACSI where TenDangNhap = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new BACSI(item);
            }

            return null;
        }
        // chinh sua thong tin bác sĩ
        public bool CapNhatThongTin(string ma, string ten,string tendangnhap,string matkhau, string matkhaumoi)
        {
            int data = DataProvider.Instance.ExecuteNonQuery("exec USP_ChinhSuaThongTinBACSI @MaBS , @HoTen , @TenDangNhap , @MatKhau , @MKMoi ", new object[] { ma, ten, tendangnhap, matkhau, matkhaumoi});

            return data > 0;
        }
}
}
