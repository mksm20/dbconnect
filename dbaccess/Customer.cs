using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace dbaccess
{
    public class Customer
    {
        public int customer_id;
        public List<string> device_id = new List<string>();
        
        public void customerCreate(string customerID){
            string connectionString = "Server = desktop-1v9posi\\mydb; Database = Webtrack_studyproject; User Id = test; Password = password;";
            string queryString = "SELECT * FROM CustomerDevices WHERE CustomerID ='" + customerID + "'";
            SqlCon connection = new SqlCon();
               connection.connectionString = connectionString;
               connection.queryString = queryString;
               connection.OpenConnection();
                SqlDataReader reader = connection.DataReader(queryString);
                int UniqueIdOrdinal = reader.GetOrdinal("UniqueID");

                while(reader.Read()){
                    device_id.Add(reader.GetString(UniqueIdOrdinal));
                }
               connection.CloseConnection();
        }
    }
    
  
}
