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
    public class NHANVIEN_DAO
    {

        private static NHANVIEN_DAO instance;

        private NHANVIEN_DAO() { }

        public static NHANVIEN_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NHANVIEN_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool DangNhap(string TenDangNhap, string MatKhau)
        {
            string query = "  USP_DieuKienDangNhap @TenDangNhap , @MatKhau";

            DataTable Result = DataProvider_0.Instance.ExecuteQuery(query, new object[] { TenDangNhap, MatKhau });
            return Result.Rows.Count > 0;

        }
        static SqlConnection Con;
        public List<NHANVIEN> LoadNHANVIEN()
        {
            // khai bao truy van sql
            string sTruyVan = "select * from NHANVIEN where TrangThai = '1'";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List PHIEUKHAM_DTO
            List<NHANVIEN> listNV = new List<NHANVIEN>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                NHANVIEN NV = new NHANVIEN();
                NV.MaNV1 = int.Parse(dt.Rows[i]["MaNV"].ToString());
                NV.TenNV1 = dt.Rows[i]["TenNV"].ToString();
                NV.TenDangNhap1 = dt.Rows[i]["TenDangNhap"].ToString();
                NV.Matkhau1 = dt.Rows[i]["MatKhau"].ToString();
                NV.LoaiNV1 =int.Parse( dt.Rows[i]["LoaiNV"].ToString());
                NV.TrangThai1 = int.Parse(dt.Rows[i]["TrangThai"].ToString());
                listNV.Add(NV);
            }
            DataProvider_1.DongKetNoi(Con);
            return listNV;
        }
        // bac sy tham gia kham benh

        public List<NHANVIEN> LoadNHANVIENThamGiaKhamBenh()
        {

            // khai bao truy van sql
            string sTruyVan = "select * from NHANVIEN where TrangThai = '1' and LoaiNV ='2'";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List PHIEUKHAM_DTO
            List<NHANVIEN> listNV = new List<NHANVIEN>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                NHANVIEN NV = new NHANVIEN();
                NV.MaNV1 = int.Parse(dt.Rows[i]["MaNV"].ToString());
                NV.TenNV1 = dt.Rows[i]["TenNV"].ToString();
                NV.TenDangNhap1 = dt.Rows[i]["TenDangNhap"].ToString();
                NV.Matkhau1 = dt.Rows[i]["MatKhau"].ToString();
                NV.LoaiNV1 = int.Parse(dt.Rows[i]["LoaiNV"].ToString());
                NV.TrangThai1 = int.Parse(dt.Rows[i]["TrangThai"].ToString());
                listNV.Add(NV);
            }
            DataProvider_1.DongKetNoi(Con);
            return listNV;
        }

        public List<NHANVIEN> LoadNHANVIENCanTim(int Ma)
        {

            // khai bao truy van sql,  String sTruyVan = string.Format("delete from PHIEUKHAM where MaPK ='{0}'", x);
            string sTruyVan = string.Format("select * from NHANVIEN where MaNV = {0} and (TrangThai = '1' and LoaiNV ='2') ", Ma);
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List PHIEUKHAM_DTO
            List<NHANVIEN> listNV = new List<NHANVIEN>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                NHANVIEN NV = new NHANVIEN();
                NV.MaNV1 = int.Parse(dt.Rows[i]["MaNV"].ToString());
                NV.TenNV1 = dt.Rows[i]["TenNV"].ToString();
                NV.TenDangNhap1 = dt.Rows[i]["TenDangNhap"].ToString();
                NV.Matkhau1 = dt.Rows[i]["MatKhau"].ToString();
                NV.LoaiNV1 = int.Parse(dt.Rows[i]["LoaiNV"].ToString());
                NV.TrangThai1 = int.Parse(dt.Rows[i]["TrangThai"].ToString());
                listNV.Add(NV);
            }
            DataProvider_1.DongKetNoi(Con);
            return listNV;
        }

        public NHANVIEN LayThongTinNhanVien(int MaNV)
        {
            DataTable data = DataProvider_0.Instance.ExecuteQuery("Select * from NHANVIEN where MaNV = 'MaNV')");
            int i = 0;
            for (i = 0; i < data.Rows.Count; ++ i)

            {
                NHANVIEN NV = new NHANVIEN();
                NV.MaNV1 = int.Parse(data.Rows[i]["MaNV"].ToString());
                NV.TenNV1 = data.Rows[i]["TenNV"].ToString();
                NV.TenDangNhap1 = data.Rows[i]["TenDangNhap"].ToString();
                NV.LoaiNV1 = int.Parse(data.Rows[i]["LoaiNV"].ToString());
                NV.TrangThai1 = int.Parse(data.Rows[i]["TrangThai"].ToString());
                return NV;
            }

            return null;
        }
        public NHANVIEN GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider_0.Instance.ExecuteQuery("Select * from NHANVIEN where TenDangNhap = '" + userName + "'");
            
            for(int i=0; i< data.Rows.Count ; i++)

            {
                NHANVIEN NV = new NHANVIEN();
                NV.MaNV1 = int.Parse( data.Rows[i]["MaNV"].ToString());
                NV.TenNV1 = data.Rows[i]["TenNV"].ToString();
                NV.TenDangNhap1 = data.Rows[i]["TenDangNhap"].ToString();
                NV.LoaiNV1 = int.Parse(data.Rows[i]["LoaiNV"].ToString());
                NV.TrangThai1 = int.Parse(data.Rows[i]["TrangThai"].ToString());
                return NV;
            }

            return null;
        }
        // chinh sua thong tin nhân viên
        public bool CapNhatThongTin(int ma, string ten, string tendangnhap, string matkhau, string matkhaumoi)
        {
            int data = DataProvider_0.Instance.ExecuteNonQuery("exec USP_CapNhatThongTinNhanVien @MaNV , @HoTen , @TenDangNhap , @MatKhau , @MKMoi ", new object[] { ma, ten, tendangnhap, matkhau, matkhaumoi });

            return data > 0;
        }

    }
}