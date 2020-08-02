using Locar.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locar.Infra.Ioc.Extensions
{
    public static class InfraIocExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddConfigurations(configuration)
                .AddContexts()
                .AddRepositories();
        }
    }
}
