using Beykam.Application;
using Beykam.Application.Common.Mapping;
using Beykam.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication(); 
builder.Services.AddDbContext<BeykamDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=BeykamDb;Username=postgres;Password=skrmricv"));


builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Beykam API", Version = "v1" });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Beykam API v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
