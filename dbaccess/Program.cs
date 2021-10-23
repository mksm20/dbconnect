using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace dbaccess
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server = DESKTOP-ODNL8OS; Database = Webtrack_studyproject; User Id = test; Password = password;";
            string queryString = "SELECT * FROM CustomerDevices WHERE CustomerID ='178'"; 
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    cmd.Connection.Open();
                    Console.WriteLine("Connection open " + cmd.Connection.Database);
                }
                catch(SqlException e) { Console.WriteLine(e); }
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    int UniqueIdOrdinal = reader.GetOrdinal("UniqueID");
                    var customer = new Customer();
                    while (reader.Read())
                    {
                        
                        customer.customer_id = 178;
                        customer.device_id.Add(reader.GetString(UniqueIdOrdinal));
                    }
                    Console.WriteLine(customer.device_id[1]);
                    string connectionString2 = "Server = DESKTOP-ODNL8OS; Database = Tracking_FM2_studyproject; User Id = test; Password = password;";
                    string queryString2 = "SELECT * FROM Track WHERE ItemID = " + "'" + customer.device_id[1] + "'";
                    using (SqlConnection connection2 = new SqlConnection(connectionString2))
                    {
                        SqlCommand cmd2 = new SqlCommand(queryString2, connection2);
                        try
                        {
                            cmd2.Connection.Open();
                            Console.WriteLine("Connected to Tracking FM2");
                        }catch(SqlException e) { Console.WriteLine(e); }
                        using (SqlDataReader reader2 = cmd2.ExecuteReader())
                        {
                            int ItemIdOrdinal = reader2.GetOrdinal("Address");
                            var unit = new Unit();
                            unit.itemId = customer.device_id[1];
                            while (reader2.Read())
                            {
                                unit.address.Add(reader2.GetString(ItemIdOrdinal));
                            }
                            for(int i = 0; i < 160; i++)
                            {
                                Console.WriteLine(unit.address[i] + '\n');
                            }
                        }
                    }

                }
                
            }
        }
    }
    public class Customer
    {
        public int customer_id;
        public List<string> device_id = new List<string>();
    }
    public class Unit
    {
        public string itemId;
        public List<string> address = new List<string>();
    }
    
  
}
