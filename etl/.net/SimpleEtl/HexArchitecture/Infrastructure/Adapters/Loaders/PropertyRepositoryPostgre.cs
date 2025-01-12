using simpleEtl.Application.Models.Loader.Dtos;
using simpleEtl.Application.Ports.Repositories;
using Z.Dapper.Plus;

namespace simpleEtl.Infrastructure.Adapters.Loaders
{
    public class PropertyRepositoryPostgre : IPropertyRepository
    {
        private readonly PropertyContext _context;

        public PropertyRepositoryPostgre(PropertyContext context)
        {
            _context = context;
        }

        public async Task Add(IEnumerable<Asset> assets)
        {
            try{
                using (var connection = _context.CreateConnection())
                {
                    await connection
                      .UseBulkOptions(options => options.InsertIfNotExists = true)
                      .BulkInsertAsync(assets);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Add assets to Postgres.", ex);
            }
        }
    }
}