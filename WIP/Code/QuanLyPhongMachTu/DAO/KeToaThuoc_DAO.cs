using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using DAO;

namespace DAO
{
    public class KeToaThuoc_DAO
    {
        static SqlConnection Con;

        public static List<CTTT> LoadCTTT(int MaPK)
        {
            
            string sTruyVan = string.Format( "select * from CTTT WHERE MaPK ='{0}'", MaPK);
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List BenhNhan_DTO
            List<CTTT> listbn = new List<CTTT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CTTT DTO = new CTTT();

                DTO.MaPK1 = int.Parse(dt.Rows[i]["MaPK"].ToString());
                DTO.MaThuoc1 = int.Parse(dt.Rows[i]["MaThuoc"].ToString());
                DTO.SoLuong1 = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                DTO.DonGia1 = float.Parse(dt.Rows[i]["DonGia"].ToString());
                DTO.CachDung1 = dt.Rows[i]["CachDung"].ToString();

            }
            DataProvider_1.DongKetNoi(Con);
            return listbn;
        }
        public static bool ThemVaoCTTT(CTTT DTO)
        {

            string sTruyVan = string.Format("insert into CTTT values ('{0}','{1}','{2}','{3}',N'{4}')", DTO.MaPK1, DTO.MaPK1, DTO.SoLuong1, DTO.DonGia1, DTO.CachDung1 ); // MaBN tu dong tang
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
 

        public static bool ThemKetQuaVaoPhieuKham(PHIEUKHAM DTO)
{

    string sTruyVan = string.Format("update PHIEUKHAM set KetQua = N'{0}' where MaPK={1}", DTO.KetQua1, DTO.MaPK1);
    Con = DataProvider_1.KetNoi();
    try
    {
      
        bool KetQua = DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
    
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