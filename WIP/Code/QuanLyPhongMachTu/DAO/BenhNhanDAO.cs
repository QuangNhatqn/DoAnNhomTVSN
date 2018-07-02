using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DAO;
namespace DAO
{
    public  class BenhNhanDAO
    {

        // khoi tao bien ket noi
        static SqlConnection Con;
        //Load benhnhan
        public static List<BENHNHAN> LoadBenhNhan()
        {
            // khai bao truy van sql
            string sTruyVan = "select * from BENHNHAN where TrangThai = '1'";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List BenhNhan_DTO
            List<BENHNHAN> listbn = new List<BENHNHAN>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BENHNHAN bn = new BENHNHAN();

                // bn.MaBN1 = dt.Rows[i]["MaBN"].ToString(); // MaBN kieu string
                bn.MaBN1 = int.Parse(dt.Rows[i]["MaBN"].ToString());
                bn.TenBN1 = dt.Rows[i]["TenBN"].ToString();
                bn.NgaySinh1 = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                bn.DiaChi1 = dt.Rows[i]["DiaChi"].ToString();
                bn.DienThoai1 = dt.Rows[i]["DienThoai"].ToString();
                bn.GioiTinh1 = dt.Rows[i]["GioiTinh"].ToString();
                bn.TrangThai1 =int.Parse( dt.Rows[i]["TrangThai"].ToString());
                listbn.Add(bn);
            }
            DataProvider_1.DongKetNoi(Con);
            return listbn;
        }
        public static DataTable BangKiemTraTonTai(BENHNHAN bnDTO)
        {
            // string sTruyVan = string.Format("SELECT MaBN from BENHNHAN WHERE TrangThai = '1' and (NgaySinh = N'{1}' and (DienThoai = '{2}' and GioiTinh = N'{3}'))", bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DienThoai1, bnDTO.GioiTinh1); // MaBN tu dong tang
            string sTruyVan = string.Format("SELECT * from BENHNHAN WHERE TrangThai = '1' and (TenBN = N'{0}' and DienThoai = '{1}')", bnDTO.TenBN1, bnDTO.DienThoai1);
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt;
        }
        public static bool KiemTraTonTai(BENHNHAN bnDTO)
        {
            string sTruyVan = string.Format("SELECT MaBN from BENHNHAN WHERE TrangThai = '1' and (TenBN like N'{0}') and (NgaySinh = N'{1}' and (DienThoai = '{2}' and GioiTinh = N'{3}'))", bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DienThoai1, bnDTO.GioiTinh1); // MaBN tu dong tang
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }

        
        }
        
        // Them BenhNhan
        public static bool ThemBenhNhan(BENHNHAN bnDTO)
        {
            // tao cau truy van
            // string sTruyVan = @"insert into BENHNHAN(MaBN,TenBN) value"; -- them mot vai thanh phan vao bang
            /* string sTruyVan = string.Format("insert into BENHNHAN values ('{0}',N'{1}','{2}',N'{3}',{4},N'{5}')", bnDTO.MaBN1, bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DiaChi1, bnDTO.DienThoai1, bnDTO.GioiTinh1);*/// them day du thong tin cua bang
            string sTruyVan = string.Format("insert into BENHNHAN values (N'{0}',N'{1}',N'{2}','{3}',N'{4}', '1')", bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DiaChi1, bnDTO.DienThoai1, bnDTO.GioiTinh1); // MaBN tu dong tang
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
         
        }

        // sua benh nhan

        public static bool SuaBenhNhan(BENHNHAN bnDTO)
        {
            string sTruyVan = string.Format("update BENHNHAN set TenBN = N'{0}', NgaySinh=N'{1}', DiaChi=N'{2}', DienThoai='{3}', GioiTinh=N'{4}' where MaBN={5}", bnDTO.TenBN1 , bnDTO.NgaySinh1 , bnDTO.DiaChi1 , bnDTO.DienThoai1 , bnDTO.GioiTinh1 , bnDTO.MaBN1 );
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        // xoa benh nhan
        public static bool XoaBenhNhan(BENHNHAN bnDTO)
        {
            
            String sTruyVan = string.Format("update BENHNHAN set TrangThai = '0' where MaBN ='{0}'", bnDTO.MaBN1);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
        //
        public static DataTable TaoBang(BENHNHAN bnDTO)
        {

            //string x = "BN003";
            //string query = "select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='BN001'";
            //string query = "select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='"+bnDTO.MaBN1+"' ";
            //string query = string.Format("select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='{0}'", x);

            // string query = string.Format("select PHIEUKHAM.MaPK from BENHNHAN , PHIEUKHAM  where BENHNHAN.MaBN = PHIEUKHAM.MaBN and BENHNHAN.MaBN =N'{0}'", bnDTO.MaBN1);
            string query = string.Format("select PHIEUKHAM.MaPK from PHIEUKHAM  where  PHIEUKHAM.MaBN =N'{0}'", bnDTO.MaBN1);
           
            Con = DataProvider_1.KetNoi();

            DataTable dt = DataProvider_1.LayDataTable(query, Con);

            DataProvider_1.DongKetNoi(Con);
            if (dt.Rows.Count == 0)
                return null;
            else
            return dt;
        }

        public static bool XoaCTTT(int x)
        {
            String sTruyVan = string.Format("update CTTT set TrangThai = '0' where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        public static  bool XoaHoaDon(int x)
        {
            String sTruyVan = string.Format("update HOADON set TrangThai = '0' where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        

        public static bool XoaPhieKham(int x)
        {
            String sTruyVan = string.Format("update PHIEUKHAM set TrangThai ='0' where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
        public static void DuyetBang(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return ;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //foreach (DataRow row in dt.Rows) // Duyệt từng dòng (DataRow) trong DataTable
                //{

                //foreach (var item in row.ItemArray) // Duyệt từng cột của dòng hiện tại
                //{
                int x = int.Parse(dt.Rows[i]["MaPK"].ToString());
                //num = Convert.ToInt32(ds.Table["DSTinh"].Rows[i].Item["columnName"].ToString());

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

             
                //    }
                //}
                // Pause.

            }
        }

        public  static bool XoaBenhNhanCu(BENHNHAN bnDTO)
        {
            DataTable dt = TaoBang(bnDTO);

            if(dt != null)
            DuyetBang(dt);
            
            String sTruyVan = string.Format("update BENHNHAN set TrangThai = '0' where MaBN ='{0}'", bnDTO.MaBN1);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
               bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                if (KetQua == true)
                    return true;
                else
                    return false;
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

