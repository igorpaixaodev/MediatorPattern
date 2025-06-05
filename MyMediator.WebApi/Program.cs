using Mediator.Abstractions.Interfaces;
using Mediator.Extensions;
using MyMediator.Application.People.UsesCases.CreatePerson;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediator(typeof(CreatePersonCommand).Assembly);
var app = builder.Build();

app.MapPost("/person",
    async (CreatePersonCommand command, IMediator mediator) =>
    {
        var result = await mediator.SendAsync(command);
        return Results.Ok(result);
    });

app.Run();
