using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ProfilesOperations;

public class GetProfilesQueryResponse
{
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string UserName { get; set; }
     public string Image { get; set; }
     public ICollection<Photo> Photos { get; set; }
}
