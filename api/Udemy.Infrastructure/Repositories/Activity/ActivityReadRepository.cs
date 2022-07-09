using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class ActivityReadRepository : ReadRepository<Activity>, IActivityReadRepository
{
     public ActivityReadRepository(ApplicationContext context) : base(context) { }
}
