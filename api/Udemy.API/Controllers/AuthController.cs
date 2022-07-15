using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.AuthenticationOperations;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;


public class AuthController : BaseController
{
     private readonly UserManager<AppUser> _userManager;

     public AuthController(UserManager<AppUser> userManager)
     {
          _userManager = userManager;
     }

     [AllowAnonymous]
     [HttpPost("login")]
     public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
     {
          var result = await Mediator.Send(request);
          if (result.IsSuccess == false)
               return Unauthorized("Email veya şifre hatalı!");
          return Ok(result);
     }

     [AllowAnonymous]
     [HttpPost("register")]
     public async Task<IActionResult> Register(RegisterCommandRequest request) => Ok(await Mediator.Send(request));

     [Authorize]
     [HttpGet]
     public async Task<IActionResult> GetCurrentUser() => Ok(await Mediator.Send(new GetCurrentUserQueryRequest()));
}
