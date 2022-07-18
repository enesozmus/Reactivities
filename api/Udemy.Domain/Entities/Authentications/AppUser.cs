using Microsoft.AspNetCore.Identity;

namespace Udemy.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
     public string FirstName { get; set; }
     public string LastName { get; set; }

     // many to many
     public ICollection<ActivityAttendee> Activities { get; set; }
     // many
     public ICollection<Photo> Photos { get; set; }
}
