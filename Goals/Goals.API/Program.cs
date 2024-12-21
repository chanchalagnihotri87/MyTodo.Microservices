using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions.Handler;
using FluentValidation;
using Goals.API.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to application
var assembly = typeof(Program).Assembly;

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddDbContext<GoalDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));

});



builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

//Add services in request pipelines

app.UseMigration();

app.MapCarter();

app.UseExceptionHandler(option => { });

app.Run();
