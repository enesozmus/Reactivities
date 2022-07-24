using System.Linq.Expressions;
using Udemy.Application.Features.ActivitiesOperations;
using Udemy.Domain.Entities;

namespace Udemy.Application.IRepositories;
public interface IActivityReadRepository : IReadRepository<Activity>
{
     Task<IQueryable<GetActivitiesQueryResponse>> GetAllActivitiesForIndex();
     Task<GetActivityDetailQueryResponse> GetActivityDetails(Guid id);
     Task<Activity> UpdateAttendance(Guid id);
}
