using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Udemy.Application.Interfaces;
using Udemy.Application.Test;

namespace Udemy.Application;

public static class ApplicationServicesRegistration
{
     public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
     {
          services.AddAutoMapper(Assembly.GetExecutingAssembly());
          services.AddMediatR(Assembly.GetExecutingAssembly());
          services.AddControllers(options =>
          {
               var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
               options.Filters.Add(new AuthorizeFilter(policy));
          })
                          .AddFluentValidation(options =>
                          {
                               // Validate child properties and root collection elements
                               options.ImplicitlyValidateChildProperties = true;
                               options.ImplicitlyValidateRootCollectionElements = true;
                               // Automatic registration of validators in assembly
                               options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                          });
                          //.AddNewtonsoftJson(options =>
                          //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

          services.AddScoped<IAuthentication, AuthenticationService>();

          return services;
     }
}
