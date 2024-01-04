using Clean.Domain.Common;
using Clean.Domain.Course.Events;

namespace Clean.Domain.Course;

using ErrorOr;

public class Course: Entity
{
    public int Id { get; private set; }
    public string? Name { get; private set; }

    public Course()
    {
        
    }

    private Course(string name)
    {
        Name = name;
    }

    public static ErrorOr<Course> Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            return new ErrorOr<Course>();


        var course = new Course(name);
     
        course.RaiseEvent(new CourseCreatedEvent(course.Id));
        return course;
    }
}