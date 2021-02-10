using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AutoPark.DAL.Repositories
{
    public class ConnectionRepository:IDisposable, IAsyncDisposable
    {
        protected readonly DbConnection connection;
        protected ConnectionRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            connection?.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return connection.DisposeAsync();
        }
    }
}