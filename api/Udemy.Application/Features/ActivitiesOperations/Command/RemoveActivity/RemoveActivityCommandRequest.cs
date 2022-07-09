using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class RemoveActivityCommandRequest : IRequest
{
     public Guid Id { get; set; }
}
