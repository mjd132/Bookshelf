using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;

namespace Bookshelf.Application.Features.Book.Commands;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;

        RuleFor(p => p.Title).NotEmpty();
        RuleFor(q => q).MustAsync(BookTitleUnique).WithMessage("Title is repetitive");
        RuleFor(c=>c.PublisherId).GreaterThan(0);
        //todo : ISBN validator


    }
    private async Task<bool> BookTitleUnique(CreateBookCommand command, CancellationToken token)
    {
        var res = await _bookRepository.IsTitleUnique(command.Title);

        return !res;
    }

}
