using Bookshelf.Application.Common.Validation;

namespace Bookshelf.Application.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<ValidationError> Errors { get; }
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }
}