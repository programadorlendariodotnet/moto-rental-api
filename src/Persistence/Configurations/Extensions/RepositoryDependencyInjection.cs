using Domain.Contracts.DeliveryPersons;
using Domain.Contracts.Motorcycles;
using Domain.Contracts.Motorcycles.Generics;
using Domain.Contracts.Rentals;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.DeliveryPersons;
using Persistence.Repositories.Generics;
using Persistence.Repositories.Motorcycles;
using Persistence.Repositories.Rentals;
using Persistence.Repositories.UnitOfWork;

namespace Persistence.Configurations.Extensions;

public static class RepositoryDependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IMotorcycleReadRepository, MotorcycleReadRepository>();
        services.AddScoped<IMotorcycleWriteRepository, MotorcycleWriteRepository>();

        services.AddScoped<IDeliveryPersonReadRepository, DeliveryPersonReadRepository>();
        services.AddScoped<IDeliveryPersonWriteRepository, DeliveryPersonWriteRepository>();

        services.AddScoped<IRentalReadRepository, RentalReadRepository>();
        services.AddScoped<IRentalWriteRepository, RentalWriteRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}