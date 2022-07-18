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

          var user1 = new AppUser() { Id = new Guid("b01b3c37-5b75-47e4-8a7d-da6815e412d7"), FirstName = "Enes", LastName = "Ozmus", Email = "enes@seeddata.com", EmailConfirmed = true, NormalizedEmail = " ENES@SEEDDATA.COM", UserName = "enesozmus", NormalizedUserName = "ENESOZMUS", PasswordHash = hasher.HashPassword(null, "Customer1*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user2 = new AppUser() { Id = new Guid("0f7d8c5f-95d3-4f6b-8c62-5abdcff93c28"), FirstName = "Umay", LastName = "Zengin", Email = "umay@seeddata.com", EmailConfirmed = true, NormalizedEmail = "UMAY@SEEDDATA.COM", UserName = "umayzengin", NormalizedUserName = "UMAYZENGIN", PasswordHash = hasher.HashPassword(null, "Customer2*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user3 = new AppUser() { Id = new Guid("bd7f1491-2ce9-4cb1-8646-28d896b7974f"), FirstName = "Selim", LastName = "Karaca", Email = "selim@seeddata.com", EmailConfirmed = true, NormalizedEmail = "SELIM@SEEDDATA.COM", UserName = "selimkaraca", NormalizedUserName = "SELIMKARACA", PasswordHash = hasher.HashPassword(null, "Customer3*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
          var user4 = new AppUser() { Id = new Guid("8892eb4c-8da6-4151-9a9b-e9987952c2eb"), FirstName = "Emine", LastName = "Yıldırım", Email = "emine@seeddata.com", EmailConfirmed = true, NormalizedEmail = "EMINE@SEEDDATA.COM", UserName = "emineyıldırım", NormalizedUserName = "EMINEYILDIRIM", PasswordHash = hasher.HashPassword(null, "Customer4*123"), SecurityStamp = Guid.NewGuid().ToString("D") };

          builder.HasData(user1, user2, user3, user4);

          #endregion
     }
}
