using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Interfaces;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ProfilesOperations;

public class GetProfilesQueryHandler : IRequestHandler<GetProfilesQueryRequest, Result<GetProfilesQueryResponse>>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;
     private readonly IUserAccessor _userAccessor;

     public GetProfilesQueryHandler(UserManager<AppUser> userManager, IMapper mapper, IUserAccessor userAccessor)
     {
          _userManager = userManager;
          _mapper = mapper;
          _userAccessor = userAccessor;
     }

     public async Task<Result<GetProfilesQueryResponse>> Handle(GetProfilesQueryRequest request, CancellationToken cancellationToken)
     {
          var user = await _userManager
               .Users
               .ProjectTo<GetProfilesQueryResponse>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
               .SingleOrDefaultAsync(x => x.UserName == request.UserName);

          if (user == null) return null;

          return Result<GetProfilesQueryResponse>.Success(user);
     }
}
