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
            string sTruyVan = "select * from PHIEUKHAM";
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
                bn.MaPK1 = dt.Rows[i]["MaPK"].ToString();
                bn.MaBS1= dt.Rows[i]["MaBS"].ToString();
                bn.MaBN1 = dt.Rows[i]["MaBN"].ToString();
                bn.NgayKham1 = DateTime.Parse(dt.Rows[i]["NgayKham"].ToString());
                bn.TrieuChung1 = dt.Rows[i]["TrieuChung"].ToString();
                bn.KetQua1 = dt.Rows[i]["KetQua"].ToString();
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
            string sTruyVan = string.Format("insert into PHIEUKHAM values ('{0}','{1}','{2}','{3}',N'{4}',N'{5}')", bnDTO.MaPK1, bnDTO.MaBS1, bnDTO.MaBN1, bnDTO.NgayKham1, bnDTO.TrieuChung1,bnDTO.KetQua1);// them day du thong tin cua bang
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
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
            // DataProvider_1.DongKetNoi(Con);
          
        }


        // Sua PHIEUKHAM
        public static bool SuaPHIEUKHAM(PHIEUKHAM pkDTO)
        {
            // tao cau truy van
            // string sTruyVan = @"insert into PHIEUKHAM(MaBN,TenBN) value"; -- them mot vai thanh phan vao bang
            string sTruyVan = string.Format("update PHIEUKHAM set MaBS=N'{0}' , MaBN=N'{1}' , NgayKham=N'{2}' , TrieuChung=N'{3}' , KetQua=N'{4}' where MaPK='{5}'", pkDTO.MaBS1 , pkDTO.MaBN1 , pkDTO.NgayKham1 , pkDTO.TrieuChung1 , pkDTO.KetQua1 , pkDTO.MaPK1);
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
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
           
        }

        // Xoa PHIEUKHAM
        public static bool XoaPHIEUKHAM(PHIEUKHAM pkDTO)
        {
            // tao cau truy van
           
            string sTruyVan = string.Format("delete from PHIEUKHAM where MaPK = '{0}'", pkDTO.MaPK1);
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
                
                DataProvider_1.DongKetNoi(Con);
                return false;
            }

        }
    }
}
