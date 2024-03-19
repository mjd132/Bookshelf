using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Models;
using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Features.Author.Queries.GetAllAuthors;

public record GetAuthorQuery(int PageNumber, int PageSize) : IRequest<PaginatedList<AuthorDto>>;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, PaginatedList<AuthorDto>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IValidator<PaginatedList<Domain.Entities.Author>> _validator;
    private readonly IMapper _mapper;

    public GetAuthorQueryHandler(IAuthorRepository authorRepository, IValidator<PaginatedList<Domain.Entities.Author>> validator, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<PaginatedList<AuthorDto>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {

        var authors = await _authorRepository.GetWithPaginationAync(request.PageNumber, request.PageSize).IsValidPaginationAsync(_validator, cancellationToken);

        // convert to author dto
        var authorsDto = _mapper.Map<PaginatedList<AuthorDto>>(authors);

        // return data
        return authorsDto;

    }
}
