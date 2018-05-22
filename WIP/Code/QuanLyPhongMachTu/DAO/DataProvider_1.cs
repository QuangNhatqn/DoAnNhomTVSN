﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    class DataProvider_1
    {
        //ket noi
        public static SqlConnection KetNoi()
        {
            string sChuoiKetNoi = @"Data Source=DESKTOP-R6C5BS9;Initial Catalog=Quanlikhambenh;Integrated Security=True";
            SqlConnection Con = new SqlConnection(sChuoiKetNoi);
            Con.Open();
            return Con;
            
        }
        //dong ket noi
        public static void DongKetNoi(SqlConnection Con)
        {

            Con.Close();

        }

        // lay datatable
        public static DataTable LayDataTable (string sTruyVan, SqlConnection Con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, Con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool ThucThiTruyVanNonQuery(string sTruyVan, SqlConnection Con)
        {
            try
            {
                SqlCommand Command = new SqlCommand(sTruyVan, Con);
                Command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex);
                return false;
            }
        }

    }
}
