using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class THUOC
    {
       
        private string TenThuoc;
        private string DonViTinh;
        private float Gia;
        private int TrangThai;
        
        public string TenThuoc1
        {
            get
            {
                return TenThuoc;
            }

            set
            {
                TenThuoc = value;
            }
        }

        public string DonViTinh1
        {
            get
            {
                return DonViTinh;
            }

            set
            {
                DonViTinh = value;
            }
        }

        public float Gia1
        {
            get
            {
                return Gia;
            }

            set
            {
                Gia = value;
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

        public THUOC()
        {

        }
        public THUOC(string Ten, string DVT, int Gia, int TrangThai)
        {
            this.TenThuoc1 = Ten;
            this.DonViTinh1 = DVT;
            this.Gia1 = Gia;
            this.TrangThai1 = TrangThai;
        }
    }
}
