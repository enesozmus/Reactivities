using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivitiesQueryRequest : IRequest<Result<IReadOnlyList<GetActivitiesQueryResponse>>> { }
