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
     public DbSet<Comment> Comments { get; set; }

     public DbSet<UserFollowing> UserFollowings { get; set; }

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
          modelBuilder.ApplyConfiguration(new PhotoConfiguration());
          modelBuilder.ApplyConfiguration(new CommentConfiguration());

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

          modelBuilder.Entity<UserFollowing>(b =>
          {
               b.HasKey(k => new { k.ObserverId, k.TargetId });

               b.HasOne(o => o.Observer)
                   .WithMany(f => f.Followings)
                   .HasForeignKey(o => o.ObserverId)
                   .OnDelete(DeleteBehavior.NoAction);

               b.HasOne(o => o.Target)
                   .WithMany(f => f.Followers)
                   .HasForeignKey(o => o.TargetId)
                   .OnDelete(DeleteBehavior.NoAction);

          });

          #endregion

          base.OnModelCreating(modelBuilder);
     }

     #endregion
}
