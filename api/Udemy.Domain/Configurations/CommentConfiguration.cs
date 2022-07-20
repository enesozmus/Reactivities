using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Domain.Entities;

namespace Udemy.Domain.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
     public void Configure(EntityTypeBuilder<Comment> builder)
     {
          builder.Property(x => x.Body).HasMaxLength(300).IsRequired();
     }
}
