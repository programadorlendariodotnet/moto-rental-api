using FluentResults;
using Shared.Extensions;
using Shared.Identifies.Contexts;
using Shared.Results.Errors.Default;

namespace Domain.Models.MotorcycleAggregate.ValueObjects.DeliveryPerson;

public class ImageUrlValue(string value)
{
    public const int FieldMinLength = 1;
    public const int FieldMaxLength = 50;

    public string Value { get; } = value;

    private static Result<bool> IsValidLength(string value)
    {
        return value.Length.IsBetween(FieldMinLength, FieldMaxLength);
    }

    private static Result Validate(string value, string entity)
    {
        const string fieldName = "image url";

        if (string.IsNullOrEmpty(value))
            return Result.Ok();

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

    public static Result<ImageUrlValue> Create(string reasonValue, string entity)
    {
        var isValid = Validate(reasonValue, entity);
        return isValid.IsFailed ? isValid : new ImageUrlValue(reasonValue);
    }
}