namespace Backend.Application.Features.Course.GetCourseById;

public record Query(int Id) : IRequest<ErrorOr<Response>>;