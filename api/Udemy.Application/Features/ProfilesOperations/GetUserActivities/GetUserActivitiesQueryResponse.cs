﻿using System.Text.Json.Serialization;

namespace Udemy.Application.Features.ProfilesOperations;

public class GetUserActivitiesQueryResponse
{
     public Guid Id { get; set; }
     public string Title { get; set; }
     public string Category { get; set; }
     public DateTime Date { get; set; }

     [JsonIgnore]
     public string HostUsername { get; set; }
}
