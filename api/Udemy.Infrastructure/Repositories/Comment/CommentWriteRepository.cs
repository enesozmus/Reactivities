using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class CommentWriteRepository : WriteRepository<Comment>, ICommentWriteRepository
{
     public CommentWriteRepository(ApplicationContext context) : base(context) { }
}
