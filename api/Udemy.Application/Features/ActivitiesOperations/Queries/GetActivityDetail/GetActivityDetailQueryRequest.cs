using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivityDetailQueryRequest : IRequest<Result<GetActivityDetailQueryResponse>>
{
     public GetActivityDetailQueryRequest(Guid id)
     {
          Id = id;
     }

     public Guid Id { get; set; }
}
