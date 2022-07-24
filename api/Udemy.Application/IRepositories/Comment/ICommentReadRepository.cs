using Udemy.Application.Features.CommentOperations;
using Udemy.Domain.Entities;

namespace Udemy.Application.IRepositories;
public interface ICommentReadRepository : IReadRepository<Comment>
{
     Task<IReadOnlyList<GetCommentsQueryResponse>> GetAllCommentsForActivity(Guid id);
}
