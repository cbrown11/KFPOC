using simpleEtl.Application.Models.Extractor.Dtos;

namespace simpleEtl.Application.Ports.Repositories
{
    public interface IResearchRepository
    {
        Task<IEnumerable<ResearchObject>> GetResearchObjectsAsync();
    }
}