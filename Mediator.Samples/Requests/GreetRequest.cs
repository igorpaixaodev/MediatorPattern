using Mediator.Abstractions.Interfaces;

namespace Mediator.Samples.Requests
{
    public record GreetRequest(string Name) : IRequest<string>
    {
    }
}
