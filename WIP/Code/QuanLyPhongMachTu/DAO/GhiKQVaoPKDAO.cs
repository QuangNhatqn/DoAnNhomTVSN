using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class GhiKQVaoPKDAO
    {
        private string connectionString;
        public GhiKQVaoPKDAO()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }
        //public GhiKQVaoPKDAO()
        //{
        //    //connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        //    //connectionString = @"Data Source=DESKTOP-39B6H1E\SQLEXPRESS;Initial Catalog=QLKB1;Integrated Security=True";
        //    //ConfigurationManager.AppSettings["ConnectionString"];
        //    connectionString = @"Data Source=DESKTOP-HLJNT2J\SQLEXPRESS;Initial Catalog=QLKB;Integrated Security=True";
        //}

        //public string ConnectionString
        //{
        //    get
        //    {
        //        return connectionString;
        //    }

        //    set
        //    {
        //        connectionString = value;
        //    }
        //}
        // Kiểm tra mã phiếu khám có tồn tại hay không.

        public bool KtMaPK(GhiKQVaoPKDTO a)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();


            string query = "select MaPK from PHIEUKHAM where MaPK = '" + a.Mapk + "' and TrangThai = '1'";

            DataTable dt = DataProvider.LoadTable(query, connection);

            if (dt.Rows.Count == 1)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        // Cập nhật kết quả vào phiếu khám.
        public bool updateKetQua(GhiKQVaoPKDTO a)
        {

            string query = "update PHIEUKHAM set KetQua = N'" + a.Ketqua + "' where MaPK ='" + a.Mapk + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();


            try
            {
                if (DataProvider.ThucThiNonQuery(query, connection) == true)
                {
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
            return false;
        }


        public List<GhiKQVaoPKDTO> loadTenThuoc()
        {

            string query = "select TenThuoc from THUOC";

            SqlConnection connection = new SqlConnection(connectionString);

            List<GhiKQVaoPKDTO> lstDto = new List<GhiKQVaoPKDTO>();
            connection.Open();

            DataTable dt = DataProvider.LoadTable(query, connection);

            if (dt.Rows.Count == 0)
            {
                connection.Close();
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GhiKQVaoPKDTO dto = new GhiKQVaoPKDTO();
                dto.Tenthuoc = dt.Rows[i]["TenThuoc"].ToString();
                lstDto.Add(dto);
            }
            connection.Close();
            return lstDto;
        }
        /////////////////////////////////////////

        static SqlConnection Con;
        // Load CTTT

        public static List<GhiKQVaoPKDTO> LoadCTTT(GhiKQVaoPKDTO a)
        {
            // Khai báo truy vấn SQL

            string sTruyVan = " select CTTT.TenThuoc, CTTT.SoLuong, THUOC.DonViTinh, CTTT.CachDung from CTTT, THUOC where CTTT.TenThuoc = THUOC.TenThuoc and CTTT.TrangThai = '1' and CTTT.MaPK = '" + a.Mapk + "'";
            // Mo Kết Nối
            Con = DataProvider.KetNoi();
            // Tiến Hành Truy Vấn

            DataTable dt = DataProvider.LoadTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            //tạo list GhiKetQuaVaoPhieuKham_DTO
            List<GhiKQVaoPKDTO> listgkqdto = new List<GhiKQVaoPKDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GhiKQVaoPKDTO dto = new GhiKQVaoPKDTO();
                dto.Tenthuoc = dt.Rows[i]["TenThuoc"].ToString();
                dto.Soluong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                dto.Donvitinh = dt.Rows[i]["DonViTinh"].ToString();
                dto.Cachdung = dt.Rows[i]["CachDung"].ToString();
                listgkqdto.Add(dto);
            }
            DataProvider.DongKetNoi(Con);
            return listgkqdto;
        }

        // Them CTTT
        public static bool ThemCTTT(GhiKQVaoPKDTO gkqDTO)
        {
            //string sTruyVan = string.Format("insert into CTTT values (N'{0}',N'{1}','{2}','{3}', '1')", gkqDTO.Mapk, gkqDTO.Tenthuoc, gkqDTO.Soluong, gkqDTO.Cachdung, gkqDTO.Trangthai);
            string sTruyVan = string.Format("INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)	 VALUES('{0}',N'{1}','{2}','{3}', N'{4}', '1')", gkqDTO.Mapk, gkqDTO.Tenthuoc, gkqDTO.Soluong, gkqDTO.Dongia, gkqDTO.Cachdung, gkqDTO.Trangthai);
            Con = DataProvider.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider.ThucThiNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider.DongKetNoi(Con);
                return false;
            }
        }
        public GhiKQVaoPKDTO LayGiaThuoc(GhiKQVaoPKDTO a)
        {
            string sTruyVan = " select Gia from THUOC where TenThuoc = N'" + a.Tenthuoc + "'";
            // Mo Kết Nối
            Con = DataProvider.KetNoi();
            // Tiến Hành Truy Vấn

            DataTable dt = DataProvider.LoadTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            if (dt.Rows.Count == 1)
            {
                GhiKQVaoPKDTO gkqdto = new GhiKQVaoPKDTO();
                gkqdto.Gia = float.Parse(dt.Rows[0]["Gia"].ToString());
                DataProvider.DongKetNoi(Con);
                return gkqdto;
            }
            else
            {
                DataProvider.DongKetNoi(Con);
                return null;
            }
        }
        public static bool SuaCTTT(GhiKQVaoPKDTO LayDTO, GhiKQVaoPKDTO SuaDTO)
        {
            string sTruyVan = string.Format("update CTTT set TenThuoc= N'{0}', SoLuong='{1}', DonGia ={2},  CachDung=N'{3}' where MaPK='{4}' and TenThuoc=N'{5}' ", SuaDTO.Tenthuoc, SuaDTO.Soluong, SuaDTO.Dongia, SuaDTO.Cachdung, LayDTO.Mapk, LayDTO.Tenthuoc);
            Con = DataProvider.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider.ThucThiNonQuery(sTruyVan, Con);
                // dong truy van
                DataProvider.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider.DongKetNoi(Con);
                return false;
            }
        }

        public static bool SuaCTTTDaTonTai(GhiKQVaoPKDTO SuaDTO)
        {
            string sTruyVan = string.Format("update CTTT set TenThuoc= N'{0}', SoLuong='{1}', DonGia ={2},  CachDung=N'{3}', TrangThai = '1' where MaPK='{4}' and TenThuoc=N'{5}' ", SuaDTO.Tenthuoc, SuaDTO.Soluong, SuaDTO.Dongia, SuaDTO.Cachdung, SuaDTO.Mapk, SuaDTO.Tenthuoc);
            Con = DataProvider.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider.ThucThiNonQuery(sTruyVan, Con);
                // dong truy van
                DataProvider.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider.DongKetNoi(Con);
                return false;
            }
        }

        public static bool XoaCTTT(GhiKQVaoPKDTO a)
        {
            string sTruyVan = string.Format("update CTTT set TrangThai = '0' where MaPK='{0}' and TenThuoc=N'{1}' ", a.Mapk, a.Tenthuoc);
            Con = DataProvider.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider.ThucThiNonQuery(sTruyVan, Con);
                // dong truy van
                DataProvider.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider.DongKetNoi(Con);
                return false;
            }
        }
        public KiemTraHoSoBenhAnDTO XuatCTPK(KiemTraHoSoBenhAnDTO a)
        {
            string query = "select PHIEUKHAM.NgayKham, BENHNHAN.TenBN, BENHNHAN.NgaySinh, BENHNHAN.GioiTinh, NHANVIEN.TenNV, PHIEUKHAM.TrieuChung, PHIEUKHAM.KetQua from PHIEUKHAM, BENHNHAN, NHANVIEN where PHIEUKHAM.MaBN = BENHNHAN.MaBN and PHIEUKHAM.MaNV = NHANVIEN.MaNV and PHIEUKHAM.MaPK = '" + a.Mapk + "'";
            KiemTraHoSoBenhAnDTO dto = new KiemTraHoSoBenhAnDTO();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            DataTable dt = DataProvider.LoadTable(query, connection);
            if (dt.Rows.Count == 0)
                return null;
            dto.Ngaykham = DateTime.Parse(dt.Rows[0]["NgayKham"].ToString());
            dto.Tenbn = dt.Rows[0]["TenBN"].ToString();
            dto.Ngaysinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            dto.Gioitinh = dt.Rows[0]["GioiTinh"].ToString();
            dto.Bacsi = dt.Rows[0]["TenNV"].ToString();
            dto.Trieuchung = dt.Rows[0]["TrieuChung"].ToString();
            dto.Chuandoan = dt.Rows[0]["KetQua"].ToString();
            connection.Close();
            return dto;
        }
    }
}
