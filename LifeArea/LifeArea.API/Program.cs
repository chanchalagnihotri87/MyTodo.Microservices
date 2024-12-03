using Carter;
using LifeArea.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Add services to the container
var assembly = typeof(Program).Assembly;

builder.Services.AddDbContext<LifeAreaDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));

});


builder.Services.AddCarter();


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});




var app = builder.Build();


//Configure the HTTP Request Pipeline

app.UseMigration();

app.MapCarter();

app.Run();
