using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class UpdateActivityCommandRequest : IRequest
{
     public Activity Activity { get; set; }
}
