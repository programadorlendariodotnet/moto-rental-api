using Shared.Identifies.Contexts;
using Shared.Messages;
using Shared.Results.Errors.Base;

namespace Shared.Results.Errors.Default;

public class InvalidLengthError(
    string entity,
    string fieldName,
    string fieldValue,
    double fieldLengthMinLimit,
    double fieldLengthMaxLimit,
    ContextType type) : BadRequestFieldsError(DefaultErrorMessageKeys.InvalidLengthMessageKey,
    type,
    entity,
    new Dictionary<string, object>
    {
        {fieldName, fieldValue},
        {$"{fieldName}.min-value", fieldLengthMinLimit},
        {$"{fieldName}.max-value", fieldLengthMaxLimit}
    });