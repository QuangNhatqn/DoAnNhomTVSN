using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BENHNHAN
    {
        // private string MaBN;
        private int MaBN;

        private string TenBN;

        private DateTime NgaySinh;

        private string DiaChi;

        private string DienThoai;

        private string GioiTinh;
        private int TrangThai;
        public int MaBN1
        {
            get
            {
                return MaBN;
            }

            set
            {
                MaBN = value;
            }
        }

        public string TenBN1
        {
            get
            {
                return TenBN;
            }

            set
            {
                TenBN = value;
            }
        }

        public DateTime NgaySinh1
        {
            get
            {
                return NgaySinh;
            }

            set
            {
                NgaySinh = value;
            }
        }

        public string DiaChi1
        {
            get
            {
                return DiaChi;
            }

            set
            {
                DiaChi = value;
            }
        }

        public string DienThoai1
        {
            get
            {
                return DienThoai;
            }

            set
            {
                DienThoai = value;
            }
        }

        public string GioiTinh1
        {
            get
            {
                return GioiTinh;
            }

            set
            {
                GioiTinh = value;
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

        public BENHNHAN(int mabn,string tenbn, DateTime ngaysinh,string diachi,string dienthoai,string gioitinh, int TrangThai)
        {
            this.MaBN = mabn;
            this.TenBN = tenbn;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diachi;
            this.DienThoai = dienthoai;
            this.GioiTinh = gioitinh;
            this.TrangThai = TrangThai;

        }

        public BENHNHAN()
        {


        }

        public BENHNHAN(int mabn)
        {

            this.MaBN = mabn;
        }

        public BENHNHAN(string tenbn, DateTime ngaysinh, string diachi, string dienthoai, string gioitinh)
        {

            this.TenBN = tenbn;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diachi;
            this.DienThoai = dienthoai;
            this.GioiTinh = gioitinh;
        }


    }
}
