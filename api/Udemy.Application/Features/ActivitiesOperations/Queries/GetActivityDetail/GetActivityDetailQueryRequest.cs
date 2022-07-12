using MediatR;
using Udemy.Application.Result;

namespace Udemy.Application.Features.ActivitiesOperations;

public class GetActivityDetailQueryRequest : IRequest<Result<GetActivityDetailQueryResponse>>
{
     public GetActivityDetailQueryRequest(Guid id)
     {
          Id = id;
     }

     public Guid Id { get; set; }
}
