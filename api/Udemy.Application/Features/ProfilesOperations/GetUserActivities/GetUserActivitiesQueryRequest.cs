using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ProfilesOperations;

public class GetUserActivitiesQueryRequest : IRequest<Result<List<GetUserActivitiesQueryResponse>>>
{
     public string Username { get; set; }
     public string Predicate { get; set; }
}
