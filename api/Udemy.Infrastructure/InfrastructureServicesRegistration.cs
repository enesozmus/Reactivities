using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Udemy.Application.Interfaces;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;
using Udemy.Infrastructure.Photos;
using Udemy.Infrastructure.Repositories;
using Udemy.Infrastructure.Security;

namespace Udemy.Infrastructure;

public static class InfrastructureServicesRegistration
{
     public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
     {
          #region Microsoft SQL Server

          services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

          #endregion


          #region Repositories

          services.AddScoped<IActivityReadRepository, ActivityReadRepository>();
          services.AddScoped<IActivityWriteRepository, ActivityWriteRepository>();

          services.AddScoped<IPhotoReadRepository, PhotoReadRepository>();
          services.AddScoped<IPhotoWriteRepository, PhotoWriteRepository>();

          #endregion


          #region Microsoft.AspNetCore.Identity.EntityFrameworkCore Library

          services.AddIdentityCore<AppUser>(options =>
          {
               options.Password.RequiredLength = 8;
               options.Password.RequireNonAlphanumeric = true;
               options.Password.RequireLowercase = true;
               options.Password.RequireUppercase = true;
               options.Password.RequireDigit = true;
               options.Password.RequiredUniqueChars = 1;

               options.User.RequireUniqueEmail = true;
               options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";

          })
             .AddEntityFrameworkStores<ApplicationContext>()
             .AddSignInManager<SignInManager<AppUser>>();

          #endregion


          #region Json Web Token

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));

          services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = key,
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = true,
                         ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                         OnMessageReceived = context =>
                         {
                              var accessToken = context.Request.Query["access_token"];
                              var path = context.HttpContext.Request.Path;
                              if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/chat")))
                              {
                                   context.Token = accessToken;
                              }
                              return Task.CompletedTask;
                         }
                    };
               });

          #endregion


          #region MyRegion

          services.AddAuthorization(options =>
          {
               options.AddPolicy("IsActivityHost", policy =>
               {
                    policy.Requirements.Add(new IsHostRequirement());
               });
          });

          services.AddTransient<IAuthorizationHandler, IsHostRequirementHandler>();

          #endregion
          services.AddScoped<IUserAccessor, UserAccessor>();
          services.AddScoped<IPhotoAccessor, PhotoAccessor>();
          services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));

          return services;
     }
}