using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class ActivityAttendeeWriteRepository : WriteRepository<ActivityAttendee>, IActivityAttendeeWriteRepository
{
     public ActivityAttendeeWriteRepository(ApplicationContext context) : base(context) { }
}
