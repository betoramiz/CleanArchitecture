using ErrorOr;

namespace Clean.Domain.Course;

public static class CourseErrors
{
    public static Error CourseNameEmpty = Error.Validation("Course.CourseNameEmpty", "Course Name is Empty");
}