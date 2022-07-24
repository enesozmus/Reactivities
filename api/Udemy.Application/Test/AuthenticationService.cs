using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Udemy.Application.Features.AuthenticationOperations;
using Udemy.Application.Interfaces;
using Udemy.Domain.Entities;

namespace Udemy.Application.Test;

public class AuthenticationService : IAuthentication
{
     private readonly IConfiguration _configuration;
     private readonly UserManager<AppUser> _userManager;
     private readonly SignInManager<AppUser> _signInManager;

     public AuthenticationService(IConfiguration config, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
     {
          _configuration = config;
          _userManager = userManager;
          _signInManager = signInManager;
     }

     public async Task<LoginCommandResponse> LoginAsync(LoginCommandRequest request)
     {
          var user = await _userManager
               .Users
               .Include(x => x.Photos)
               .SingleOrDefaultAsync(x => x.Email == request.Email);

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

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
          var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

          JwtSecurityToken securityToken = new(
                    claims: claims,
                    audience: _configuration["Token:Audience"],
                    issuer: _configuration["Token:Issuer"],
                    expires: DateTime.Now.AddDays(2),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: creds
                    );

          //var tokenDescriptor = new SecurityTokenDescriptor
          //{
          //     Subject = new ClaimsIdentity(claims),
          //     Expires = DateTime.Now.AddDays(1),
          //     SigningCredentials = creds
          //};

          JwtSecurityTokenHandler tokenHandler = new();

          var token = tokenHandler.WriteToken(securityToken);

          return Task.FromResult(new LoginCommandResponse
          {
               Id = user.Id,
               FirstName = user.FirstName,
               LastName = user.LastName,
               UserName = user.UserName,
               Email = user.Email,
               
               IsSuccess = true,
               Token = token,
          });
     }

     #endregion

}
