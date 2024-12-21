using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions.Handler;
using Microsoft.EntityFrameworkCore;
using Problems.API.Data;

var builder = WebApplication.CreateBuilder(args);

//Add services to container
var assembly = typeof(Program).Assembly;

builder.Services.AddCarter(); //Add Carter service


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly); //For Mediator IRequest & IRequestHandler Scan
    config.AddOpenBehavior(typeof(ValidationBehavior<,>)); //For Fluent Validation
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));//For global Logging
});

builder.Services.AddValidatorsFromAssembly(assembly); // For Fluent Validation

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


builder.Services.AddDbContext<ProblemDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));

});

var app = builder.Build();

//Add request pipelines

app.UseMigration();

app.MapCarter(); //Scan carter module

app.UseExceptionHandler(option => { });

app.Run();
