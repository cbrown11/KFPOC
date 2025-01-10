using researchApi.Adapters;
using researchApi.Application.Ports.Repositories;
using researchApi.Infrastructure.Adapters.SQL;
namespace researchApi.Infrastructure.Adapters
{
    public static  class ServiceCollectionExtension
    {
        public static void RegisterMockServices(this IServiceCollection services)
        {
            services.AddScoped<IResearchRepositry, ResearchRepositryMock>();
        }   

        public static void RegisterServices(this IServiceCollection services)
        {
             services.AddSingleton<DapperContext>(); 
             services.AddScoped<IResearchRepositry, ResearchRepositryAzureSQL>();
        }          
    }
}