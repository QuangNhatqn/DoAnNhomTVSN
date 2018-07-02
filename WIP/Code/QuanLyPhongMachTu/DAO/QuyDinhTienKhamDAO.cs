using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class QuyDinhTienKhamDAO
    {
        static SqlConnection Con;

        public static float LayGiaCu()
        {
            float GiaCu = 0;
            string query = "select TienKham from QUIDINH";
            Con = DataProvider_1.KetNoi();
            try
            {
                DataTable dt = DataProvider_1.LayDataTable(query, Con);
                DataProvider_1.DongKetNoi(Con);
                if (dt.Rows.Count == 0)
                    return 0;
                //bn.TenThuoc1 = dt.Rows[i]["TenThuoc"].ToString();
                GiaCu = float.Parse(dt.Rows[0]["TienKham"].ToString());
                // GiaCu = float.Parse(dt.Rows.ToString());
                return GiaCu;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                DataProvider_1.DongKetNoi(Con);
                return 0;
            }
            //DataTable dt = DataProvider.LoadTable(query, Con);
            //if (dt.Rows.Count == 0)
            //    return 0;

            //GiaCu = float.Parse(dt.Rows.ToString());
            //return GiaCu;

        }

        public static bool Sua(float TienKham)
        {
            string sTruyVan = string.Format("update QUIDINH set TienKham = N'{0}'", TienKham);
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
