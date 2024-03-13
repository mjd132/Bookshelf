using Bookshelf.Application.Common.Validation;

namespace Bookshelf.Application.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<ValidationError> Errors { get; }
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }
    public ValidationException(IEnumerable<ValidationError> errors,int StatusCode)
    {
        Errors = errors;
    }
    public ValidationException(IEnumerable<ValidationError> errors,string StatusCode)
    {
        Errors = errors;
    }
}