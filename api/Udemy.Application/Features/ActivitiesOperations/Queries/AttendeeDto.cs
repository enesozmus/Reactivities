namespace Udemy.Application.Features.ActivitiesOperations;

public class AttendeeDto
{
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string UserName { get; set; }
     public string? Image { get; set; }
     #region Following
     public bool Following { get; set; }
     public int FollowersCount { get; set; }
     public int FollowingCount { get; set; }
     #endregion
}
