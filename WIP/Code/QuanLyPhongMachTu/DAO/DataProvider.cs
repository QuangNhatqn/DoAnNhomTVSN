using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DataProvider
    {
        
        //ket noi
        public static SqlConnection KetNoi()
        {
            //string sChuoiKetNoi = @"Data Source=DESKTOP-HLJNT2J\SQLEXPRESS;Initial Catalog=QLKB;Integrated Security=True";
            string sChuoiKetNoi = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection Con = new SqlConnection(sChuoiKetNoi);
            Con.Open();
            return Con;

        }
        //dong ket noi
        public static void DongKetNoi(SqlConnection Con)
        {

            Con.Close();

        }

        //lấy table
        public static DataTable LoadTable(string query, SqlConnection connectionString)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //nonquery
        public static bool ThucThiNonQuery(string query, SqlConnection connectionString)
        {
            try
            {
                SqlCommand com = new SqlCommand(query, connectionString);
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
