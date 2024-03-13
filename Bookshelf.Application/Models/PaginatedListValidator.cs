using FluentValidation;

namespace Bookshelf.Application.Models;

public class PaginatedListValidator<T> :AbstractValidator<PaginatedList<T>> where T : class
{
    public PaginatedListValidator()
    {
        RuleFor(p=>p.PageNumber).LessThanOrEqualTo(p=>p.TotalPages).GreaterThan(0);
        RuleFor(p=>p.PageSize).InclusiveBetween(1,20);
    }
}