using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Configurations.Extensions;

namespace Persistence.Configurations;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddRepositories();

        return services;
    }
}