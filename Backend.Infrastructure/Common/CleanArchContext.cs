using Backend.Application.Data;
using Backend.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Common;

public class CleanArchContext: DbContext ,ICleanArchitectureContext
{
    public CleanArchContext(DbContextOptions<CleanArchContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchContext).Assembly);
    }

    public DbSet<Domain.Course.Course> Courses { get; set; }
}