namespace Clean.Domain.Course;

using ErrorOr;

public class Course
{
    public int Id { get; private set; }
    public string? Name { get; private set; }

    public static ErrorOr<Course> Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            return new ErrorOr<Course>();
        
        return new Course
        {
            Name = name
        };
    }
}