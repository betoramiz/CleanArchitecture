using FluentValidation;
using FluentValidation.Results;

namespace Backend.Application.Common.Validation;

public static class FluentValidatorExtension
{
    public static bool IsNotValid<T>(this IValidator<T> validator, T request, out List<ValidationFailure> errors) where T : class
    {
        var result = validator.Validate(request);
        errors = [];

        if (result.IsValid) 
            return false;
        
        errors = result.Errors;
        return true;

    }
}