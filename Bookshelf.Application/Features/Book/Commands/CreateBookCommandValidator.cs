using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;

namespace Bookshelf.Application.Features.Book.Commands;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandValidator(IBookRepository bookRepository)
    {   
        _bookRepository = bookRepository;

        RuleFor(p => p.Title).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد.");

        RuleFor(q=>q).MustAsync(BookTitleUnique).WithMessage("this title is repetitive");
        
    }

    private async Task<bool> BookTitleUnique(CreateBookCommand book, CancellationToken token)
    {
        return await _bookRepository.IsTitleUnique(book.Title);
    }
}
