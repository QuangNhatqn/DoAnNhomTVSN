using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LapHoaDonDTO
    {

        private int mapk;
        private string tenbn;
        private int mahd;
        private float chiphikham;
        private float chiphithuoc;
        private float tongtien;
        private string tenthuoc;
        private int soluong;
        private string donvitinh;
        private float dongia;


        public int Mapk
        {
            get { return mapk; }
            set { mapk = value; }
        }
        public string Tenbn
        {
            get { return tenbn; }
            set { tenbn = value; }
        }
        public int Mahd
        {
            get { return mahd; }
            set { mahd = value; }
        }
        public float Chiphikham
        {
            get { return chiphikham; }
            set { chiphikham = value; }
        }
        public float Chiphithuoc
        {
            get { return chiphithuoc; }
            set { chiphithuoc = value; }
        }
        public float Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
        public string Tenthuoc
        {
            get { return tenthuoc; }
            set { tenthuoc = value; }
        }
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public string Donvitinh
        {
            get { return donvitinh; }
            set { donvitinh = value; }
        }
        public float Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
    }
}

