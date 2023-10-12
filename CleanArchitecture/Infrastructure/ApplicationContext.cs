using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions options): base(options)
    {
    }
    
    public DbSet<Alumnos> Alumnos { get; set; }
}