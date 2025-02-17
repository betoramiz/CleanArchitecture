using FluentValidation;

namespace Backend.Application.Features.Course.Create;

internal class CommandValidator : AbstractValidator<Command>
{
    public CommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}