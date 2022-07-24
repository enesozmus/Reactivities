namespace Udemy.Domain.Entities;

public class UserFollowing : BaseEntity
{
     public Guid ObserverId { get; set; }
     public AppUser Observer { get; set; }
     public Guid TargetId { get; set; }
     public AppUser Target { get; set; }
}
