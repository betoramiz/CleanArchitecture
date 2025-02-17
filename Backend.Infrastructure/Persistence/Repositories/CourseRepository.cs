using Backend.Application.Features.Course;
using Backend.Infrastructure.Common;
using Dapper;
using ErrorOr;
using Microsoft.Extensions.Options;
using Course = Backend.Application.Features.Course;

namespace Backend.Infrastructure.Persistence.Repositories;

public class CourseRepository(IOptions<ConnectionStringOptions> options) : Repository(options), ICourseRepository
{
    public async Task<ErrorOr<Course.GetCourseById.Response>> GetSomeDataAsync()
    {
        var sqlQuery = "SELECT Name FROM dbo.Courses WHERE Id = @Id";
        using var connection = CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Course.GetCourseById.Response>(sqlQuery, new { Id = 1 });
        Console.WriteLine(result);
        return result;
    }
}