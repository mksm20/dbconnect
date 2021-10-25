using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace dbaccess
{
    public class SqlCon
    {
        public string connectionString = "";
        public string queryString = "";
        SqlConnection connection;
        public void OpenConnection(){
            connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    cmd.Connection.Open();
                    Console.WriteLine("Connected to " + cmd.Connection.Database);
                }
                catch (SqlException e) { Console.WriteLine(e); }
        }

        public void CloseConnection(){
            connection.Close();
        }

        public SqlDataReader DataReader(string queryString){
            
            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }


    }
    
  
}
