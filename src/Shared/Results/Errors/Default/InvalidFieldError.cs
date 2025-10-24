using Shared.Identifies.Contexts;
using Shared.Messages;
using Shared.Results.Errors.Base;

namespace Shared.Results.Errors.Default;

public class InvalidFieldError(
    string entity,
    string fieldName,
    string fieldValue,
    ContextType type) : BadRequestFieldsError(
    DefaultErrorMessageKeys.InvalidFieldsMessageKey,
    type,
    entity,
    new Dictionary<string, object> { { fieldName, fieldValue } }
);