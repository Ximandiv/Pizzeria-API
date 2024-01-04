using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pizza.Infrastructure.Data;
using System.Reflection;
using Pizza.Persistence.Repositories.Base;
using Pizza.Persistence.Repositories.Pizza;
using Pizza.Application.MediatR;
using Pizza.Domain.Repositories.Pizza;
using Pizza.Domain.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers();

services.AddDbContext<PizzeriaContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("default")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

services.AddEndpointsApiExplorer();

services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pizzeria.API",
        Version = "v1"
    });
});

services.AddAutoMapper(typeof(Program));
services.AddApplication();
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddTransient<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowLocalhost");

app.Run();
