using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Udemy.Application;

public static class ApplicationServicesRegistration
{
     public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
     {
          services.AddAutoMapper(Assembly.GetExecutingAssembly());
          services.AddMediatR(Assembly.GetExecutingAssembly());
          services.AddControllers()
                          .AddFluentValidation(options =>
                          {
                               // Validate child properties and root collection elements
                               options.ImplicitlyValidateChildProperties = true;
                               options.ImplicitlyValidateRootCollectionElements = true;
                               // Automatic registration of validators in assembly
                               options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                          });

          return services;
     }
}
