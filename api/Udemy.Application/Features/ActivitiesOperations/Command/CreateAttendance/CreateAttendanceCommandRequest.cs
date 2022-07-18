using MediatR;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateAttendanceCommandRequest : IRequest<Result<Unit>>
{
     public Guid Id { get; set; }
}
