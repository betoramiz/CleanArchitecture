using Clean.Application.Data;
using MediatR;
using ErrorOr;
using FluentValidation;
using DomainCourse = Clean.Domain.Course;

namespace Clean.Application.Course;

public class Create
{
    public record Command(string Name) : IRequest<ErrorOr<Response>>;

    public record Response(int Id);

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }

    public class CommandHandler : IRequestHandler<Command, ErrorOr<Response>>
    {
        private readonly ICleanArchitectureContext _context;
        public CommandHandler(ICleanArchitectureContext context) => _context = context;

        public async Task<ErrorOr<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validator = new CommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new ErrorOr<Response>();
            
            var newCourse = DomainCourse.Course.Create(request.Name);
            
            _context.Courses.Add(newCourse.Value);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response(newCourse.Value.Id);
        }
    }
}