using Backend.Application.Common.Interfaces;
using Backend.Infrastructure.Common;
using Microsoft.Extensions.Options;

namespace Backend.Infrastructure.Persistance.Repositories;

public class SomeRepository(IOptions<ConnectionStringOptions> options) : Repository(options), ISomeRepository
{
    public Task GetSomeDataAsync()
    {
        using var connection = CreateConnection();
        throw new NotImplementedException();
    }
}