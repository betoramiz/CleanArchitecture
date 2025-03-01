using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainCourse = Backend.Domain.Course;

namespace Backend.Infrastructure.Persistence.Configurations;

public class CourseConfiguration: IEntityTypeConfiguration<DomainCourse.Course>
{
    public void Configure(EntityTypeBuilder<DomainCourse.Course> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
    }
}