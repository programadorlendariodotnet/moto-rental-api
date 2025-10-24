using Shared.Identifies.Contexts;
using Shared.Messages;
using Shared.Results.Errors.Base;

namespace Shared.Results.Errors.Default;

public class InvalidMinValueError(
    string entity,
    string fieldName,
    string fieldValue,
    double fieldValueMinLimit,
    ContextType type)
    : BadRequestFieldsError(DefaultErrorMessageKeys.InvalidMinValueMessageKey,
        type,
        entity,
        new Dictionary<string, object>
        {
            {fieldName, fieldValue},
            {$"{fieldName}.min-value", fieldValueMinLimit}
        });