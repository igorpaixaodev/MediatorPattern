using Mediator.Abstractions.Interfaces;
using Mediator.Samples.Requests;

namespace Mediator.Samples.Handlers
{
    public class GreetRequestHandler : IRequestHandler<GreetRequest, string>
    {
        public Task<string> HandleAsync(GreetRequest request, CancellationToken cancellationToken = default)
        {
            string greeting = $"Hello, {request.Name}! Welcome to the simple Mediator example.";
            return Task.FromResult(greeting);
        }
    }
}
