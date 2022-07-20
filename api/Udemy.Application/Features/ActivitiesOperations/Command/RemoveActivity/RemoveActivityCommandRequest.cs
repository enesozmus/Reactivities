using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ActivitiesOperations;

public class RemoveActivityCommandRequest : IRequest<Result<Unit>>
{
     public Guid Id { get; set; }
}
