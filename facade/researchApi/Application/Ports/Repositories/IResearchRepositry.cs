
using researchApi.Application.Models.External.Dtos;

namespace researchApi.Application.Ports.Repositories
{
    public interface IResearchRepositry
    {
        Task<IEnumerable<ResearchObject>> GetResearchObjectsAsync();
    }
}