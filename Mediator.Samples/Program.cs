using Mediator.Abstractions.Interfaces;
using Mediator.Extensions;
using Mediator.Samples.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mediator.Samples
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddMediator(typeof(Program).Assembly);
                })
                .Build();

            var mediator = host.Services.GetRequiredService<IMediator>();

            var request = new GreetRequest("Mediator Pattern");
            string response = await mediator.SendAsync(request);
            Console.WriteLine(response);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
