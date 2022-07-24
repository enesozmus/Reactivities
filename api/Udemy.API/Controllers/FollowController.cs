using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.UserFollowingOperations;

namespace Udemy.API.Controllers;

public class FollowController : BaseController
{
     [HttpPost("{username}")]
     public async Task<IActionResult> Follow(string username) => HandleResult(await Mediator.Send(new FollowUserCommandRequest { TargetUsername = username }));

     [HttpGet("{username}")]
     public async Task<IActionResult> GetFollowings(string username, string predicate) => HandleResult(await Mediator.Send(new GetFollowersQueryRequest { Username = username, Predicate = predicate }));
}
