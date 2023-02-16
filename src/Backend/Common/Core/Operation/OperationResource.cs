// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation;

/// <summary>
/// Ресурс операции.
/// </summary>
public class OperationResource : IOperationResource
{
    #region Fields

    private readonly IStringLocalizer _localizer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public OperationResource(IStringLocalizer<OperationResource> localizer)
    {
        _localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForDefault()
    {
        return _localizer["@@ErrorMessageForDefault"];
    }

    /// <inheritdoc/>
    public string GetErrorMessageForInvalidInput(IEnumerable<string> invalidProperties)
    {
        return _localizer["@@ErrorMessageForInvalidInput", string.Join(", ", invalidProperties)];
    }

    /// <inheritdoc/>
    public string GetErrorMessageWithCode(string errorMessage, string code)
    {
        string title = _localizer["@@TitleForErrorCode"];

        return $"{errorMessage}. {title}: {code}".Replace("!.", "!").Replace("?.", "?");
    }

    /// <inheritdoc/>
    public string GetTitleForError()
    {
        return _localizer["@@TitleForError"];
    }

    /// <inheritdoc/>
    public string GetTitleForInput()
    {
        return _localizer["@@TitleForInput"];
    }

    /// <inheritdoc/>
    public string GetTitleForOperationCode()
    {
        return _localizer["@@TitleForOperationCode"];
    }    

    /// <inheritdoc/>
    public string GetTitleForResult()
    {
        return _localizer["@@TitleForResult"];
    }

    /// <inheritdoc/>
    public string GetTitleForStart()
    {
        return _localizer["@@TitleForStart"];
    }

    /// <inheritdoc/>
    public string GetTitleForSuccess()
    {
        return _localizer["@@TitleForSuccess"];
    }

    #endregion Public methods
}
