using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.CommentOperations;

public class CreateCommentsCommandRequest : IRequest<Result<CreateCommentsCommandResponse>>
{
     public Guid ActivityId { get; set; }
     public string Body { get; set; }
}
