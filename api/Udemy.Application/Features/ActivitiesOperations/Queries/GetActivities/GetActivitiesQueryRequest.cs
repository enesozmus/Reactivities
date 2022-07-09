using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivitiesQueryRequest : IRequest<IReadOnlyList<GetActivitiesQueryResponse>>
{
}
