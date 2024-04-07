using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;

namespace Bookshelf.Application.Features.Book.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;

        RuleFor(p => p.Title).NotEmpty();
        //todo: RuleFor(q => q).MustAsync(BookTitleUnique).WithMessage("Title is repetitive");
        RuleFor(p => p.Id).NotNull().NotEmpty();
        RuleFor(p=>p.PublisherId).GreaterThan(0);

    }

    //private async Task<bool> BookTitleUnique(UpdateBookCommand command, CancellationToken token)
    //{
    //    var res = await _bookRepository.IsTitleUnique(command.Title);

    //    return !res;
    //}



}