using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.ProfilesOperations;

namespace Udemy.API.Controllers;

public class ProfilesController : BaseController
{
     [HttpGet("{username}")]
     public async Task<IActionResult> GetProfile(string username) => HandleResult(await Mediator.Send(new GetProfilesQueryRequest { UserName = username }));

     [HttpPut]
     public async Task<IActionResult> Edit(EditProfilesQueryRequest request) => HandleResult(await Mediator.Send(request));

}
