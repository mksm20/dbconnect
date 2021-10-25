using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace dbaccess
{
    class Program
    {
        static Unit populateUnit(Customer customer){
            Unit unit = new Unit();
            string connectionString2 = "Server = desktop-1v9posi\\mydb; Database = Tracking_FM2_studyproject; User Id = test; Password = password;";
            string queryString2 = "SELECT * FROM Track WHERE TimeStamp between '2020-10-06' and '2020-10-31' AND ItemID = " + "'" + customer.device_id[1] + "'";

            SqlCon connection = new SqlCon();
            connection.connectionString = connectionString2;
            connection.queryString = queryString2;
            connection.OpenConnection();

            SqlDataReader reader = connection.DataReader(queryString2);
            int ItemIdOrdinal = reader.GetOrdinal("Address");                    
            unit.itemId = customer.device_id[1];

            while(reader.Read()){
                unit.address.Add(reader.GetString(ItemIdOrdinal));
            }
            return unit;
        }

        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.customerCreate("178");
            Unit unit = populateUnit(customer);
            

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(unit.address[i] + '\n');
            }

        }
    }
        

    public class Unit
    {
        public string itemId;
        public List<string> address = new List<string>();
    }
    
  
}
