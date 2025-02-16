using ErrorOr;

namespace Backend.Application.Features.Course;

public static class CourseErrors
{
    public static Error CourseNotFound = Error.NotFound("Course.NotFound", $"Course was not found");
}