using Shared.Identifies.Contexts;
using Shared.Messages;
using Shared.Results.Errors.Base;

namespace Shared.Results.Errors.Default;

public class EmptyFieldError(string entity, string fieldName, ContextType type)
    : BadRequestFieldsError(DefaultErrorMessageKeys.EmptyFieldMessageKey, type, entity,
        new Dictionary<string, object> {{fieldName, string.Empty}});