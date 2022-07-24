using MediatR;
using Udemy.Application.Features.ProfilesOperations;
using Udemy.Application.Results;

namespace Udemy.Application.Features.UserFollowingOperations;

public class GetFollowersQueryRequest : IRequest<Result<List<GetProfilesQueryResponse>>>
{
     public string Predicate { get; set; }
     public string Username { get; set; }
}
