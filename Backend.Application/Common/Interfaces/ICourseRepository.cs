using Backend.Application.Features.Course;

namespace Backend.Application.Common.Interfaces;

public interface ICourseRepository: IRepository
{
    public Task<ErrorOr<GetCourseById.Response>> GetSomeDataAsync();
}