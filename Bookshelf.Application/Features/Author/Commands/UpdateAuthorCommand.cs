using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Features.Author.Commands;

public class UpdateAuthorCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;

}

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IValidator<UpdateAuthorCommand> _validator;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IValidator<UpdateAuthorCommand> validator, IAuthorRepository authorRepository, IMapper mapper)
    {
        _validator = validator;
        _authorRepository = authorRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Domain.Entities.Author>(request);

        await _authorRepository.UpdateAsync(author);

        return Unit.Value;
    }
}
