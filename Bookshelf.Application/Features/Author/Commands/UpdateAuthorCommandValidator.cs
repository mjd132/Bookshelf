using FluentValidation;

namespace Bookshelf.Application.Features.Author.Commands;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Family).NotEmpty();
    }
}