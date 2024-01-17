using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UKRainfall.Application.Contracts.Infrastructure;
using UKRainfall.Infrastructure.Reading;

namespace UKRainfall.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddTransient<IReadingService, ReadingService>();            

            return services;
        }
    }
}
