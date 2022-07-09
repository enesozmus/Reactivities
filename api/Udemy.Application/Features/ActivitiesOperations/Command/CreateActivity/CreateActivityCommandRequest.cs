using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateActivityCommandRequest : IRequest
{
     public Activity Activity { get; set; }
}
