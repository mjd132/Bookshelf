using FluentValidation;

namespace Bookshelf.Application.Features.Book.Queries.GetAllBook;

public class GetBookQueryValidator : AbstractValidator<GetBookQuery>
{
    public GetBookQueryValidator()
    {
        RuleFor(p=>p.PageSize).GreaterThan(1).LessThan(50).WithMessage("{PropertyName} should be greater than 1 and less than 50 .");
    }
}
