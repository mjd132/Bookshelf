using FluentValidation;

namespace Bookshelf.Application.Features.Author.Commands;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Family).NotEmpty();

    }
}