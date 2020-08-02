using Locar.Domain.Repositories;
using Locar.Infra.Data.Configurations;
using Locar.Infra.Data.Contexts;
using Locar.Infra.Data.Interfaces;
using Locar.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Locar.Infra.Data.Extensions
{
    public static class InfraDataSetup
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<LocarMongoDatabaseSettings>(
                configuration.GetSection(nameof(LocarMongoDatabaseSettings)));

            services.AddSingleton<ILocarMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<LocarMongoDatabaseSettings>>().Value);

            return services;
        }

        public static IServiceCollection AddContexts(this IServiceCollection services)
        {
            services.AddSingleton<ILocarMongoContext, LocarMongoContext>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            return services;
        }
    }
}