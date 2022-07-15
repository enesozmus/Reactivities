using AutoMapper;
using Udemy.Application.Features.ActivitiesOperations;
using Udemy.Application.Features.AuthenticationOperations;
using Udemy.Domain.Entities;

namespace Udemy.Application.Mappings;

public class MappingProfile : Profile
{
     public MappingProfile()
     {
          #region Activities

          CreateMap<Activity, GetActivitiesQueryResponse>();
          CreateMap<Activity, GetActivityDetailQueryResponse>();

          CreateMap<Activity, CreateActivityCommandRequest>().ReverseMap();
          CreateMap<Activity, UpdateActivityCommandRequest>().ReverseMap();

          #endregion

          #region Users

          CreateMap<AppUser, LoginCommandResponse>().ReverseMap();
          CreateMap<AppUser, RegisterCommandRequest>().ReverseMap();
          CreateMap<AppUser, GetCurrentUserQueryResponse>().ReverseMap();

          

          #endregion
     }
}
