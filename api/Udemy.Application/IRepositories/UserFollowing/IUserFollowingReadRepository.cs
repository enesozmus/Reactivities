using System.Linq.Expressions;
using Udemy.Application.Features.ProfilesOperations;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.IRepositories;
public interface IUserFollowingReadRepository : IReadRepository<UserFollowing>
{
     Task<List<GetProfilesQueryResponse>> GetTargetProfiles(Expression<Func<UserFollowing, bool>> predicate = null);
     Task<List<GetProfilesQueryResponse>> GetObserverProfiles(Expression<Func<UserFollowing, bool>> predicate = null);
}
