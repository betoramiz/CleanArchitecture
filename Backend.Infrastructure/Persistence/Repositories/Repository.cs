using System.Data;
using Backend.Infrastructure.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Backend.Infrastructure.Persistence.Repositories;

public class Repository(IOptions<ConnectionStringOptions> options)
{
    internal IDbConnection CreateConnection()
    {
        return new SqlConnection(options.Value.ConnectionString);
    }
}