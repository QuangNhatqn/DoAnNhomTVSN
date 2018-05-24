using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BACSI
    {
        private int MaBS;

        public int MaBS1
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

        private string TenBS;
        public string TenBS1
        {
            get
            {
                return TenBS;
            }

            set
            {
                TenBS = value;
            }
        }

        private string TenDangNhap;
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


        private string matkhau;
        private DataRow item;

        public string Matkhau
        {
            get
            {
                return matkhau;
            }

            set
            {
                matkhau = value;
            }
        }

        public BACSI(int mabs, string tenbs, string tendangnhap, string matkhau)
        {
            this.MaBS1= mabs;
            this.TenBS1= tenbs;
            this.TenDangNhap1= tendangnhap;
            this.Matkhau = matkhau;
        }

        public BACSI()
        {
        }

        public BACSI(DataRow item)
        {
            this.item = item;
        }

        //public BACSI (DataRow row)
        //{
        //    this.MaBS1 = row["MaBS"].ToString();
        //    this.TenBS1 = row["TenBS"].ToString();
        //    this.TenDangNhap = row["TenDangNhap"].ToString();
        //    this.Matkhau = row["MatKhau"].ToString();
        //}
    }

}
