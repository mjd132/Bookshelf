using FluentValidation;

namespace Bookshelf.Application.Features.Book.Queries.GetAllBook;

public class GetBookQueryValidator : AbstractValidator<GetBookQuery>
{
    public GetBookQueryValidator()
    {
        RuleFor(p=>p.PageSize).GreaterThan(1).LessThan(50);
        RuleFor(p=>p.PageNumber).GreaterThan(0);
        
    }

}
