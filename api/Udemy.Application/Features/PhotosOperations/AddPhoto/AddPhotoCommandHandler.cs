using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Result;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.PhotosOperations;

public class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommandRequest, Result<Photo>>
{
     
     private readonly IPhotoWriteRepository _writeRepository;
     private readonly IUserAccessor _userAccessor;
     private readonly IPhotoAccessor _photoAccessor;
     private readonly UserManager<AppUser> _userManager;
     private readonly IHttpContextAccessor _httpContextAccessor;

     public AddPhotoCommandHandler(IPhotoWriteRepository writeRepository, IUserAccessor userAccessor, IPhotoAccessor photoAccessor, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
     {
          _writeRepository = writeRepository;
          _userAccessor = userAccessor;
          _photoAccessor = photoAccessor;
          _userManager = userManager;
          _httpContextAccessor = httpContextAccessor;
     }

     public async Task<Result<Photo>> Handle(AddPhotoCommandRequest request, CancellationToken cancellationToken)
     {
          //var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity?.Name);
          var user = _userManager
               .Users
               .Include(x => x.Photos)
               .SingleOrDefault(x => x.UserName == _userAccessor.GetUsername()); 

          if (user == null) return null;

          var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

          var photo = new Photo { Url = photoUploadResult.Url, PhotoId = photoUploadResult.PublicId, AppUserId = user.Id };
          if (!user.Photos.Any(x => x.IsMain)) photo.IsMain = true;

          await _writeRepository.AddAsync(photo);
          //user.Photos.Add(photo);

          await _writeRepository.SaveAsync();

          return Result<Photo>.Success(photo);
          //return Result<Photo>.Failure("Problem adding photo");


          //var user = await _context.Users
          //.Include(p => p.Photos)
          //.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
     }
}
