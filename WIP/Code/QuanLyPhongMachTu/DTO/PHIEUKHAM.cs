using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PHIEUKHAM
    {
        private string MaPK;
        private string MaBS;
        private string MaBN;
         private DateTime NgayKham;
        private string TrieuChung;
        private string KetQua;
       
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

        public string MaBS1
        {
            get
            {
                return MaBS;
            }

            set
            {
                MaBS = value;
            }
        }

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
