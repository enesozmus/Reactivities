using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Udemy.Application.Features.AuthenticationOperations;
using Udemy.Application.Result;
using Udemy.Domain.Entities;

namespace Udemy.Application.Test;

public class AuthenticationService : IAuthentication
{
     private readonly IConfiguration _config;
     private readonly UserManager<AppUser> _userManager;
     private readonly SignInManager<AppUser> _signInManager;

     public AuthenticationService(IConfiguration config, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
     {
          _config = config;
          _userManager = userManager;
          _signInManager = signInManager;
     }

     public async Task<LoginCommandResponse> LoginAsync(LoginCommandRequest request)
     {
          var user = _userManager.Users.SingleOrDefault(x => x.Email == request.Email);

          if (user == null)
               return new LoginCommandResponse { Errors = new[] { "Email veya şifre hatalı!" } };

          var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

          if (!result.Succeeded)
               return new LoginCommandResponse { Errors = new[] { "Email veya şifre hatalı!" } }; 

          return await GenerateAuthenticationResponseForUserAsync(user);
     }

     #region Token

     private Task<LoginCommandResponse> GenerateAuthenticationResponseForUserAsync(AppUser user)
     {
          var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
          var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

          var tokenDescriptor = new SecurityTokenDescriptor
          {
               Subject = new ClaimsIdentity(claims),
               Expires = DateTime.UtcNow.AddMinutes(10),
               SigningCredentials = creds
          };

          var tokenHandler = new JwtSecurityTokenHandler();

          var token = tokenHandler.CreateToken(tokenDescriptor);

          return Task.FromResult(new LoginCommandResponse
          {
               Id = user.Id,
               FirstName = user.FirstName,
               LastName = user.LastName,
               UserName = user.UserName,
               Email = user.Email,
               
               IsSuccess = true,
               Token = tokenHandler.WriteToken(token),
               
          });
     }

     #endregion

}
