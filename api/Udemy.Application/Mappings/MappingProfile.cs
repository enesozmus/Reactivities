﻿using AutoMapper;
using Udemy.Application.Features.ActivitiesOperations;
using Udemy.Domain.Entities;

namespace Udemy.Application.Mappings;

public class MappingProfile : Profile
{
     public MappingProfile()
     {
          #region Activities

          CreateMap<Activity, GetActivitiesQueryResponse>();
          CreateMap<Activity, GetActivityDetailQueryResponse>();

          // Test
          CreateMap<Activity, Activity>();



          //CreateMap<Activity, CreateCategoryCommandRequest>().ReverseMap();
          //CreateMap<Activity, CreateCategoryCommandRequest>().ReverseMap();

          #endregion
     }
}
