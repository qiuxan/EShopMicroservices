using BuildingBlocks.Behaviors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//add services to the container

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>)); //register the validation behavior as a pipeline behavior
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();


builder.Services.AddMarten(opts => {

    opts.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();


var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapCarter();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exceptiontion = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exceptiontion == null)
        {
            return;
        }

        var problemDetails = new ProblemDetails
        {
            Title = exceptiontion.Message,
            Status = StatusCodes.Status500InternalServerError,
            Detail = exceptiontion.StackTrace
        };

        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exceptiontion, exceptiontion.Message);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});


app.Run();
