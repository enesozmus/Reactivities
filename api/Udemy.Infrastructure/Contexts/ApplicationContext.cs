using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Configurations;
using Udemy.Domain.Entities;

namespace Udemy.Infrastructure.Contexts;

public class ApplicationContext : IdentityDbContext<AppUser, AppRole, Guid>
{
     public ApplicationContext(DbContextOptions options) : base(options) { }

     #region Entities

     public DbSet<Activity> Activities { get; set; }
     public DbSet<ActivityAttendee> ActivityAttendees { get; set; }
     public DbSet<Photo> Photos { get; set; }

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
          modelBuilder.ApplyConfiguration(new AppUserConfiguration());
          modelBuilder.ApplyConfiguration(new ActivityConfiguration());

          #region many to many

          modelBuilder.Entity<ActivityAttendee>(x => x.HasKey(aa => new { aa.AppUserId, aa.ActivityId }));

          modelBuilder.Entity<ActivityAttendee>()
              .HasOne(u => u.AppUser)
              .WithMany(a => a.Activities)
              .HasForeignKey(aa => aa.AppUserId);

          modelBuilder.Entity<ActivityAttendee>()
              .HasOne(u => u.Activity)
              .WithMany(a => a.Attendees)
              .HasForeignKey(aa => aa.ActivityId);

          #endregion

          base.OnModelCreating(modelBuilder);
     }

     #endregion
}
