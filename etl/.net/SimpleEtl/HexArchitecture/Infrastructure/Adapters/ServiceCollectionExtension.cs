
using researchApi.Adapters;
using simpleEtl.Application.Ports.Repositories;
using simpleEtl.Infrastructure.Adapters.Loaders;
using simpleEtl.Infrastructure.Adapters.Extractors;

namespace researchApi.Infrastructure.Adapters
{
    public static  class ServiceCollectionExtension
    {
        public static void RegisterExtractorMockServices(this IServiceCollection services)
        {
            services.AddScoped<IResearchRepository, ResearchRepositryMock>();
        }   

        public static void RegisterExtractorServices(this IServiceCollection services)
        {
             services.AddSingleton<ResearchContext>(); 
             services.AddScoped<IResearchRepository, ResearchRepositoryAzureSQL>();
        }   
        public static void RegisterLoaderServices(this IServiceCollection services)
        {
             services.AddSingleton<PropertyContext>(); 
             services.AddScoped<IPropertyRepository, PropertyRepositoryPostgre>();
        }         

    }
}