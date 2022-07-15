using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Domain.Entities;

namespace Udemy.Domain.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
     public void Configure(EntityTypeBuilder<AppUser> builder)
     {
          builder.Property(x => x.FirstName).IsRequired().HasMaxLength(15);
          builder.Property(x => x.LastName).IsRequired().HasMaxLength(15);
          builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
          builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);

          #region SeedData

          var hasher = new PasswordHasher<AppUser>();

          var FirstID = new Guid();
          var SecondID = new Guid();

          var user1 = new AppUser() { Id = new Guid("b01b3c37-5b75-47e4-8a7d-da6815e412d7"), FirstName = "Enes", LastName = "Ozmus", Email = "enes@seeddata.com", EmailConfirmed = true, NormalizedEmail = " ENES@SEEDDATA.COM", UserName = "enesozmus", NormalizedUserName = "ENESOZMUS", PasswordHash = hasher.HashPassword(null, "Customer1*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user2 = new AppUser() { Id = new Guid("7e264482-e439-475c-86c0-dbf687411cc7"), FirstName = "Umay", LastName = "Zengin", Email = "umay@seeddata.com", EmailConfirmed = true, NormalizedEmail = "UMAY@SEEDDATA.COM", UserName = "umayzengin", NormalizedUserName = "UMAYZENGIN", PasswordHash = hasher.HashPassword(null, "Customer2*123"), SecurityStamp = Guid.NewGuid().ToString("D") };

          builder.HasData(user1, user2);

          #endregion
     }
}
