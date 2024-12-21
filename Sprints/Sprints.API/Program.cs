using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions.Handler;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Services to container
var assembly = typeof(Program).Assembly;

builder.Services.AddDbContext<SprintDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));

});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


builder.Services.AddCarter();


var app = builder.Build();

//Configure HTTP request pipeline
app.UseMigration();

app.MapCarter();

app.UseExceptionHandler(config => { });

app.Run();
