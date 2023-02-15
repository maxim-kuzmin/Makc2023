// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.Mediator.Behaviors;

/// <summary>
/// Поведение логирующего посредника.
/// </summary>
/// <typeparam name="TRequest">Тип запроса.</typeparam>
/// <typeparam name="TResponse">Тип отклика.</typeparam>
public class MediatorLoggingBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Properties

    private ILogger Logger { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="logger">Регистратор.</param>
    public MediatorLoggingBehavior(
        ILogger<MediatorLoggingBehavior<TRequest, TResponse>> logger)
    {
        Logger = logger;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation(
            "----- Handling command {CommandName} ({@Command})",
            request.GetGenericTypeName(),
            request);

        var response = await next().ConfigureAwait(false);
        
        Logger.LogInformation(
            "----- Command {CommandName} handled - response: {@Response}",
            request.GetGenericTypeName(),
            response);

        return response;
    }

    #endregion Public methods
}
