using Mediator.Abstractions.Interfaces;

namespace Mediator
{
    public class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var requestType = request.GetType();
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

            var handler = serviceProvider.GetService(handlerType) ?? throw new InvalidOperationException($"Handler not found for {requestType}");

            var method = handlerType.GetMethod("HandleAsync") ?? throw new InvalidOperationException($"Method not found for {requestType}");

            var result = method.Invoke(handler, [request, cancellationToken ]);
            if (result is not Task<TResponse> task)
                throw new InvalidOperationException($"Method returned unexpected type {requestType}");

            return await task;
        }
    }
}
