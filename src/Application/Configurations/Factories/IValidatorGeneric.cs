using FluentValidation;

namespace Application.Configurations.Factories;

public interface IValidatorGeneric
{
    IValidator<T>? GetValidator<T>();
}