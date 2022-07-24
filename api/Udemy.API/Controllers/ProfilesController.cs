using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.ProfilesOperations;

namespace Udemy.API.Controllers;

public class ProfilesController : BaseController
{
     [HttpGet("{username}")]
     public async Task<IActionResult> GetProfile(string username) => HandleResult(await Mediator.Send(new GetProfilesQueryRequest { UserName = username }));

     [HttpPut]
     public async Task<IActionResult> Edit(EditProfilesQueryRequest request) => HandleResult(await Mediator.Send(request));

     [HttpGet("{username}/activities")]
     public async Task<IActionResult> GetUserActivities(string username, string predicate) => HandleResult(await Mediator.Send(new GetUserActivitiesQueryRequest { Username = username, Predicate = predicate }));

}
