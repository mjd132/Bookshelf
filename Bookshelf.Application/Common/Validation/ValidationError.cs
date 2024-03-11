namespace Bookshelf.Application.Common.Validation;

public class ValidationError
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }

    public ValidationError(string propertyName, string errorMessage)
    {
        ErrorMessage = errorMessage;
        PropertyName = propertyName;
    }
}
