using Mediator.Abstractions.Interfaces;
using MyMediator.Domain.People;

namespace MyMediator.Application.People.UsesCases.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, string>
    {
        public Task<string> HandleAsync(CreatePersonCommand request, CancellationToken cancellationToken = default)
        {
            var person = new Person(request.Age, request.Name);
            return Task.FromResult(person.ToString());
        }
    }
}
