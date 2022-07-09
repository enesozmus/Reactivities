using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class ActivityWriteRepository : WriteRepository<Activity>, IActivityWriteRepository
{
     public ActivityWriteRepository(ApplicationContext context) : base(context) { }
}
