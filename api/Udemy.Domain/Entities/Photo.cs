namespace Udemy.Domain.Entities;

public class Photo : BaseEntity
{
     public string PhotoId { get; set; }
     public string Url { get; set; }
     public bool IsMain { get; set; }
     public Guid AppUserId { get; set; }
     public AppUser AppUser { get; set; }
}
