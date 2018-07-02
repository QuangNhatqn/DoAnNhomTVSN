using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTTT
    {
        private int MaPK;
        private int MaThuoc;
        private int SoLuong;
        private float DonGia;
        private string CachDung;
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

        public int MaThuoc1
        {
            get
            {
                return MaThuoc;
            }

            set
            {
                MaThuoc = value;
            }
        }

        public int SoLuong1
        {
            get
            {
                return SoLuong;
            }

            set
            {
                SoLuong = value;
            }
        }

        public float DonGia1
        {
            get
            {
                return DonGia;
            }

            set
            {
                DonGia = value;
            }
        }

        public string CachDung1
        {
            get
            {
                return CachDung;
            }

            set
            {
                CachDung = value;
            }
        }

        public CTTT()
        {

        }
    }
}
