// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation;

/// <summary>
/// Расширение операции.
/// </summary>
public static class OperationExtension
{
    #region Public methods

    /// <summary>
    /// Добавить.
    /// </summary>
    /// <param name="operationResults">Результаты операции.</param>
    /// <param name="functionToGetOperationResult">Функция для получения результата операции.</param>
    public static void Add(ICollection<OperationResult> operationResults, Func<OperationResult> functionToGetOperationResult)
    {
        var operationResult = functionToGetOperationResult.Invoke();

        operationResults.Add(operationResult);
    }

    /// <summary>
    /// Добавить с выходными данными.
    /// </summary>
    /// <typeparam name="TOutput">Тип выходных данных.</typeparam>
    /// <param name="operationResults">Результаты операции.</param>
    /// <param name="functionToGetOperationResult">Функция для получения результата операции.</param>
    /// <param name="actionToSetOutput">Действие по установке выходных данных.</param>
    /// <returns>Признак успешной установки выходных данных.</returns>
    public static bool AddWithOutput<TOutput>(
        this ICollection<OperationResult> operationResults,
        Func<OperationResultWithOutput<TOutput>> functionToGetOperationResult,
        Action<TOutput> actionToSetOutput
        ) where TOutput : class
    {
        var operationResult = functionToGetOperationResult.Invoke();

        operationResults.Add(operationResult);

        if (operationResult.IsOk && operationResult.Output != null)
        {
            actionToSetOutput.Invoke(operationResult.Output);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Добавить.
    /// </summary>
    /// <param name="operationResults">Результаты операции.</param>
    /// <param name="functionToGetOperationResultTask">
    /// Функция для получения задачи на получение результата операции.
    /// </param>
    /// <returns>Задача.</returns>
    public static async Task AddAsync(
        ICollection<OperationResult> operationResults,
        Func<Task<OperationResult>> functionToGetOperationResultTask
        )
    {
        var operationResult = await functionToGetOperationResultTask.Invoke().ConfigureAwait(false);

        operationResults.Add(operationResult);
    }

    /// <summary>
    /// Добавить с выходными данными асинхронно.
    /// </summary>
    /// <typeparam name="TOutput">Тип выходных данных.</typeparam>
    /// <param name="operationResults">Результаты операции.</param>
    /// <param name="functionToGetOperationResultTask">
    /// Функция для получения задачи на получение результата операции.
    /// </param>
    /// <param name="actionToSetOutput">Действие по установке выходных данных.</param>
    /// <returns>Задача на получение признака успешной установки выходных данных.</returns>
    public static async Task<bool> AddWithOutputAsync<TOutput>(
        this ICollection<OperationResult> operationResults,
        Func<Task<OperationResultWithOutput<TOutput>>> functionToGetOperationResultTask,
        Action<TOutput> actionToSetOutput
        ) where TOutput: class
    {
        var operationResult = await functionToGetOperationResultTask.Invoke().ConfigureAwait(false);

        operationResults.Add(operationResult);

        if (operationResult.IsOk && operationResult.Output != null)
        {
            actionToSetOutput.Invoke(operationResult.Output);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Загрузить.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    /// <param name="operationResultsToLoad">Результаты операции для загрузки.</param>
    public static void Load(this OperationResult operationResult, IEnumerable<OperationResult> operationResultsToLoad)
    {
        bool isOk = true;

        foreach (var operationResultToLoad in operationResultsToLoad)
        {
            isOk = isOk && operationResultToLoad.IsOk;

            operationResult.ErrorMessages.UnionWith(operationResultToLoad.ErrorMessages);
        }

        operationResult.IsOk = isOk;
    }

    #endregion Public methods
}
