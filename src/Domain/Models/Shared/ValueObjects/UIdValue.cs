using FluentResults;
using Shared.Extensions;
using Shared.Identifies.Contexts;
using Shared.Results.Errors.Default;

namespace Domain.Models.Shared.ValueObjects;

public class UIdValue(string value)
{
    public const int FieldMinLength = 1;
    public const int FieldMaxLength = 150;

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
        const string fieldName = "uId";

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

    public static Result<UIdValue> Create(string uIdValue, string entity)
    {
        var isValid = Validate(uIdValue, entity);
        return isValid.IsFailed ? isValid : new UIdValue(uIdValue);
    }
}