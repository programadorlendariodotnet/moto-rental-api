using Application.Configurations.Factories;
using Application.Features.Motorcycles.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.Extensions;

public static class ValidatorConfig
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateMotorcycleCommandValidator>();
        services.AddScoped<IValidatorGeneric, ValidatorFactory>();

        return services;
    }
}