using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ProfilesOperations;

public class GetProfilesQueryRequest : IRequest<Result<GetProfilesQueryResponse>>
{
     public string UserName { get; set; }
}
