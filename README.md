# MediatorPattern

A clean and extensible implementation of the Mediator Pattern in C#, inspired by CQRS and the popular MediatR library. This solution demonstrates how to define and dispatch requests (commands/queries) to their respective handlers, decoupling the caller from the business logic. It also includes sample projects to illustrate both a Minimal API approach and a Clean Architecture approach.

---

## 🧩 Project Structure
```shell
MediatorPattern/
│
├── Abstractions/
│ └── Interfaces/
│ ├── IMediator.cs # Contract for sending requests and receiving responses
│ ├── IRequest.cs # Marker interface for a request that returns a response
│ └── IRequestHandler.cs # Contract for handling a request and returning a response
│
├── Mediator/
│ ├── Extensions/
│ │ └── MediatorExtensions.cs # (Optional) Extension methods for registering Mediator in DI
│ └── Mediator.cs # Concrete implementation of IMediator
│
├── Samples/
│ ├── CleanArchitecture/
│ │ ├── MyMediator.Application/ # Application layer: Commands and Handlers
│ │ ├── MyMediator.Domain/ # Domain layer: Entities
│ │ └── MyMediator.WebApi/ # Web API layer: Controllers wiring up IMediator
│ │
│ └── Mediator.Samples/
│ ├── Handlers/
│ │ └── GreetRequestHandler.cs # Example handler without external dependencies
│ ├── Requests/
│ │ └── GreetRequest.cs # Example request carrying a simple payload
│ └── Program.cs # Minimal API example wiring up IMediator
│
└── README.md # This file
```
---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later  
- A C#–aware IDE (Visual Studio 2022+, Visual Studio Code, Rider, etc.)  
- Basic knowledge of Dependency Injection, asynchronous programming (`async/await`), and interface-based design
---

## 📚 Abstractions

All core contracts live under **Abstractions/Interfaces**:

- **`IMediator`**  
  Responsible for dispatching a generic request (`IRequest<TResponse>`) to its registered handler (`IRequestHandler<TRequest, TResponse>`) and returning a response.  
- **`IRequest<TResponse>`**  
  Marker interface used to represent a request that expects a response of type `TResponse`.  
- **`IRequestHandler<TRequest, TResponse>`**  
  Contract for a handler that processes a `TRequest : IRequest<TResponse>` and produces a `TResponse`.

You’ll find XML comments (with bilingual English/Portuguese) on each interface method, explaining usage, parameters, and possible exceptions.

---

## 🔧 Mediator Implementation

Under **Mediator/** you have:

1. **`Mediator.cs`**  
   - Implements **`IMediator`**.  
   - Uses an `IServiceProvider` internally to resolve the correct `IRequestHandler<,>` based on the runtime request type.  
   - Reflection is used to invoke the `HandleAsync` method on the discovered handler.  
   - Throws `InvalidOperationException` if no matching handler is found or if the handler returns an unexpected type.

2. **`Extensions/MediatorExtensions.cs`** _(optional)_  
   - Contains extension methods (e.g., `services.AddMediator()`) for registering `IMediator` and scanning assemblies to auto-register all `IRequestHandler<,>` implementations.  
   - Feel free to customize or remove it if you prefer manual registration.

---

## 🎯 Usage Examples

### 1. Minimal API Example (`Samples/CleanArchitecture/MyMediator.WebApi/Program.cs`)

Demonstrates how to wire up a minimal Web API that accepts a `CreatePersonCommand` via HTTP POST and returns a string in the exact format:
`Name: [name] with age [age] created`

```csharp
// Samples/CleanArchitecture/MyMediator.WebApi/Program.cs

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mediator.Abstractions.Interfaces;
using Mediator.Extensions;
using MyMediator.Application.People.UseCases.CreatePerson;

var builder = WebApplication.CreateBuilder(args);

// Register IMediator + all IRequestHandler<> implementations from the specified assembly
builder.Services.AddMediator(typeof(CreatePersonCommand).Assembly);

var app = builder.Build();

app.MapPost("/person",
    async (CreatePersonCommand command, IMediator mediator) =>
    {
        // The handler for CreatePersonCommand must return a string in this exact format:
        //    Name: [name] with age [age] created
        var result = await mediator.SendAsync(command);
        return Results.Ok(result);
    });

app.Run();
```
Example HTTP request

POST /person HTTP/1.1
Host: localhost:5000
Content-Type: application/json

{
  "name": "MyMediator",
  "age": 1
}

Example HTTP response (200 OK)
`Name: MyMediator with age 1 created`

---
## 🛠️ How to Register Handlers

```csharp

builder.Services.AddMediator(typeof(CreatePersonCommand).Assembly);
```
**Note on Assembly Registration:**

The line `builder.Services.AddMediator(typeof(CreatePersonCommand).Assembly)` uses `CreatePersonCommand` as an example type to locate the assembly where all handlers and related types are defined. This method will scan that entire assembly and register all necessary Mediator components (handlers, etc.).

---
✅ Running the Samples
```bash
git clone https://github.com/yourusername/MediatorPattern.git
cd MediatorPattern
```
**Build the solution:**
```shell
dotnet build
```
**Run Minimal API sample:**
```shell
cd Samples/Mediator.Samples
dotnet run
```
**Run Clean Architecture sample:**
```shell
cd Samples/CleanArchitecture/MyMediator.WebApi
dotnet run
```
---
## 📜 Acknowledgments

- **MediatR Library**  
  Core inspiration from Jimmy Bogard's [MediatR](https://github.com/jbogard/MediatR) implementation

- **.NET Community**  
  For Dependency Injection and async design best practices

- **OSS Contributors**  
  For sharing architectural knowledge and patterns
