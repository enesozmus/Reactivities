using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class UserFollowingWriteRepository : WriteRepository<UserFollowing>, IUserFollowingWriteRepository
{
     public UserFollowingWriteRepository(ApplicationContext context) : base(context) { }
}
