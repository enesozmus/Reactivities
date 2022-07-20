using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateAttendanceCommandRequest : IRequest<Result<Unit>>
{
     public Guid Id { get; set; }
}
