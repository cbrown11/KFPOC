
using AutoMapper;
using simpleEtl.Application.Models.Loader.Dtos;
using simpleEtl.Application.Ports.Repositories;

namespace simpleEtl.Schema
{
    public class Mutation
    {
         public async Task<string> ProcessResearch([Service] 
            IResearchRepository researchRepositry, 
            IPropertyRepository propertyRepository, 
            IMapper mapper)
         {
            // Just demo purpose buy would at least extract this out to application service layer 
            // but would also send this on to Bus for it to handle and the logic to be there
            try
            {
               var  researchObjects = await researchRepositry.GetResearchObjectsAsync(); 
               var assets = mapper.Map<IEnumerable<Asset>>(researchObjects);
               await propertyRepository.Add(assets);
               return $"Insert or Update {assets.Count()} assets"; 
            }
            catch(Exception ex){
               return $"Failed to process Research: {ex.Message}.";
            }
         } 
    }
}