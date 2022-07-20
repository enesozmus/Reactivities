using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.CommentOperations;

public class GetCommentsQueryRequest : IRequest<Result<IReadOnlyList<GetCommentsQueryResponse>>>
{
     public Guid ActivityId { get; set; }
}
