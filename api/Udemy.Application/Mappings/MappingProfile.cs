using AutoMapper;
using Udemy.Application.Features.ActivitiesOperations;
using Udemy.Application.Features.AuthenticationOperations;
using Udemy.Application.Features.CommentOperations;
using Udemy.Application.Features.ProfilesOperations;
using Udemy.Domain.Entities;

namespace Udemy.Application.Mappings;

public class MappingProfile : Profile
{
     public MappingProfile()
     {
          string currentUsername = null;

          #region Katılımcılar

          CreateMap<ActivityAttendee, AttendeeDto>()
               .ForMember(d => d.FirstName, o => o.MapFrom(s => s.AppUser.FirstName))
               .ForMember(d => d.LastName, o => o.MapFrom(s => s.AppUser.LastName))
               .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
               .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url))
               .ForMember(d => d.FollowersCount, o => o.MapFrom(s => s.AppUser.Followers.Count))
               .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.AppUser.Followings.Count))
               .ForMember(d => d.Following, o => o.MapFrom(s => s.AppUser.Followers.Any(x => x.Observer.UserName == currentUsername)));

          #endregion

          #region Etkinlikler

          CreateMap<Activity, GetActivitiesQueryResponse>()
               .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));

          CreateMap<Activity, GetActivityDetailQueryResponse>()
               .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));

          CreateMap<Activity, CreateActivityCommandRequest>().ReverseMap();
          CreateMap<Activity, UpdateActivityCommandRequest>().ReverseMap();

          #endregion

          #region Kullanıcılar

          CreateMap<AppUser, LoginCommandResponse>().ReverseMap();

          CreateMap<AppUser, RegisterCommandRequest>().ReverseMap();

          CreateMap<AppUser, GetCurrentUserQueryResponse>()
               .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));

          #endregion

          #region Profil

          CreateMap<AppUser, GetProfilesQueryResponse>()
               .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url))
               .ForMember(d => d.FollowersCount, o => o.MapFrom(s => s.Followers.Count))
               .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.Followings.Count))
               .ForMember(d => d.Following, o => o.MapFrom(s => s.Followers.Any(x => x.Observer.UserName == currentUsername)));

          CreateMap<ActivityAttendee, GetUserActivitiesQueryResponse>()
              .ForMember(d => d.Id, o => o.MapFrom(s => s.Activity.Id))
              .ForMember(d => d.Date, o => o.MapFrom(s => s.Activity.Date))
              .ForMember(d => d.Title, o => o.MapFrom(s => s.Activity.Title))
              .ForMember(d => d.Category, o => o.MapFrom(s => s.Activity.Category))
              .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Activity.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));
          #endregion

          #region Yorumlar

          CreateMap<Comment, CreateCommentsCommandResponse>()
               .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
               .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

          CreateMap<Comment, GetCommentsQueryResponse>()
               .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
               .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

          #endregion
     }
}
