using Microsoft.AspNetCore.Identity;

namespace Udemy.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string? Bio { get; set; }

     // many to many
     public ICollection<ActivityAttendee> Activities { get; set; }
     // many
     public ICollection<Photo> Photos { get; set; }
     public ICollection<UserFollowing> Followings { get; set; }
     public ICollection<UserFollowing> Followers { get; set; }
}
