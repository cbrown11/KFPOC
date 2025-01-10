
using Dapper;
using researchApi.Application.Models.External.Dtos;
using researchApi.Application.Ports.Repositories;
using researchApi.Infrastructure.Adapters.SQL;

namespace researchApi.Adapters
{
    public class ResearchRepositryAzureSQL : IResearchRepositry
    {
        private readonly DapperContext _context;

        public ResearchRepositryAzureSQL(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResearchObject>> GetResearchObjectsAsync()
        {
            var  query  = "SELECT * FROM [Assets] (NOLOCK)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ResearchObject>(query);
            }
        }
    }
}