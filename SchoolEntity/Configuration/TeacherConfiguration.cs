using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEntity.Models;

namespace SchoolEntity.Configuration
{
    public class TeacherConfiguration
        : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Subject).IsRequired().HasMaxLength(45);
        }
    }
}
