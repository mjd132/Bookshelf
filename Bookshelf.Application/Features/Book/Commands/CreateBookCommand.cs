using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using MediatR;

namespace Bookshelf.Application.Features.Book.Commands;

public class CreateBookCommand : IRequest<int>
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? PublishedDate { get; set; }
    //public ICollection<Author>? Authors { get; set; }
    public string? ImageUrl { get; set; }
    public int? PagesCount { get; set; }
    public string? ISBN { get; set; }
    public string? Language { get; set; }
    //public int? PublisherId { get; set; }
    //public Publisher? Publisher { get; set; }
    public float? Price { get; set; }
}

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        //vaildate

        //convert to domain entity object 
        var book = _mapper.Map<Domain.Entities.Book>(request);
        //add to database
        await _bookRepository.CreateAsync(book);
        //return record id
        return book.Id;
    }
}