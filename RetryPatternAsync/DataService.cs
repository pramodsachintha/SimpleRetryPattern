using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RetryPatternAsync {
    public class DataService {
        private const string ConnectionString = @"";
        private readonly string queryString = @"SELECT * FROM dbo.Vendors";
        private readonly RetryExecutor retryExecutor;

        public DataService() {
            var retryStrategy = new RetryStrategy(3, TimeSpan.FromSeconds(2));
            retryExecutor = new RetryExecutor(retryStrategy);
        }

        public async Task GetData() {
            
            await retryExecutor.Retry(async () => {
                
                await using var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync()) {
                    Console.WriteLine($"\t{reader[0]}\t{reader[1]}\t{reader[2]}");
                }
                await reader.CloseAsync();

            });
        }
    }
}
