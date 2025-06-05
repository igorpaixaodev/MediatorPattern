namespace Mediator.Abstractions.Interfaces
{
    /// <summary>
    /// Defines a contract for sending requests to handlers through the Mediator pattern.
    /// </summary>
    /// <remarks>
    /// <b>Tradução em português:</b><br/>
    /// Define um contrato para envio de requisições para manipuladores através do padrão Mediator.
    /// </remarks>
    public interface IMediator
    {
        /// <summary>
        /// Sends a request to the appropriate handler and returns the response asynchronously.
        /// <br/>
        ///<b>(Português)</b> Envia uma requisição para o manipulador apropriado e retorna a resposta de forma assíncrona.
        /// </summary>
        /// <typeparam name="TResponse">
        /// The type of the response expected from the handler.
        /// 
        ///  <b>(Português)</b><br/>O tipo da resposta esperada do manipulador.
        /// </typeparam>
        /// <param name="request">
        /// The request object to be processed.
        /// <br/>
        /// <b>(Português)</b> O objeto de requisição a ser processado.
        /// </param>
        /// <param name="cancellationToken">
        /// A token that can be used to cancel the operation.
        /// <br/>
        /// <b>(Português)</b> Um token que pode ser usado para cancelar a operação.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, with the response from the handler.
        /// <br/>
        /// <b>(Português)</b> Uma tarefa que representa a operação assíncrona, contendo a resposta do manipulador.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no handler is found for the specified request type or if the handler returns an invalid response type.
        /// <br/>
        /// <b>(Português)</b>  Lançada quando nenhum manipulador é encontrado para o tipo de requisição informado ou quando o manipulador retorna um tipo de resposta inválido.
        /// </exception>
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }

}
