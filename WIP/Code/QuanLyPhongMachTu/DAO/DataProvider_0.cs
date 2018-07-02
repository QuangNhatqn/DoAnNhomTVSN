using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DataProvider_0
    {


        private static DataProvider_0 instance;

        private string connectionSTR = ConfigurationManager.AppSettings["ConnectionString"];//@"Data Source=DESKTOP-HLJNT2J\SQLEXPRESS;Initial Catalog=QLKB;Integrated Security=True";

        public static DataProvider_0 Instance
        {
            get
            {

                if (instance == null) instance = new DataProvider_0();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        private DataProvider_0() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();


                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }


        //////////////////////

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {

            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();


                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        /////////////////////

        public object ExecuteScalar(string query, object[] parameter = null)
        {

            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();


                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }

}
