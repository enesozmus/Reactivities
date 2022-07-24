using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using Udemy.Application.Features.ProfilesOperations;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class ActivityAttendeeReadRepository : ReadRepository<ActivityAttendee>, IActivityAttendeeReadRepository
{
     private readonly ApplicationContext _context;
     private readonly IMapper _mapper;
     public ActivityAttendeeReadRepository(ApplicationContext context, IMapper mapper) : base(context)
     {
          _context = context;
          _mapper = mapper;
     }

     public async Task<IQueryable<GetUserActivitiesQueryResponse>> GetUserActivities(Expression<Func<ActivityAttendee, bool>> predicate = null)
     {
          var query = _context.ActivityAttendees
               .Where(predicate)
              .OrderBy(a => a.Activity.Date)
              .ProjectTo<GetUserActivitiesQueryResponse>(_mapper.ConfigurationProvider)
              .AsQueryable();

          return query;
     }
}
