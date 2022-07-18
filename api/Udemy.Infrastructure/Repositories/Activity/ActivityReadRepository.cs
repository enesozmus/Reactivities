using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Features.ActivitiesOperations;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class ActivityReadRepository : ReadRepository<Activity>, IActivityReadRepository
{
     private readonly ApplicationContext _context;
     private readonly IMapper _mapper;
     public ActivityReadRepository(ApplicationContext context, IMapper mapper) : base(context)
     {
          _context = context;
          _mapper = mapper;
     }

     public async Task<GetActivityDetailQueryResponse> GetActivityDetails(Guid id)
     {
          return await _context.Activities
               .ProjectTo<GetActivityDetailQueryResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(x => x.Id == id);
     }

     public async Task<IReadOnlyList<GetActivitiesQueryResponse>> GetAllActivitiesForIndex()
     {
          var activities = await _context.Activities
               .ProjectTo<GetActivitiesQueryResponse>(_mapper.ConfigurationProvider)
               .ToListAsync();

          return activities;

          ////return await _context.Activities
          ////     .Include(x => x.Attendees)
          ////     .ThenInclude(x => x.AppUser)
          ////     .ToListAsync();
     }

     public async Task<Activity> UpdateAttendance(Guid id)
     {
          return await _context.Activities
               .Include(a => a.Attendees)
               .ThenInclude(u => u.AppUser)
               .SingleOrDefaultAsync(x => x.Id == id);
     }
}
