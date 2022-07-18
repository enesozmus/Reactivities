using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Security;

public class IsHostRequirement : IAuthorizationRequirement { }

public class IsHostRequirementHandler : AuthorizationHandler<IsHostRequirement>
{
     private readonly ApplicationContext _context;
     private readonly IHttpContextAccessor _accessor;

     public IsHostRequirementHandler(ApplicationContext dbContext, IHttpContextAccessor accessor)
     {
          _context = dbContext;
          _accessor = accessor;
     }

     protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsHostRequirement requirement)
     {
          var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
          if (userId == null) return Task.CompletedTask;

          var activityId = Guid.Parse(_accessor.HttpContext?.Request.RouteValues
                .SingleOrDefault(x => x.Key == "id").Value?.ToString());

          var attendee = _context.ActivityAttendees
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.AppUserId.ToString() == userId && x.ActivityId == activityId)
                .Result;

          if (attendee == null) return Task.CompletedTask;

          if (attendee.IsHost) context.Succeed(requirement);

          return Task.CompletedTask;
     }
}
