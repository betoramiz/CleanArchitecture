using ErrorOr;
using FluentValidation.Results;

namespace Backend.Application.Common.Validation;

public static class ErrorExtension
{
    public static List<Error> Errors(this IEnumerable<ValidationFailure> errors) =>
        errors
            .Select(e => Error.Validation(code: e.PropertyName, description: e.ErrorMessage))
            .ToList(); 
}