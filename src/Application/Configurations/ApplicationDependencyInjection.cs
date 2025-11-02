using Application.Configurations.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediator()
            .AddValidators();

        return services;
    }
}
