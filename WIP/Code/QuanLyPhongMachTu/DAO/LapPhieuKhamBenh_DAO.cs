using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class LapPhieuKhamBenh_DAO
    {
        // khoi tao bien ket noi
        static SqlConnection Con;
        //Load PHIEUKHAM

        public static List<PHIEUKHAM> LoadPhieuKham()
        {
            // khai bao truy van sql
            string sTruyVan = "select * from PHIEUKHAM WHERE TrangThai = '1'";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List PHIEUKHAM_DTO
            List<PHIEUKHAM> listbn = new List<PHIEUKHAM>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                PHIEUKHAM bn = new PHIEUKHAM();
                bn.MaPK1 = int.Parse(dt.Rows[i]["MaPK"].ToString());
                bn.MaNV1= int.Parse(dt.Rows[i]["MaNV"].ToString());
                bn.MaBN1 = int.Parse(dt.Rows[i]["MaBN"].ToString());
                bn.NgayKham1 = DateTime.Parse(dt.Rows[i]["NgayKham"].ToString());
                bn.TrieuChung1 = dt.Rows[i]["TrieuChung"].ToString();
                //bn.KetQua1 = dt.Rows[i]["KetQua"].ToString();
                listbn.Add(bn);
            }
            DataProvider_1.DongKetNoi(Con);
            return listbn;
        }

    
        // Them PHIEUKHAM
        public static bool ThemPHIEUKHAM(PHIEUKHAM bnDTO)
        {
            // tao cau truy van
            // string sTruyVan = @"insert into PHIEUKHAM(MaBN,TenBN) value"; -- them mot vai thanh phan vao bang
            string sTruyVan = string.Format("insert into PHIEUKHAM values ('{0}','{1}',N'{2}',N'{3}',N'{4}', '1')", bnDTO.MaNV1, bnDTO.MaBN1, bnDTO.NgayKham1, bnDTO.TrieuChung1,bnDTO.KetQua1);// them day du thong tin cua bang
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


        // Sua PHIEUKHAM
        public static bool SuaPHIEUKHAM(PHIEUKHAM pkDTO)
        {
            // tao cau truy van
            // string sTruyVan = @"insert into PHIEUKHAM(MaBN,TenBN) value"; -- them mot vai thanh phan vao bang
            string sTruyVan = string.Format("update PHIEUKHAM set MaNV=N'{0}' , MaBN=N'{1}' , NgayKham=N'{2}' , TrieuChung=N'{3}'  where MaPK='{4}'", pkDTO.MaNV1 , pkDTO.MaBN1 , pkDTO.NgayKham1 , pkDTO.TrieuChung1  , pkDTO.MaPK1);
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

        // Xoa PHIEUKHAM
        //public static bool Xoa(PHIEUKHAM pkDTO)
        //{
        //    // tao cau truy van
           
        //    string sTruyVan = string.Format("delete from PHIEUKHAM where MaPK = '{0}'", pkDTO.MaPK1);
        //    Con = DataProvider_1.KetNoi();
        //    try
        //    {
        //        // thuc thi truy van
        //        bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
        //        // dong ket noi
        //        DataProvider_1.DongKetNoi(Con);
        //        if (KetQua == true)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.StackTrace);
        //        DataProvider_1.DongKetNoi(Con);
        //        return false;
        //    }

        //}
        /////////////////////////////////////////////////////////////////////////////////
       
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

        public static bool XoaHoaDon(int x)
        {
            String sTruyVan = string.Format("update HOADON set TrangThai = '1' where MaPK ='{0}'", x);

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


        public static bool XoaPK(int x)
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
                return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int x = int.Parse(dt.Rows[i]["MaPK"].ToString());
        
                if (XoaCTTT(x) == true)
                {
                    if (XoaHoaDon(x) == true)
                    {
                        if (XoaPK(x) == true)
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

        public static bool XOAPHIEUKHAM(PHIEUKHAM bnDTO)
        {
            
            if (XoaCTTT(bnDTO.MaPK1) == true)
            {
                if (XoaHoaDon(bnDTO.MaPK1) == true)
                {
                    if (XoaPK(bnDTO.MaPK1) == true)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
            
        }
    }
}
