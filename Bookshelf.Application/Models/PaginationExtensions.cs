using Bookshelf.Application.Common.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Application.Models;

public static class PaginationExtensions
{
    public static Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> queryable, int pageNumber, int pageSize) where T : class
    {
        return PaginatedList<T>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
    }

    public static async Task<PaginatedList<T>> IsValidPaginationAsync<T>(this Task<PaginatedList<T>> source, IValidator<PaginatedList<T>> validator, CancellationToken cancellationToken)
    {
        var paginatedList = await source;

        //var paginationValidator = new PaginationValidator<T>();

        var validationResult = await validator.ValidateAsync(paginatedList, cancellationToken);
        if (!validationResult.IsValid)
        {
            var validationErros = validationResult.Errors.Select(vr => new ValidationError(vr.PropertyName, vr.ErrorMessage));

            throw new Exceptions.ValidationException(validationErros);
        }


        return paginatedList;
    }
}

