using FluentValidation;

namespace Bookshelf.Application.Features.Publisher.Commands;

public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
{
    public CreatePublisherCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}