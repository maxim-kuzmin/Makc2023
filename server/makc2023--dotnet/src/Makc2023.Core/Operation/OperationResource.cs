// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Operation;

/// <summary>
/// Ресурс операции.
/// </summary>
public class OperationResource : IOperationResource
{
    #region Properties

    private IStringLocalizer<OperationResource> Localizer { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public OperationResource(IStringLocalizer<OperationResource> localizer)
    {
        Localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForDefault()
    {
        return Localizer["@@ErrorMessageForDefault"];
    }

    /// <inheritdoc/>
    public string GetErrorMessageForInvalidInput(IEnumerable<string> invalidProperties)
    {
        return Localizer["@@ErrorMessageForInvalidInput", string.Join(", ", invalidProperties)];
    }

    /// <inheritdoc/>
    public string GetErrorMessageWithCode(string errorMessage, string code)
    {
        string title = Localizer["@@TitleForErrorCode"];

        return $"{errorMessage}. {title}: {code}".Replace("!.", "!").Replace("?.", "?");
    }

    /// <inheritdoc/>
    public string GetTitleForError()
    {
        return Localizer["@@TitleForError"];
    }

    /// <inheritdoc/>
    public string GetTitleForInput()
    {
        return Localizer["@@TitleForInput"];
    }

    /// <inheritdoc/>
    public string GetTitleForOperationCode()
    {
        return Localizer["@@TitleForOperationCode"];
    }    

    /// <inheritdoc/>
    public string GetTitleForResult()
    {
        return Localizer["@@TitleForResult"];
    }

    /// <inheritdoc/>
    public string GetTitleForStart()
    {
        return Localizer["@@TitleForStart"];
    }

    /// <inheritdoc/>
    public string GetTitleForSuccess()
    {
        return Localizer["@@TitleForSuccess"];
    }

    #endregion Public methods
}
