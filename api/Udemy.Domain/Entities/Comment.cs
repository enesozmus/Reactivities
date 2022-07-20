namespace Udemy.Domain.Entities;

public class Comment : BaseEntity
{
     public string Body { get; set; }
     public Guid AppUserId { get; set; }
     public AppUser Author { get; set; }
     public Activity Activity { get; set; }
}
