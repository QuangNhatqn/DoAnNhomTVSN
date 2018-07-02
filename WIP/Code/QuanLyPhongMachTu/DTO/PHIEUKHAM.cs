using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PHIEUKHAM
    {
        private int MaPK;
        private int MaNV;
        private int MaBN;
        private DateTime NgayKham;
        private string TrieuChung;
        private string KetQua;
        
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
        public DateTime NgayKham1
        {
            get
            {
                return NgayKham;
            }

            set
            {
                NgayKham = value;
            }
        }
        public string TrieuChung1
        {
            get
            {
                return TrieuChung;
            }

            set
            {
                TrieuChung = value;
            }
        }

        public string KetQua1
        {
            get
            {
                return KetQua;
            }

            set
            {
                KetQua = value;
            }
        }

        
    }
}
