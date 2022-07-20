namespace Udemy.Application.Features.CommentOperations;

public class GetCommentsQueryResponse
{
     public Guid Id { get; set; }
     public DateTime CreatedDate { get; set; }
     public string Body { get; set; }
     public string UserName { get; set; }
     public string Image { get; set; }
}
