using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NHANVIEN
    {
        private int MaNV;
        private string TenNV;
        private string TenDangNhap;
        private string Matkhau;
        private DataRow item;
        int LoaiNV;
        int TrangThai;

        public int MaNV1
        {
            get
            {
                return MaNV;
            }

            set
            {
                MaNV = value;
            }
        }

        public string TenNV1
        {
            get
            {
                return TenNV;
            }

            set
            {
                TenNV = value;
            }
        }

        public string TenDangNhap1
        {
            get
            {
                return TenDangNhap;
            }

            set
            {
                TenDangNhap = value;
            }
        }

        public string Matkhau1
        {
            get
            {
                return Matkhau;
            }

            set
            {
                Matkhau = value;
            }
        }

        public int LoaiNV1
        {
            get
            {
                return LoaiNV;
            }

            set
            {
                LoaiNV = value;
            }
        }

        public int TrangThai1
        {
            get
            {
                return TrangThai;
            }

            set
            {
                TrangThai = value;
            }
        }

        public NHANVIEN( string tennv, string tendangnhap, string matkhau, int loai, int tinhtrangtontai)
        {
           
            this.TenNV1= tennv;
            this.TenDangNhap1= tendangnhap;
            this.Matkhau1 = matkhau;
            this.LoaiNV1 = loai;
            this.TrangThai1 = tinhtrangtontai;
        }

       
        public NHANVIEN(int manv,string tennv, string tendangnhap, string matkhau)
        {
            this.MaNV1 = manv;
            this.TenNV1 = tennv;
            this.TenDangNhap1 = tendangnhap;
            this.Matkhau1 = matkhau;
        }

        public NHANVIEN(int manv, string tennv, string tendangnhap)
        {
            this.MaNV1 = manv;
            this.TenNV1 = tennv;
            this.TenDangNhap1 = tendangnhap;
        }
        public NHANVIEN( string tendangnhap, string matkhau)
        {
            this.TenDangNhap1 = tendangnhap;
            this.Matkhau1 = matkhau;
        }

        public NHANVIEN()
        {
        }

        public NHANVIEN(DataRow item)
        {
            this.item = item;
        }

    }

}
