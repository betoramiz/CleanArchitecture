using Microsoft.EntityFrameworkCore;

namespace Clean.Domain;

public class CleanArchContext: DbContext
{
    public CleanArchContext(DbContextOptions<CleanArchContext> options) : base(options)
    {
        
    }
    
    public DbSet<Course.Course> Courses { get; set; }
}