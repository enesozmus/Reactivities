using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Domain.Entities;

namespace Udemy.Domain.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
     public void Configure(EntityTypeBuilder<Activity> builder)
     {
          builder.Property(x => x.Title).HasMaxLength(30).IsRequired();
          builder.Property(x => x.Category).HasMaxLength(30).IsRequired();
          builder.Property(x => x.Description).HasMaxLength(80).IsRequired();
          builder.Property(x => x.City).HasMaxLength(30).IsRequired();
          builder.Property(x => x.Venue).HasMaxLength(30).IsRequired();
     }
}
