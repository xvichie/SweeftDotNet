using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEntity.Models;

namespace SchoolEntity.Configuration
{
    public class PupilConfiguration
        : IEntityTypeConfiguration<Pupil>
    {
        public void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Grade).IsRequired().HasMaxLength(5);
            builder.HasMany(x => x.Teachers)
                .WithMany(x => x.Pupils);
        }
    }
}
