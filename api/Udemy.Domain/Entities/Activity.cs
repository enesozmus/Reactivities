namespace Udemy.Domain.Entities;

public class Activity : BaseEntity
{
     public string Title { get; set; }
     public string Description { get; set; }
     public DateTime Date { get; set; }
     public string Category { get; set; }
     public string City { get; set; }
     public string Venue { get; set; }
     public bool IsCancelled { get; set; }

     // many to many
     public ICollection<ActivityAttendee> Attendees { get; set; } = new List<ActivityAttendee>();
     // one to many
     public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
