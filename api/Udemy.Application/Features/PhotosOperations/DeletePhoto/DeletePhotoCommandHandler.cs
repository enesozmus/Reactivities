using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.PhotosOperations;

public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommandRequest, Result<Unit>>
{

     private readonly IPhotoWriteRepository _writeRepository;
     private readonly IUserAccessor _userAccessor;
     private readonly IPhotoAccessor _photoAccessor;
     private readonly UserManager<AppUser> _userManager;

     public DeletePhotoCommandHandler(IPhotoWriteRepository writeRepository, IUserAccessor userAccessor, IPhotoAccessor photoAccessor, UserManager<AppUser> userManager)
     {
          _writeRepository = writeRepository;
          _userAccessor = userAccessor;
          _photoAccessor = photoAccessor;
          _userManager = userManager;
     }

     public async Task<Result<Unit>> Handle(DeletePhotoCommandRequest request, CancellationToken cancellationToken)
     {
          var user = await _userManager
               .Users
               .Include(p => p.Photos)
               .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

          if (user == null) return null;

          var photo = user.Photos.FirstOrDefault(x => x.PhotoId == request.Id);
          if (photo == null) return null;

          if (photo.IsMain) return Result<Unit>.Failure("Birincil fotoğrafınızı silemezsiniz!");
          var result = await _photoAccessor.DeletePhoto(photo.PhotoId);

          if (result == null) return Result<Unit>.Failure("Cloudinary kaynaklı bir problem yaşanıyor!");

          await _writeRepository.RemoveAsync(photo);
          await _writeRepository.SaveAsync();
          return Result<Unit>.Success(Unit.Value);
     }
}
