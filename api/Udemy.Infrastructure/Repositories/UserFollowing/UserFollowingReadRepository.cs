using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Application.Features.ProfilesOperations;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.Repositories;

public class UserFollowingReadRepository : ReadRepository<UserFollowing>, IUserFollowingReadRepository
{
     private readonly ApplicationContext _context;
     private readonly IMapper _mapper;
     private readonly IUserAccessor _userAccessor;
     public UserFollowingReadRepository(ApplicationContext context, IMapper mapper, IUserAccessor userAccessor) : base(context)
     {
          _context = context;
          _mapper = mapper;
          _userAccessor = userAccessor;
     }

     public async Task<List<GetProfilesQueryResponse>> GetObserverProfiles(Expression<Func<UserFollowing, bool>> predicate = null)
     {
          var profiles = await _context.UserFollowings
               .Where(predicate)
               .Select(u => u.Target)
               .ProjectTo<GetProfilesQueryResponse>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
               .ToListAsync();

          return profiles;
          //return _mapper.Map<List<GetProfilesQueryResponse>>(profiles);
          //return _mapper.Map<GetProfilesQueryResponse>(profiles);
     }

     public async Task<List<GetProfilesQueryResponse>> GetTargetProfiles(Expression<Func<UserFollowing, bool>> predicate = null)
     {
          var profiles = await _context.UserFollowings
               .Where(predicate)
               .Select(u => u.Observer)
               .ProjectTo<GetProfilesQueryResponse>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
               .ToListAsync();

          return profiles;
          //return _mapper.Map<List<GetProfilesQueryResponse>>(profiles);
          //return _mapper.Map<GetProfilesQueryResponse>(profiles);
     }
}
