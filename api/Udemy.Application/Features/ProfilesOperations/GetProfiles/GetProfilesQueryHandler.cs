using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ProfilesOperations;

public class GetProfilesQueryHandler : IRequestHandler<GetProfilesQueryRequest, Result<GetProfilesQueryResponse>>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public GetProfilesQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
     {
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<Result<GetProfilesQueryResponse>> Handle(GetProfilesQueryRequest request, CancellationToken cancellationToken)
     {
          var user = await _userManager
               .Users
               .ProjectTo<GetProfilesQueryResponse>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync(x => x.UserName == request.UserName);

          if (user == null) return null;

          return Result<GetProfilesQueryResponse>.Success(user);
     }
}
