using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Features.Author.Queries.GetAllAuthors;
using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Features.Book.Commands;

public class CreateBookCommand : IRequest<int>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public ICollection<AuthorDto>? Authors { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int PagesCount { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    //public int? PublisherId { get; set; }
    //public Publisher? Publisher { get; set; }
    public float Price { get; set; }
}

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IValidator<CreateBookCommand> _validator;

    public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository, IValidator<CreateBookCommand> validator)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _validator = validator;
    }
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        //convert to domain entity object
        var book = _mapper.Map<Domain.Entities.Book>(request);

        //add authors to book
        book.Authors = await _bookRepository.UpdateRelatedEntityAsync(null,book.Authors);

        //add to database
        await _bookRepository.CreateAsync(book);

        //return record id
        return book.Id;
    }
}