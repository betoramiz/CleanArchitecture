using Backend.Application.Data;
using DomainCourse = Backend.Domain.Course;

namespace Backend.Application.Features.Course.Create;

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

