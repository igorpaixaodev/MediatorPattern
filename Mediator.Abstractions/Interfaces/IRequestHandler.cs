namespace Mediator.Abstractions.Interfaces;

/// <summary>
/// Defines a handler responsible for processing a specific request type and returning a response.
/// <br/>
/// <b>(Português)</b> Define um manipulador responsável por processar um tipo específico de requisição e retornar uma resposta.
/// </summary>
/// <typeparam name="TRequest">
/// The type of request to handle.
/// <br/>
/// <b>(Português)</b> O tipo de requisição a ser tratado.
/// </typeparam>
/// <typeparam name="TResponse">
/// The type of response produced by the handler.
/// <br/>
/// <b>(Português)</b> O tipo de resposta produzido pelo manipulador.
/// </typeparam>
public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Handles the given request and returns a response asynchronously.
    /// <br/>
    /// <b>(Português)</b> Trata a requisição fornecida e retorna uma resposta de forma assíncrona.
    /// </summary>
    /// <param name="request">
    /// The request to be handled.
    /// <br/>
    /// <b>(Português)</b> A requisição a ser tratada.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete.
    /// <br/>
    /// <b>(Português)</b> Um token para acompanhar o cancelamento da operação.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, yielding the result.
    /// <br/>
    /// <b>(Português)</b> Uma tarefa que representa a operação assíncrona, retornando o resultado.
    /// </returns>
    Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}

