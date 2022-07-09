using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Application.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;
using Udemy.Infrastructure.Repositories;

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

          #endregion


          #region Identity Library

          services.AddIdentity<AppUser, AppRole>(options =>
          {
               options.Password.RequiredLength = 8;
               options.Password.RequireNonAlphanumeric = true;
               options.Password.RequireLowercase = true;
               options.Password.RequireUppercase = true;
               options.Password.RequireDigit = true;
               options.User.RequireUniqueEmail = true;
               options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";

          })
             .AddEntityFrameworkStores<ApplicationContext>();

          #endregion

          return services;
     }
}