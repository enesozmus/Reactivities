using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;

namespace Udemy.Infrastructure.Contexts;

public class ApplicationContext : IdentityDbContext<AppUser, AppRole, Guid>
{
     public ApplicationContext(DbContextOptions options) : base(options) { }

     #region Entitis

     public DbSet<Activity> Activities { get; set; }

     #endregion

     #region OnModelCreating

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          base.OnModelCreating(modelBuilder);
     }

     #endregion
}
