using GameTipsShop.Api.Application.Interfaces;
using GameTipsShop.Api.Infrastructure.Data;
using GameTipsShop.Api.Infrastructure.Repositories;
using GameTipsShop.SharedLibrary.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameTipsShop.Api.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            SharedServiceContainer.AddSharedServices<AdviceTypeDbContext>(services, config, config["MySerilog:FileName"]!);

            services.AddScoped<IAdviceTypeRepository, AdviceTypeRepository>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructurePolicy(this IApplicationBuilder app)
        {
            SharedServiceContainer.UseSharedPolices(app);
            return app;
        }
    }
}
