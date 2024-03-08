using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using MediatR;

namespace Bookshelf.Application.Features.Book.Commands;

public class UpdateBookCommand : IRequest<Unit>
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

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Domain.Entities.Book>(request);

        await _bookRepository.UpdateAsync(book);
        
        return Unit.Value;
    }
}