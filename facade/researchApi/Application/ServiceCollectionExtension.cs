
using researchApi.Application.Automapper.Profiles;

namespace researchApi.Application
{
    public static  class ServiceCollectionExtension
    {
        public static void AddApplicationAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ExternalDtosToSchemaProfile));
        }          
    }
}