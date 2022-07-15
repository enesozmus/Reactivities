using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Contexts;

namespace Udemy.Infrastructure.SeedData;

public class DbInitializer
{
     public static void Initialize(IApplicationBuilder applicationBuilder)
     {
          using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
          {
               var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

               context?.Database.Migrate();

               #region Activities

               if (!context.Activities.Any())
               {
                    context.Activities.AddRange(new List<Activity>()
                    {
                         new Activity
                         {
                              Title = "Etkinlik 1",
                              Date = new DateTime(2022, 04, 11, 20, 00, 00),
                              Description = "seeddata 1 | Lorem ipsum dolor sit amet.",
                              Category = "drinks",
                              City = "London",
                              Venue = "Pub",
                              CreatedDate = DateTime.Now,
                         },
                         new Activity
                         {
                              Title = "Etkinlik 2",
                              Date = new DateTime(2022, 04, 12, 21, 30, 00),
                              Description = "seeddata 2 | Lorem ipsum dolor sit amet.",
                              Category = "culture",
                              City = "Paris",
                              Venue = "Louvre",
                              CreatedDate = DateTime.Now,
                         },
                         new Activity
                         {
                              Title = "Etkinlik 3",
                              Date = new DateTime(2022, 04, 13, 20, 00, 00),
                              Description = "seeddata 3 | Lorem ipsum dolor sit amet.",
                              Category = "culture",
                              City = "London",
                              Venue = "Natural History Museum",
                              CreatedDate = DateTime.Now
                          },
                         new Activity
                         {
                              Title = "Etkinlik 4",
                              Date = new DateTime(2022, 04, 14, 21, 30, 00),
                              Description = "seeddata 4 | Lorem ipsum dolor sit amet.",
                              Category = "music",
                              City = "London",
                              Venue = "O2 Arena",
                              CreatedDate = DateTime.Now
                         },
                         new Activity
                         {
                              Title = "Etkinlik 5",
                              Date = new DateTime(2022, 04, 15, 20, 00, 00),
                              Description = "seeddata 5 | Lorem ipsum dolor sit amet.",
                              Category = "drinks",
                              City = "London",
                              Venue = "Another pub",
                              CreatedDate = DateTime.Now
                         },
                         new Activity
                         {
                              Title = "Etkinlik 6",
                              Date = new DateTime(2022, 04, 16, 21, 30, 00),
                              Description = "seeddata 6 | Lorem ipsum dolor sit amet.",
                              Category = "drinks",
                              City = "London",
                              Venue = "Yet another pub",
                              CreatedDate = DateTime.Now
                         },
                         new Activity
                         {
                              Title = "Etkinlik 7",
                              Date = new DateTime(2022, 04, 17, 20, 00, 00),
                              Description = "seeddata 7 | Lorem ipsum dolor sit amet.",
                              Category = "drinks",
                              City = "London",
                              Venue = "Just another pub",
                              CreatedDate = DateTime.Now
                         },
                         new Activity
                         {
                              Title = "Etkinlik 8",
                              Date = new DateTime(2022, 04, 18, 21, 30, 00),
                              Description = "seeddata 8 | Lorem ipsum dolor sit amet.",
                              Category = "music",
                              City = "London",
                              Venue = "Roundhouse Camden",
                              CreatedDate = DateTime.Now
                         },
                         new Activity
                         {
                              Title = "Etkinlik 9",
                              Date = new DateTime(2022, 04, 19, 20, 00, 00),
                              Description = "seeddata 9 | Lorem ipsum dolor sit amet.",
                              Category = "travel",
                              City = "London",
                              Venue = "Somewhere on the Thames",
                              CreatedDate = DateTime.Now
                         },
                         new Activity
                         {
                              Title = "Etkinlik 10",
                              Date = new DateTime(2022, 04, 20, 21, 30, 00),
                              Description = "seeddata 10 | Lorem ipsum dolor sit amet.",
                              Category = "film",
                              City = "London",
                              Venue = "Cinema",
                              CreatedDate = DateTime.Now
                         }
                         });

                    context.SaveChanges();
               }

               #endregion
          }
     }
}
