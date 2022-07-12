using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;

namespace Udemy.Infrastructure.Contexts;

public class ApplicationContext : IdentityDbContext<AppUser, AppRole, Guid>
{
     public ApplicationContext(DbContextOptions options) : base(options) { }

     #region Entities

     public DbSet<Activity> Activities { get; set; }

     #endregion

     #region Customized SaveChangesAsync

     public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
     {
          foreach (var entry in ChangeTracker.Entries<BaseEntity>())
          {
               switch (entry.State)
               {
                    case EntityState.Added:
                         entry.Entity.CreatedDate = DateTime.Now;

                         break;
                    case EntityState.Modified:
                         entry.Entity.LastModifiedDate = DateTime.Now;
                         break;
               }
          }
          return base.SaveChangesAsync(cancellationToken);
     }

     #endregion

     #region OnModelCreating

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          base.OnModelCreating(modelBuilder);
     }

     #endregion
}
