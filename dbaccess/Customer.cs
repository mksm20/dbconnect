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
            SqlCon a = new SqlCon();
                a.connectionString = connectionString;
                a.queryString = queryString;
                a.OpenConnection();
                SqlDataReader b = a.DataReader(queryString);
                int UniqueIdOrdinal = b.GetOrdinal("UniqueID");

                while(b.Read()){
                    device_id.Add(b.GetString(UniqueIdOrdinal));
                }
                a.CloseConnection();
        }
    }
    
  
}
