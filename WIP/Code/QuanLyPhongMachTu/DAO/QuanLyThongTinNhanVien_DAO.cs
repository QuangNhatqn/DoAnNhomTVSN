using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
  public  class QuanLyThongTinNhanVien_DAO
    {
        static SqlConnection Con;

        private static QuanLyThongTinNhanVien_DAO instance;

        private QuanLyThongTinNhanVien_DAO() { }

        public static QuanLyThongTinNhanVien_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuanLyThongTinNhanVien_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
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
                NV.LoaiNV1 = int.Parse(dt.Rows[i]["LoaiNV"].ToString());
                NV.TrangThai1 = int.Parse(dt.Rows[i]["TrangThai"].ToString());

                listNV.Add(NV);
            }
            DataProvider_1.DongKetNoi(Con);
            return listNV;
        }

        // them - sua - xoa table NHANVIEN

        public static DataTable BangKiemTraTonTai(NHANVIEN bnDTO)
        {
            // string sTruyVan = string.Format("SELECT MaBN from BENHNHAN WHERE (TenBN like N'{0}') and (NgaySinh = N'{1}' and (DienThoai = '{2}' and GioiTinh = N'{3}'))", bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DienThoai1, bnDTO.GioiTinh1); // MaBN tu dong tang
            string sTruyVan = string.Format("SELECT MaNV from NHANVIEN WHERE TenDangNhap =N'{0}' AND TrangThai = '1'", bnDTO.TenDangNhap1);
            try
            {   
                DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
                DataProvider_1.DongKetNoi(Con);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return null;
            }

        }
        public bool KiemTraTonTai(NHANVIEN bnDTO)
        {
            string sTruyVan = string.Format("SELECT MaNV from NHANVIEN WHERE TenDangNhap =N'{0}'  AND TrangThai = '1'", bnDTO.TenDangNhap1); // MaBN tu dong tang
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool kq = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider_1.DongKetNoi(Con);

                if (kq == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }


        }

        public bool ThemNHANVIEN(NHANVIEN bnDTO)
        {
            // tao cau truy van
            // string sTruyVan = @"insert into BENHNHAN(MaBN,TenBN) value"; -- them mot vai thanh phan vao bang
            /* string sTruyVan = string.Format("insert into BENHNHAN values ('{0}',N'{1}','{2}',N'{3}',{4},N'{5}')", bnDTO.MaBN1, bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DiaChi1, bnDTO.DienThoai1, bnDTO.GioiTinh1);*/// them day du thong tin cua bang
            string sTruyVan = string.Format("insert into NHANVIEN values (N'{0}', N'{1}', N'{2}', '{3}', '1')", bnDTO.TenNV1, bnDTO.TenDangNhap1, bnDTO.Matkhau1, bnDTO.LoaiNV1); // MaBN tu dong tang
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                bool kq = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider_1.DongKetNoi(Con);

                if (kq == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }

        }

        // sua benh nhan

        public bool SuaNHANVIEN(NHANVIEN bnDTO)
        {
            string sTruyVan = string.Format("update NHANVIEN set TenNV = N'{0}', TenDangNhap = N'{1}', MatKhau = N'{2}' , LoaiNV = '{3}'  where MaNV= N'{4}'", bnDTO.TenNV1, bnDTO.TenDangNhap1, bnDTO.Matkhau1, bnDTO.LoaiNV1, bnDTO.MaNV1);
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        // xoa benh nhan
        public DataTable TaoBang(NHANVIEN bnDTO)
        {
            

            string query = string.Format("SELECT MaPK from PHIEUKHAM, NHANVIEN WHERE NHANVIEN.MaNV = PHIEUKHAM.MaNV and TenDangNhap = N'{0}'", bnDTO.TenDangNhap1);
            Con = DataProvider_1.KetNoi();

            DataTable dt = DataProvider_1.LayDataTable(query, Con);

            DataProvider_1.DongKetNoi(Con);

            return dt;
        }

        public bool XoaCTTT(int x)
        {
            String sTruyVan = string.Format("update CTTT set TrangThai ='0'  where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        public bool XoaHoaDon(int x)
        {
            String sTruyVan = string.Format("update HOADON set TrangThai ='0' where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }



        public bool XoaPhieKham(int x)
        {
            String sTruyVan = string.Format("update PHIEUKHAM set TrangThai = '0' where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
        public void DuyetBang(DataTable dt)
        {

            if (dt.Rows.Count == 0)
                return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                int x = int.Parse(dt.Rows[i]["MaPK"].ToString());

                if (XoaCTTT(x) == true)
                {
                    if (XoaHoaDon(x) == true)
                    {
                        if (XoaPhieKham(x) == true)
                        {

                        }
                        else
                            return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                    return;

            }
        }

        public bool XoaNHANVIEN(NHANVIEN bnDTO)
        {
            DataTable dt = TaoBang(bnDTO);

    
            if (dt != null)
                DuyetBang(dt);

            
            string sTruyVan = string.Format("update NHANVIEN set TrangThai = '0'  where MaNV= N'{0}'", bnDTO.MaNV1);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
    }
}
