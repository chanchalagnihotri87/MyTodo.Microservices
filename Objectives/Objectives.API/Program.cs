using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions.Handler;
using Carter;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using BuildingBlocks.Messages.MassTransit;
using Objectives.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to container
var assembly = typeof(Program).Assembly;

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


builder.Services.AddDbContext<ObjectiveDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));

});

builder.Services.AddMessageBroker(builder.Configuration, Assembly.GetExecutingAssembly());

var app = builder.Build();

//Configure the HTTP request pipeline
app.UseMigration();

app.MapCarter();

app.UseExceptionHandler(option => { });

app.Run();
