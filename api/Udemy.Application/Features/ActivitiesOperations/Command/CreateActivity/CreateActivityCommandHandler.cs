using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommandRequest, Result<Unit>>
{
     private readonly IActivityWriteRepository _writeRepository;
     private readonly IUserAccessor _userAccessor;
     private readonly UserManager<AppUser> _userManager;
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IMapper _mapper;

     public CreateActivityCommandHandler(IActivityWriteRepository writeRepository, IUserAccessor userAccessor, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
     {
          _writeRepository = writeRepository;
          _userAccessor = userAccessor;
          _userManager = userManager;
          _httpContextAccessor = httpContextAccessor;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(CreateActivityCommandRequest request, CancellationToken cancellationToken)
     {
          // kullanıcıyı getir
          var appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity?.Name);
          var activityMap = _mapper.Map<Activity>(request);
          var testUserName = _userAccessor.GetUsername();

          if (appUser.UserName == _userAccessor.GetUsername())
          {
               var attendee = new ActivityAttendee
               {
                    AppUser = appUser,
                    Activity = activityMap,
                    IsHost = true
               };
               activityMap.Attendees.Add(attendee);
          }

          // maple
          //var activity = _mapper.Map<Activity>(request);

          // ekle
          await _writeRepository.AddAsync(activityMap);
          if (activityMap == null) return Result<Unit>.Failure("Yeni etkinlik eklenirken bir hata oluştu!");
          
          // kaydet
          await _writeRepository.SaveAsync();

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
