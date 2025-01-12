using System.Data;
using Npgsql;

namespace simpleEtl.Infrastructure.Adapters.Loaders
{
    public class PropertyContext
    {
        private readonly string _connectionString;
        public PropertyContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PropertySqlConnection");
        }
        
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}