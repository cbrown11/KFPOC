
using simpleEtl.Application.Automapper.Profiles;

namespace simpleEtl.Application
{
    public static  class ServiceCollectionExtension
    {
        public static void AddApplicationAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(LoaderDtosToExtractorProfile));
        }          
    }
}