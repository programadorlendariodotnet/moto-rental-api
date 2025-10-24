using FluentResults;
using Shared.Extensions;
using Shared.Identifies.Contexts;
using Shared.Results.Errors.Default;

namespace Domain.Models.DeliveryPersonAggregate.ValueObjects;

public class CnpjValue(string value)
{
    public const int FieldMinLength = 1;
    public const int FieldMaxLength = 50;

    public string Value { get; } = value;

    private static Result<bool> IsValidNotEmpty(string value)
    {
        return value.IsValid();
    }

    private static Result<bool> IsValidLength(string value)
    {
        return value.Length.IsBetween(FieldMinLength, FieldMaxLength);
    }

    private static Result Validate(string value, string entity)
    {
        const string fieldName = "cnpj";

        if (!IsValidNotEmpty(value).Value)
            return new EmptyFieldError(
                entity,
                fieldName,
                ContextType.Domain
            );

        if (!IsValidLength(value).Value)
            return new InvalidLengthError(
                entity,
                fieldName,
                value,
                FieldMinLength,
                FieldMaxLength,
                ContextType.Domain);

        return Result.Ok();
    }

    public static Result<CnpjValue> Create(string reasonValue, string entity)
    {
        var isValid = Validate(reasonValue, entity);
        return isValid.IsFailed ? isValid : new CnpjValue(reasonValue);
    }
}