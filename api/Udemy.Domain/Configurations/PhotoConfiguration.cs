using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Domain.Entities;

namespace Udemy.Domain.Configurations;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
     public void Configure(EntityTypeBuilder<Photo> builder)
     {
          builder.Property(x => x.PhotoId).IsRequired();
          builder.Property(x => x.Url).IsRequired();
     }
}
