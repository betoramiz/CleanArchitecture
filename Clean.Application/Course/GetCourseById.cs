using Clean.Application.Data;
using MediatR;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Course;

public class GetCourseById
{
    public record Query(int Id) : IRequest<ErrorOr<Response>>;

    public record Response(int Id, string Name);

    public class CommandHandler : IRequestHandler<Query, ErrorOr<Response>>
    {
        private readonly ICleanArchitectureContext _context;
        public CommandHandler(ICleanArchitectureContext context) => _context = context;

        public async Task<ErrorOr<Response>> Handle(Query request, CancellationToken cancellationToken)
        {
            var course = await _context
                .Courses
                .Where(course => course.Id == request.Id)
                .Select(c => new Response(c.Id, c.Name))
                .FirstOrDefaultAsync(cancellationToken);

            if (course is null)
                return CourseErrors.CourseNotFound;

            return course;
        }
    }
}