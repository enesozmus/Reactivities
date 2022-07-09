using Udemy.Application;
using Udemy.Infrastructure;
using Udemy.Infrastructure.SeedData;

var builder = WebApplication.CreateBuilder(args);

#region @ Layers @

builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

#endregion


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region CORS-2

app.UseCors("CorsPolicy");

#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
