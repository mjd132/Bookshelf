namespace Bookshelf.Application.Exceptions;

public class BadRequest : Exception
{
    public BadRequest(string message) : base(message)
    {

    }
}
