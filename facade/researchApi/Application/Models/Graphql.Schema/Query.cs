
namespace researchApi.Schema
{
    public class Query
    {
         public async Task<IEnumerable<Asset>>  GetAsset([Service] Application.Ports.Repositories.IResearchRepositry researchRepositry)
         {
            var  researchObjects = await researchRepositry.GetResearchObjectsAsync(); 
            // Could use Automapper to map external Dto retreived to graphql schema 
            return researchObjects.Select(x=> new Asset{
                Id=x.Id,
                Name = x.Name
            });
         } 
    }
}