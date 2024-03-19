using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Common.Validation;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = await Task.WhenAll
            (
            _validators.Select(v => v.ValidateAsync(context))
            );

        var errors = validationFailures
            .Where(vresult => !vresult.IsValid)
            .SelectMany(vresult => vresult.Errors)
            .Select(vf => new ValidationError(vf.PropertyName, vf.ErrorMessage));

        if (errors.Any())
        {
            throw new Exceptions.ValidationException(errors);
        }
        var response = await next();

        return response;

    }
}
