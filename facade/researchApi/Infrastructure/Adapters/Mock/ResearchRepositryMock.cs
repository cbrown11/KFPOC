
using researchApi.Application.Models.External.Dtos;
using researchApi.Application.Ports.Repositories;

namespace researchApi.Adapters
{
    public class ResearchRepositryMock : IResearchRepositry
    {
        public async Task<IEnumerable<ResearchObject>> GetResearchObjectsAsync()
        {
            return new List<ResearchObject>{
                new ResearchObject { Id = 1, Name="Test 1 Name Mock"},
                new ResearchObject { Id = 2, Name="Test 2 Name Mock"},
                new ResearchObject { Id = 3, Name="Test 3 Name Mock"}
            };
        }
    }
}