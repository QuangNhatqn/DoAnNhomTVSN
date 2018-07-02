using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HOADON
    {
        private int MaHD;
        private int MaPK;
        private float TienKham;
        private float TienThuoc;
        private float TongTien;
      
        public int MaHD1
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

        public int MaPK1
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
