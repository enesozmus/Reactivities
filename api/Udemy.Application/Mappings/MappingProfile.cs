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
          #region Katılımcılar

          CreateMap<ActivityAttendee, AttendeeDto>()
               .ForMember(d => d.FirstName, o => o.MapFrom(s => s.AppUser.FirstName))
               .ForMember(d => d.LastName, o => o.MapFrom(s => s.AppUser.LastName))
               .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
               .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

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

          CreateMap<AppUser, GetProfilesQueryResponse>()
               .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));

          #endregion

          #region Yorumlar

          CreateMap<Comment, GetCommentsQueryResponse>()
               .ForMember(d => d.UserName, o => o.MapFrom(s => s.Author.UserName))
               .ForMember(d => d.Image, o => o.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));

          #endregion
     }
}
