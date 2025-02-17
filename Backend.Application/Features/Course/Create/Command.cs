namespace Backend.Application.Features.Course.Create;

public record Command(string Name) : IRequest<ErrorOr<Response>>;