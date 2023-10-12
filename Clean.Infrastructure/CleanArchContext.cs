using Clean.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure;

public class CleanArchContext: DbContext ,ICleanArchitectureContext
{
    public CleanArchContext(DbContextOptions<CleanArchContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Course.Configuration());
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchContext).Assembly);
    }

    public DbSet<Domain.Course.Course> Courses { get; set; }
}