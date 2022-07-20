using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommandRequest, Result<Unit>>
{
     private readonly IActivityReadRepository _readRepository;
     private readonly IActivityWriteRepository _writeRepository;
     private readonly UserManager<AppUser> _userManager;
     private readonly IHttpContextAccessor _httpContextAccessor;

     public CreateAttendanceCommandHandler(IActivityReadRepository readRepository, IActivityWriteRepository writeRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
          _userManager = userManager;
          _httpContextAccessor = httpContextAccessor;
     }

     public async Task<Result<Unit>> Handle(CreateAttendanceCommandRequest request, CancellationToken cancellationToken)
     {
          var activity = await _readRepository.UpdateAttendance(request.Id);
          if (activity == null) return null;

          // kullanıcıyı getir
          var appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity?.Name);
          if (appUser == null) return null;

          var hostUsername = activity.Attendees.FirstOrDefault(x => x.IsHost)?.AppUser?.UserName;
          var attendance = activity.Attendees.FirstOrDefault(x => x.AppUser.UserName == appUser.UserName);

          if (attendance != null && hostUsername == appUser.UserName)
               activity.IsCancelled = !activity.IsCancelled;

          if (attendance != null && hostUsername != appUser.UserName)
               activity.Attendees.Remove(attendance);

          if (attendance == null)
          {
               attendance = new ActivityAttendee
               {
                    AppUser = appUser,
                    Activity = activity,
                    IsHost = false
               };

               activity.Attendees.Add(attendance);
          }

          // kaydet
          await _writeRepository.SaveAsync();

          // gönder
          return Result<Unit>.Success(Unit.Value);
          //return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem updating attendance");
     }
}
