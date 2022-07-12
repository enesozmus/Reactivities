using MediatR;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateActivityCommandRequest : IRequest<Result<Unit>>
{
     public string Title { get; set; }
     public string Description { get; set; }
     public string Category { get; set; }
     public string City { get; set; }
     public string Venue { get; set; }
     public bool IsCancelled { get; set; }
}
