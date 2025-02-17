namespace Backend.Application.Features.Course.GetCourseById;

public class CommandHandler : IRequestHandler<Query, ErrorOr<Response>>
{
    private readonly ICourseRepository _repository;

    public CommandHandler(ICourseRepository repository) => _repository = repository;


    public async Task<ErrorOr<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetSomeDataAsync();

        return course;
    }
}