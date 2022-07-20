using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ProfilesOperations;

public class EditProfilesQueryHandler : IRequestHandler<EditProfilesQueryRequest, Result<Unit>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly UserManager<AppUser> _userManager;
     private readonly IActivityWriteRepository _writeRepository;


     public EditProfilesQueryHandler(IUserAccessor userAccessor, UserManager<AppUser> userManager, IActivityWriteRepository writeRepository)
     {
          _userAccessor = userAccessor;
          _userManager = userManager;
          _writeRepository = writeRepository;
     }

     public async Task<Result<Unit>> Handle(EditProfilesQueryRequest request, CancellationToken cancellationToken)
     {
          var user = await _userManager
               .Users
               .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

          user.Bio = request.Bio ?? user.Bio;
          user.DisplayName = request.DisplayName ?? user.DisplayName;

          await _writeRepository.SaveAsync();
          return Result<Unit>.Success(Unit.Value);
     }
}
