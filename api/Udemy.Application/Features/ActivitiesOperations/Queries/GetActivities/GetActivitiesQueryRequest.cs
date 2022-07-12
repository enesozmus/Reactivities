using MediatR;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivitiesQueryRequest : IRequest<Result<IReadOnlyList<GetActivitiesQueryResponse>>>
{
}
