using JayRide.Repository.Infrastructure;
using JayRide.Repository.Repository;
using JayRide.Service;
using JayRide.Service.Infrastructure;

namespace JayRide.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
          IConfiguration config)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }
     }
}
