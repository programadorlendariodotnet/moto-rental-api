using Shared.Identifies.Contexts;
using Shared.Messages;
using Shared.Results.Errors.Base;

namespace Shared.Results.Errors.Default;

public class EntityNotFoundError(string entity)
    : BadRequestFieldsError(DefaultErrorMessageKeys.EmptyFieldMessageKey, ContextType.Domain, entity);