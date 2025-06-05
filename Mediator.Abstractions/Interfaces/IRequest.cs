namespace Mediator.Abstractions.Interfaces;

/// <summary>
/// Represents a request that expects a response of type <typeparamref name="TResponse"/>.
/// <br/>
/// <b>(Português)</b> Representa uma requisição que espera uma resposta do tipo <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">
/// The type of response returned when this request is handled.
/// 
/// (Português) O tipo de resposta retornado quando esta requisição for tratada.
/// </typeparam>
public interface IRequest<TResponse>;