using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Features.Author.Commands;

public class CreateAuthorCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;

}
public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IValidator<CreateAuthorCommand> _validator;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IValidator<CreateAuthorCommand> validator, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Domain.Entities.Author>(request);

        await _authorRepository.CreateAsync(author);

        return author.Id;

    }
}
