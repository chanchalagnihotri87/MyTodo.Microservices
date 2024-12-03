var builder = WebApplication.CreateBuilder(args);

//Add services to the container

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

//Configure HTTP Request pipelines
app.MapReverseProxy();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


app.Run();
