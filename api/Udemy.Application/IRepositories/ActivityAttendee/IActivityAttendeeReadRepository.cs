using System.Linq.Expressions;
using Udemy.Application.Features.ProfilesOperations;
using Udemy.Domain.Entities;

namespace Udemy.Application.IRepositories;
public interface IActivityAttendeeReadRepository : IReadRepository<ActivityAttendee>
{
     Task<IQueryable<GetUserActivitiesQueryResponse>> GetUserActivities(Expression<Func<ActivityAttendee, bool>> predicate = null);
}
