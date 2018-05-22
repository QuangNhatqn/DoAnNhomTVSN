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

        public string MaBN1
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

        

        private string MaBN;

        private string TenBN;

        private DateTime NgaySinh;

        private string DiaChi;

        private string DienThoai;

        private string GioiTinh;

        public BENHNHAN(string mabn,string tenbn, DateTime ngaysinh,string diachi,string dienthoai,string gioitinh)
        {
            this.MaBN = mabn;
            this.TenBN = tenbn;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diachi;
            this.DienThoai = dienthoai;
            this.GioiTinh = gioitinh;
          

        }

        public BENHNHAN()
        {


        }

        public BENHNHAN(string mabn)
        {

            this.MaBN = mabn;
        }


    }
}
