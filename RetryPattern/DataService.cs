using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern
{
    public class DataService
    {
        private const string connectionString = @"";
        private string queryString = @"SELECT 
                                        * FROM dbo.Vendors";
        private RetryExecutor retryExecutor;
        public DataService()
        {
            RetryStrategy retryStrategy = new RetryStrategy(3, TimeSpan.FromSeconds(2));
            retryExecutor = new RetryExecutor(retryStrategy);
        }
        public void GetData() 
        {
            retryExecutor.Retry(
                ()=> 
                {
                    using (SqlConnection connection =  new SqlConnection(connectionString))
                    {
                        // Create the Command and Parameter objects.
                        SqlCommand command = new SqlCommand(queryString, connection);
                        
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}",
                                reader[0], reader[1], reader[2]);
                        }
                        reader.Close();                        
                    }
                });            
        }
      
    }
}
