using Backend.Application.Common.Interfaces;

namespace Backend.Application.Features.Course;

public interface ICourseRepository: IRepository
{
    public Task<ErrorOr<GetCourseById.Response>> GetSomeDataAsync();
}