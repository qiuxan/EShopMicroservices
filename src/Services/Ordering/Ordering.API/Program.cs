using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

//builder.Services
//add application services
//add infrastructure services
//add web services


var app = builder.Build();

//Configure the HTTP request pipeline.

app.Run();
