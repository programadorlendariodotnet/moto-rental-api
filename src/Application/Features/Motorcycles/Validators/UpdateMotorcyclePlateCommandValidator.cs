using Application.Features.Motorcycles.Commands.UpdateMotorcycle;
using Domain.Models.MotorcycleAggregate.ValueObjects;
using Domain.Models.Shared.ValueObjects;
using FluentValidation;

namespace Application.Features.Motorcycles.Validators;

public class UpdateMotorcyclePlateCommandValidator : AbstractValidator<UpdateMotorcycleCommand>
{
    public UpdateMotorcyclePlateCommandValidator()
    {
        RuleFor(x => x.UId)
            .NotEmpty()
            .NotNull()
            .MinimumLength(UIdValue.FieldMinLength)
            .MaximumLength(UIdValue.FieldMaxLength)
            .WithName(x => nameof(x.UId));

        RuleFor(x => x.Plate)
            .NotEmpty()
            .NotNull()
            .MinimumLength(PlateValue.FieldMinLength)
            .MaximumLength(PlateValue.FieldMaxLength)
            .WithName(x => nameof(x.Plate));
    }
}