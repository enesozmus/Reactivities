using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Application.Features.ActivitiesOperations;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class ActivityReadRepository : ReadRepository<Activity>, IActivityReadRepository
{
     private readonly ApplicationContext _context;
     private readonly IMapper _mapper;
     private readonly IUserAccessor _userAccessor;
     public ActivityReadRepository(ApplicationContext context, IMapper mapper, IUserAccessor userAccessor) : base(context)
     {
          _context = context;
          _mapper = mapper;
          _userAccessor = userAccessor;
     }

     #region Bütün Etkinlikleri Listele

     public async Task<IQueryable<GetActivitiesQueryResponse>> GetAllActivitiesForIndex()
     {
          var query = _context.Activities
               //.Where(predicate)
               .OrderBy(d => d.Date)
               .ProjectTo<GetActivitiesQueryResponse>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
               .AsQueryable();

          return query;
     }

     #endregion

     public async Task<GetActivityDetailQueryResponse> GetActivityDetails(Guid id)
     {
          return await _context.Activities
               .ProjectTo<GetActivityDetailQueryResponse>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
               .FirstOrDefaultAsync(x => x.Id == id);
     }

     public async Task<Activity> UpdateAttendance(Guid id)
     {
          return await _context.Activities
               .Include(a => a.Attendees)
               .ThenInclude(u => u.AppUser)
               .SingleOrDefaultAsync(x => x.Id == id);
     }
}
