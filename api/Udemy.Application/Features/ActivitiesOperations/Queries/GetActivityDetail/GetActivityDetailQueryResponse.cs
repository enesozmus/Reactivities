using Udemy.Application.Profiles;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivityDetailQueryResponse
{
     public Guid Id { get; set; }
     public string Title { get; set; }
     public DateTime Date { get; set; }
     public string Description { get; set; }
     public string Category { get; set; }
     public string City { get; set; }
     public string Venue { get; set; }
     public bool IsCancelled { get; set; }

     public string? HostUsername { get; set; }
     public ICollection<Profile> Attendees { get; set; }
}
