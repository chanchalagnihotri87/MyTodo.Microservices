using Tasks.API;
using Tasks.API.Data;
using Tasks.Application;
using Tasks.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add services to container
builder.Services.
    AddInfrastructureServices(builder.Configuration).
    AddApplicaitonServices(builder.Configuration).
    AddApiServices();


var app = builder.Build();

//Configurat HTTP request pipelines

app.UseMigration();

app.UseApiServices();

app.Run();
