using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    class DataPro
    {
        private string connectionSTR;// = @"Data Source=DESKTOP-HLJNT2J\SQLEXPRESS;Initial Catalog=QLKB;Integrated Security=True";//gan chuoi ket noi vo connectionSTR
        public DataPro()
        {
            connectionSTR = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionSTR
        {
            get
            {
                return connectionSTR;
            }

            set
            {
                connectionSTR = value;
            }
        }

        public DataSet ExecuteQuery(string query)
        {
            DataSet data = new DataSet();//tao noi do du Enterprise
            using (SqlConnection connection = new SqlConnection(connectionSTR))//ep kieu thanh sqlconnection vo connection
            {
                connection.Open();//mo ket noi
                SqlCommand command = new SqlCommand(query, connection);//execute (chay) cau lenh sql
                SqlDataAdapter adapter = new SqlDataAdapter(command);//luu du lieu command
                adapter.Fill(data, "tbl");//do du lieu vao dataset
                connection.Close();//dong ket noi
            }
            return data;
        }
        public DataTable ExecuteQueryTable(string query)
        {
            DataTable data = new DataTable();//tao noi do du lieu
            using (SqlConnection connection = new SqlConnection(connectionSTR))//ep kieu thanh sqlconnection vo connection
            {
                connection.Open();//mo ket noi
                SqlCommand command = new SqlCommand(query, connection);//execute (chay) cau lenh sql
                SqlDataAdapter adapter = new SqlDataAdapter(command);//luu du lieu command
                adapter.Fill(data);//do du lieu vao dataTable
                connection.Close();//dong ket noi
            }
            return data;
        }



    }
}
