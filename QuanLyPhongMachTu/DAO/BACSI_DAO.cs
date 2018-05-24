
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace DAO
{
    public class BACSI_DAO
    {
       
        private static BACSI_DAO instance;

        private BACSI_DAO() { }

        public static BACSI_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BACSI_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool DangNhap(string TenDangNhap, string MatKhau)
        {
            string query = " USP_DANGNHAP @TenDangNhap , @MatKhau";

            DataTable Result = DataProvider.Instance.ExecuteQuery(query, new object[] { TenDangNhap, MatKhau });
            return Result.Rows.Count > 0;

        }
        static SqlConnection Con;
        public  List<BACSI> LoadBacSi()
        {
            
            // khai bao truy van sql
            string sTruyVan = "select * from BACSI";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List PHIEUKHAM_DTO
            List<BACSI> listbs = new List<BACSI>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                BACSI bs = new BACSI();
                bs.MaBS1 = int.Parse(dt.Rows[i]["MaBS"].ToString());
                bs.TenBS1 = dt.Rows[i]["TenBS"].ToString();
                bs.TenDangNhap1 = dt.Rows[i]["TenDangNhap"].ToString();
                bs.Matkhau = dt.Rows[i]["MatKhau"].ToString();

                listbs.Add(bs);
            }
            DataProvider_1.DongKetNoi(Con);
            return listbs;
        }

        public BACSI GetAccountByUserName(string userName)                   
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from BACSI where TenDangNhap = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new BACSI(item);
            }

            return null;
        }
        // chinh sua thong tin bác sĩ
        public bool CapNhatThongTin(string ma, string ten,string tendangnhap,string matkhau, string matkhaumoi)
        {
            int data = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateBACSI @MaBS , @HoTen , @TenDangNhap , @MatKhau , @MKMoi ", new object[] { ma, ten, tendangnhap, matkhau, matkhaumoi});

            return data > 0;
        }

        ////////////////////////////////////////////////////////////////
        // them - sua - xoa table BACSI

        public static DataTable BangKiemTraTonTai(BACSI bnDTO)
        {
            // string sTruyVan = string.Format("SELECT MaBN from BENHNHAN WHERE (TenBN like N'{0}') and (NgaySinh = N'{1}' and (DienThoai = '{2}' and GioiTinh = N'{3}'))", bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DienThoai1, bnDTO.GioiTinh1); // MaBN tu dong tang
            string sTruyVan = string.Format("SELECT MaBS from BACSI WHERE (TenDangNhap =N'{0}') )", bnDTO.TenDangNhap1);
            try
            {
                DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
                DataProvider_1.DongKetNoi(Con);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return null;
            }

        }
        public  bool KiemTraTonTai(BACSI bnDTO)
        {
            string sTruyVan = string.Format("SELECT MaBS from BACSI WHERE (TenDangNhap =N'{0}') )", bnDTO.TenDangNhap1); // MaBN tu dong tang
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }


        }

        public bool ThemBacSi(BACSI bnDTO)
        {
            // tao cau truy van
            // string sTruyVan = @"insert into BENHNHAN(MaBN,TenBN) value"; -- them mot vai thanh phan vao bang
            /* string sTruyVan = string.Format("insert into BENHNHAN values ('{0}',N'{1}','{2}',N'{3}',{4},N'{5}')", bnDTO.MaBN1, bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DiaChi1, bnDTO.DienThoai1, bnDTO.GioiTinh1);*/// them day du thong tin cua bang
            string sTruyVan = string.Format("insert into BACSI values (N'{0}', N'{1}', N'{2}'", bnDTO.TenBS1 , bnDTO.TenDangNhap1 , bnDTO.Matkhau ); // MaBN tu dong tang
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }

        }

        // sua benh nhan

        public  bool SuaBacSi(BACSI bnDTO)
        {
            string sTruyVan = string.Format("update BACSI set TenBS = N'{0}', TenDangNhap=N'{1}', MatKhau=N'{2}'  where MaBS={3}", bnDTO.TenBS1, bnDTO.TenDangNhap1, bnDTO.Matkhau, bnDTO.MaBS1);
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        // xoa benh nhan
        public  DataTable TaoBang(BACSI bnDTO)
        {

            //string x = "BN003";
            //string query = "select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='BN001'";
            //string query = "select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='"+bnDTO.MaBN1+"' ";
            //string query = string.Format("select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='{0}'", x);

            // string query = string.Format("select PHIEUKHAM.MaPK from BENHNHAN , PHIEUKHAM  where BENHNHAN.MaBN = PHIEUKHAM.MaBN and BENHNHAN.MaBN =N'{0}'", bnDTO.MaBN1);
            // string query = string.Format("select PHIEUKHAM.MaPK from PHIEUKHAM  where  PHIEUKHAM.MaBS =N'{0}'", bnDTO.MaBS1);
            //string query = "select *from PHIEUKHAM";
  
            string query = string.Format("SELECT MaPK from PHIEUKHAM,BACSI WHERE BACSI.MaBS = PHIEUKHAM.MaBS and TenDangNhap = '{0}'", bnDTO.TenDangNhap1);
            Con = DataProvider_1.KetNoi();

            DataTable dt = DataProvider_1.LayDataTable(query, Con);

            DataProvider_1.DongKetNoi(Con);

            return dt;
        }

        public  bool XoaCTTT(int x)
        {
            String sTruyVan = string.Format("delete from CTTT where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        public  bool XoaHoaDon(int x)
        {
            String sTruyVan = string.Format("delete from HOADON where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        

        public  bool XoaPhieKham(int x)
        {
            String sTruyVan = string.Format("delete from PHIEUKHAM where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
        public  void DuyetBang(DataTable dt)
        {
            
            if (dt.Rows.Count == 0)
                return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                int x = int.Parse(dt.Rows[i]["MaPK"].ToString());
             
                if (XoaCTTT(x) == true)
                {
                    if (XoaHoaDon(x) == true)
                    {
                        if (XoaPhieKham(x) == true)
                        {

                        }
                        else
                            return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                    return;

            }
        }

        public bool XoaBacSi(BACSI bnDTO)
        {
            DataTable dt = TaoBang(bnDTO);

            if (dt != null)
                DuyetBang(dt);

            String sTruyVan = string.Format("delete from BACSI where TenDangNhap ='{0}'", bnDTO.TenDangNhap1);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
    }
}
