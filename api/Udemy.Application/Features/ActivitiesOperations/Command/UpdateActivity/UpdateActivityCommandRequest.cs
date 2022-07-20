using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ActivitiesOperations;

public class UpdateActivityCommandRequest : IRequest<Result<Unit>>
{
     public Guid Id { get; set; }
     public string Title { get; set; }
     public DateTime Date { get; set; }
     public string Description { get; set; }
     public string Category { get; set; }
     public string City { get; set; }
     public string Venue { get; set; }
     public bool IsCancelled { get; set; }
}
