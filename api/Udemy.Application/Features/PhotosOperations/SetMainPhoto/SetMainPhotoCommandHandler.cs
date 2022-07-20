using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.PhotosOperations;

public class SetMainPhotoCommandHandler : IRequestHandler<SetMainPhotoCommandRequest, Result<Unit>>
{

     private readonly IPhotoWriteRepository _writeRepository;
     private readonly IUserAccessor _userAccessor;
     private readonly UserManager<AppUser> _userManager;

     public SetMainPhotoCommandHandler(IPhotoWriteRepository writeRepository, IUserAccessor userAccessor, UserManager<AppUser> userManager)
     {
          _writeRepository = writeRepository;
          _userAccessor = userAccessor;
          _userManager = userManager;
     }

     public async Task<Result<Unit>> Handle(SetMainPhotoCommandRequest request, CancellationToken cancellationToken)
     {
          var user = await _userManager
               .Users
               .Include(p => p.Photos)
               .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
          if (user == null) return null;

          var photo = user.Photos.FirstOrDefault(x => x.PhotoId == request.Id);
          if (photo == null) return null;

          var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
          if (currentMain != null) currentMain.IsMain = false;

          photo.IsMain = true;

          await _writeRepository.SaveAsync();
          return Result<Unit>.Success(Unit.Value);     
     }
}
