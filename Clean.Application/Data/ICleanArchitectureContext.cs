using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Data;

public interface ICleanArchitectureContext
{
    public DbSet<Domain.Course.Course> Courses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}