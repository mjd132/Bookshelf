using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using Bookshelf.Application.Features.Author.Queries.GetAllAuthors;
using Bookshelf.Application.Features.Publisher.Queries.GetAllPublishers;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

namespace Bookshelf.Application.Features.Book.Commands;

public class UpdateBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public ICollection<AuthorDto>? Authors { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int PagesCount { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public int? PublisherId { get; set; }
    //public PublisherDto? Publisher { get; set; }
    public float Price { get; set; }
}

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IValidator<UpdateBookCommand> _validator;
    public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository, IValidator<UpdateBookCommand> validator)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {

        var bookForUpdate = _mapper.Map<Domain.Entities.Book>(request);

        await _bookRepository.UpdateBookWithAuthorsAsync(bookForUpdate);
       
        return Unit.Value;
    }
}
