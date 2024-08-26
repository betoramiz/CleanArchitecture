using Backend.Application.Data;
using Backend.Domain.Course.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Course.Events;

public class CourseCreatedEventHandler: INotificationHandler<CourseCreatedEvent>
{
    private readonly ICleanArchitectureContext _context;
    public CourseCreatedEventHandler(ICleanArchitectureContext context) => _context = context;

    public async Task Handle(CourseCreatedEvent notification, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == notification.CourseId, cancellationToken);
        
        // send Email to an admin
        Console.WriteLine("Send email to client");
    }
}