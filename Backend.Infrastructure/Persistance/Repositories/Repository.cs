using System.Data;
using Backend.Infrastructure.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Backend.Infrastructure.Persistance.Repositories;

public class Repository(IOptions<ConnectionStringOptions> options)
{
    private readonly IOptions<ConnectionStringOptions> _options = options;
    
    internal IDbConnection CreateConnection()
    {
        return new SqlConnection(_options.Value.ConnectionString);
    }
}