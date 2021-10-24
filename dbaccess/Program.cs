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
            Customer a = dbAccesCustom(queryString, connectionString);
            string connectionString2 = "Server = DESKTOP-ODNL8OS; Database = Tracking_FM2_studyproject; User Id = test; Password = password;";
            string queryString2 = "SELECT * FROM Track WHERE ItemID = " + "'" + a.device_id[1] + "'";
            Unit x = DbAccessFM2(connectionString2, queryString2, a);
            for (int i = 0; i < 160; i++)
            {
                Console.WriteLine(x.address[i] + '\n');
            }

        }
        
        static Unit DbAccessFM2(string connectionString, string queryString, Customer customer)
        {
            var unit = new Unit();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    cmd.Connection.Open();
                    Console.WriteLine("Connected to Tracking FM2");
                }
                catch (SqlException e) { Console.WriteLine(e); }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int ItemIdOrdinal = reader.GetOrdinal("Address");                    
                    unit.itemId = customer.device_id[1];
                    while (reader.Read())
                    {
                        unit.address.Add(reader.GetString(ItemIdOrdinal));
                    }
                    
                }
            }
            return unit;

        }
            
        
        static Customer dbAccesCustom(string queryString, string connectionString)
        {
            var customer = new Customer();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    cmd.Connection.Open();
                    Console.WriteLine("Connection open " + cmd.Connection.Database);
                }
                catch (SqlException e) { Console.WriteLine(e); }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int UniqueIdOrdinal = reader.GetOrdinal("UniqueID");
                    
                    while (reader.Read())
                    {

                        customer.customer_id = 178;
                        customer.device_id.Add(reader.GetString(UniqueIdOrdinal));
                    }
                }
            }
            return customer;
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
