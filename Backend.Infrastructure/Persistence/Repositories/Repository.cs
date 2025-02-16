using System.Data;
using Backend.Application.Common.Interfaces;
using Backend.Infrastructure.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Backend.Infrastructure.Persistence.Repositories;

public class Repository(IOptions<ConnectionStringOptions> options): IRepository
{
    internal IDbConnection CreateConnection()
    {
        return new SqlConnection(options.Value.ConnectionString);
    }
}