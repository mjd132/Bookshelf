using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Features.Book.Commands;

public class UpdateBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    //public ICollection<Author>? Authors { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int PagesCount { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    //public int? PublisherId { get; set; }
    //public Publisher? Publisher { get; set; }
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
        //validation
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        // mapping
        var book = _mapper.Map<Domain.Entities.Book>(request);

        // update database
        await _bookRepository.UpdateAsync(book);

        // return null
        return Unit.Value;
    }
}
