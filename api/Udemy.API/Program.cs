using Microsoft.OpenApi.Models;
using Udemy.API.Middleware;
using Udemy.API.SignalR;
using Udemy.Application;
using Udemy.Infrastructure;
using Udemy.Infrastructure.SeedData;

var builder = WebApplication.CreateBuilder(args);

#region @ Layers @

builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

#endregion

builder.Services.AddSignalR(options =>
{
     options.EnableDetailedErrors = true;
});
builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
     {
          Description = "Jwt auth header",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
     });
     c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
});

#endregion

#region CORS-1

builder.Services.AddCors(opt =>
{
     opt.AddPolicy("CorsPolicy", policy =>
     {
          policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:3000");
     });
});

#endregion

var app = builder.Build();

#region SeedData

DbInitializer.Initialize(app);

#endregion

#region ExceptionMiddleware

app.UseMiddleware<ExceptionMiddleware>();

#endregion

if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region CORS-2

app.UseCors("CorsPolicy");

#endregion

#region Identity

app.UseAuthentication();
app.UseAuthorization();

#endregion

app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
