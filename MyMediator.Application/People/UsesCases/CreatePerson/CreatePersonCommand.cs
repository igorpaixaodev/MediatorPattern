using Mediator.Abstractions.Interfaces;

namespace MyMediator.Application.People.UsesCases.CreatePerson
{
    public record CreatePersonCommand(int Age, string Name) : IRequest<string>;
}
