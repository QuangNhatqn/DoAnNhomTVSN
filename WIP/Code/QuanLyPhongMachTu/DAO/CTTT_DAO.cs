using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class CTTT_DAO
    {
        static SqlConnection Con;

        public static List<CTTT> LoadCTTT()
        {
            // khai bao truy van sql
            string sTruyVan = "select * from CTTT";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List PHIEUKHAM_DTO
            List<CTTT> listb = new List<CTTT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                CTTT b = new CTTT();
                b.MaPK1 = int.Parse(dt.Rows[i]["MaPK"].ToString());
                b.MaThuoc1 = int.Parse(dt.Rows[i]["MaThuoc"].ToString());
                b.SoLuong1 = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                b.DonGia1 = float.Parse(dt.Rows[i]["DonGia"].ToString());
                b.CachDung1 = dt.Rows[i]["CachDung"].ToString();
               
                listb.Add(b);
            }
            DataProvider_1.DongKetNoi(Con);
            return listb;
        }

        // xoa benh nhan
        public static bool XoaCTTT(CTTT CTTTDTO)
        {


            String sTruyVan = string.Format("delete from CTTT where MaBN ='{0}'", CTTTDTO.MaPK1);
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
