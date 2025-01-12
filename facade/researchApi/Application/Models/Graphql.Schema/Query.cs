
using AutoMapper;

namespace researchApi.Schema
{
    public class Query
    {
         public async Task<IEnumerable<Asset>> GetAssets([Service] Application.Ports.Repositories.IResearchRepositry researchRepositry, IMapper mapper)
         {
            var  researchObjects = await researchRepositry.GetResearchObjectsAsync(); 
            // Could use Automapper to map external Dto retreived to graphql schema or just a simple Select
            // Automapper probably better has reduce the logic in the resolver
            return mapper.Map<IEnumerable<Asset>>(researchObjects);
            /*  
            return researchObjects.Select(x=> new Asset{Id=x.Id, Name = x.Name});
            */   
         } 
    }
}