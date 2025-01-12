using System.Data;
using System.Data.SqlClient;

namespace simpleEtl.Infrastructure.Adapters.Extractors
{
    public class ResearchContext
    {
        private readonly string _connectionString;
        public ResearchContext(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("ResearchSqlConnection");
        }
        
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}