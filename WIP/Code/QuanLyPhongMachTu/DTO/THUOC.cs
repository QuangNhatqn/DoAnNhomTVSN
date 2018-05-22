using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class THUOC
    {
        private int Mathuoc;
        private string TenThuoc;
        private string DonViTinh;
        private float Gia;
        public int Mathuoc1
        {
            get
            {
                return Mathuoc;
            }

            set
            {
                Mathuoc = value;
            }
        }

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

        public THUOC()
        {

        }
    }
}
