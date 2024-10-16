using TesteCaixa.Api.Repositories;
using TesteCaixa.Api.ServiceDomain;

namespace TesteCaixa.Api
{
    public static class ServicesApi
    {
        public static void AddContainer(this IServiceCollection services)
        {            
            services.AddTransient<IBoxRepository, BoxRepository>();
            services.AddTransient<IBoxCalculateDimensionService, BoxCalculateDimensionService>();
        }
    }
}
