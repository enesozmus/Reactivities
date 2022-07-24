using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivitiesQueryRequest : IRequest<Result<PagedList<GetActivitiesQueryResponse>>>
{
     public ActivityParams Params { get; set; }
}
