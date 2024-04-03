using FluentValidation;

namespace Bookshelf.Application.Features.Publisher.Commands;

public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
{
    public UpdatePublisherCommandValidator()
    {
        RuleFor(p=>p.Name).NotEmpty();
        RuleFor(p=>p.Id).NotEmpty();
    }
}