using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.AuthenticationOperations;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQueryRequest, GetCurrentUserQueryResponse>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IMapper _mapper;

     public GetCurrentUserQueryHandler(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
     {
          _userManager = userManager;
          _httpContextAccessor = httpContextAccessor;
          _mapper = mapper;
     }

     public async Task<GetCurrentUserQueryResponse> Handle(GetCurrentUserQueryRequest request, CancellationToken cancellationToken)
     {
          //var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity?.Name);

          var username = _httpContextAccessor.HttpContext.User.Identity?.Name;
          var user = await _userManager
               .Users
               .Include(x => x.Photos)
               .FirstOrDefaultAsync(x => x.UserName == username);

          var response = _mapper.Map<GetCurrentUserQueryResponse>(user);
          return response;
     }
}
