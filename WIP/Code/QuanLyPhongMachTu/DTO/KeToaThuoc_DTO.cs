using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class KeToaThuoc_DTO
    {
        private string tenThuoc;
        private int soLuong;
        private string donViTinh;
        private string cachDung;
        public string TenThuoc
        {
            get
            {
                return tenThuoc;
            }

            set
            {
                tenThuoc = value;
            }
        }

       

        public string DonViTinh
        {
            get
            {
                return donViTinh;
            }

            set
            {
                donViTinh = value;
            }
        }

        public string CachDung
        {
            get
            {
                return cachDung;
            }

            set
            {
                cachDung = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }
    }
}
