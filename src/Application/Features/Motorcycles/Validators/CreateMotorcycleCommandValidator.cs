using Application.Features.Motorcycles.Commands.CreateMotorcycle;
using Domain.Models.MotorcycleAggregate.ValueObjects;
using Domain.Models.Shared.ValueObjects;
using FluentValidation;

namespace Application.Features.Motorcycles.Validators;

public class CreateMotorcycleCommandValidator : AbstractValidator<CreateMotorcycleCommand>
{
    public CreateMotorcycleCommandValidator()
    {
        RuleFor(x => x.Year)
            .GreaterThan(1990)
            .LessThanOrEqualTo(DateTime.UtcNow.Year + 1)
            .WithName(x => nameof(x.Year));

        RuleFor(x => x.Model)
            .NotEmpty()
            .NotNull()
            .MinimumLength(ModelValue.FieldMinLength)
            .MaximumLength(ModelValue.FieldMaxLength)
            .WithName(x => nameof(x.Model));

        RuleFor(x => x.Plate)
            .NotEmpty()
            .NotNull()
            .MinimumLength(PlateValue.FieldMinLength)
            .MaximumLength(PlateValue.FieldMaxLength)
            .WithName(x => nameof(x.Plate));
    }
}