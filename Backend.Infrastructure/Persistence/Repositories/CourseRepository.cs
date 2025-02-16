using Backend.Application.Common.Interfaces;
using Backend.Application.Features.Course;
using Backend.Infrastructure.Common;
using Dapper;
using ErrorOr;
using Microsoft.Extensions.Options;

namespace Backend.Infrastructure.Persistence.Repositories;

public class CourseRepository(IOptions<ConnectionStringOptions> options) : Repository(options), ICourseRepository
{
    public async Task<ErrorOr<GetCourseById.Response>> GetSomeDataAsync()
    {
        var sqlQuery = "SELECT Name FROM dbo.Courses WHERE Id = @Id";
        using var connection = CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<GetCourseById.Response>(sqlQuery, new { Id = 1 });
        Console.WriteLine(result);
        return result;
    }
}