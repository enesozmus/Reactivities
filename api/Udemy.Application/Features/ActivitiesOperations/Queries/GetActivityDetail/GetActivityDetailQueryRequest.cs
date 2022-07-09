using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivityDetailQueryRequest : IRequest<GetActivityDetailQueryResponse>
{
     public GetActivityDetailQueryRequest(Guid id)
     {
          Id = id;
     }

     public Guid Id { get; set; }
}
