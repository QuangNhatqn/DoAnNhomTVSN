using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HOADON
    {
        private string MaHD;
        private string MaPK;
        private float TienKham;
        private float TienThuoc;
        private float TongTien;
      
        public string MaHD1
        {
            get
            {
                return MaHD;
            }

            set
            {
                MaHD = value;
            }
        }

        public string MaPK1
        {
            get
            {
                return MaPK;
            }

            set
            {
                MaPK = value;
            }
        }

        public float TienKham1
        {
            get
            {
                return TienKham;
            }

            set
            {
                TienKham = value;
            }
        }

        public float TienThuoc1
        {
            get
            {
                return TienThuoc;
            }

            set
            {
                TienThuoc = value;
            }
        }

        public float TongTien1
        {
            get
            {
                return TongTien;
            }

            set
            {
                TongTien = value;
            }
        }

        public HOADON ()
        {

        }
    }
}
