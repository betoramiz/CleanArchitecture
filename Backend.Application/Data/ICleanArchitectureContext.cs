using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Data;

public interface ICleanArchitectureContext
{
    public DbSet<Domain.Course.Course> Courses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}