using MediatR;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class RemoveActivityCommandRequest : IRequest<Result<Unit>>
{
     public Guid Id { get; set; }
}
