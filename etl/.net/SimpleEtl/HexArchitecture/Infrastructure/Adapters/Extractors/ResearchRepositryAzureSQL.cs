
using Dapper;
using simpleEtl.Application.Models.Extractor.Dtos;
using simpleEtl.Application.Ports.Repositories;


namespace simpleEtl.Infrastructure.Adapters.Extractors
{
    public class ResearchRepositoryAzureSQL : IResearchRepository
    {
        private readonly ResearchContext _context;

        public ResearchRepositoryAzureSQL(ResearchContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResearchObject>> GetResearchObjectsAsync()
        {
            var  query  = "SELECT * FROM dbo.[Assets] (NOLOCK)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ResearchObject>(query);
            }
        }
    }
}