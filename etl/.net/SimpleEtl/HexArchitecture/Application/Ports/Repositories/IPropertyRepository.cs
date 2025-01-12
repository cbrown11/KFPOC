using simpleEtl.Application.Models.Loader.Dtos;

namespace simpleEtl.Application.Ports.Repositories
{
    public interface IPropertyRepository
    {
        Task Add(IEnumerable<Asset> assets);
    }
}