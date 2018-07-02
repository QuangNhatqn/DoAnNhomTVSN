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
    public class KiemTraHoSoBenhAnDAO
    {
        private string connectionString;
        public KiemTraHoSoBenhAnDAO()
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
        public List<KiemTraHoSoBenhAnDTO> XuatLichSuKham(KiemTraHoSoBenhAnDTO a)
        {
            string query = "select MaPK, NgayKham from PHIEUKHAM where TrangThai = '1' and MaBN = '" + a.Mabn + "' order by NgayKham desc";
            List<KiemTraHoSoBenhAnDTO> lst = new List<KiemTraHoSoBenhAnDTO>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            DataTable dt = DataProvider.LoadTable(query, connection);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KiemTraHoSoBenhAnDTO dto = new KiemTraHoSoBenhAnDTO();
                dto.Mapk = int.Parse(dt.Rows[i]["MaPK"].ToString());
                dto.Ngaykham = DateTime.Parse(dt.Rows[i]["NgayKham"].ToString());
                lst.Add(dto);
            }
            connection.Close();
            return lst;
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
        public List<KiemTraHoSoBenhAnDTO> XuatCTTT(KiemTraHoSoBenhAnDTO a)
        {
            string query = "select CTTT.TenThuoc, CTTT.SoLuong, THUOC.DonViTinh, CTTT.DonGia, CTTT.CachDung from CTTT, THUOC where CTTT.TenThuoc = THUOC.TenThuoc and CTTT.TrangThai = '1' and CTTT.MaPK = '" + a.Mapk + "'";
            List<KiemTraHoSoBenhAnDTO> lst = new List<KiemTraHoSoBenhAnDTO>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            DataTable dt = DataProvider.LoadTable(query, connection);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KiemTraHoSoBenhAnDTO dto = new KiemTraHoSoBenhAnDTO();
                dto.Tenthuoc = dt.Rows[i]["TenThuoc"].ToString();
                dto.Soluong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                dto.Donvitinh = dt.Rows[i]["DonViTinh"].ToString();
                dto.Dongia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                dto.Cachdung = dt.Rows[i]["CachDung"].ToString();
                lst.Add(dto);
            }
            connection.Close();
            return lst;
        }


    }
}
