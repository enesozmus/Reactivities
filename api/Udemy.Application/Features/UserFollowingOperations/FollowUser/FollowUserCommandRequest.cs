using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.UserFollowingOperations;

public class FollowUserCommandRequest : IRequest<Result<Unit>>
{
     public string TargetUsername { get; set; }
}
