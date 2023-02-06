// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.User;

/// <summary>
/// Загрузчик типа "Пользователь".
/// </summary>
public class UserTypeLoader : Loader<UserTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public UserTypeLoader(UserTypeEntity? target = null)
        : base(target ?? new UserTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        UserTypeEntity source,
        HashSet<string>? loadableProperties = null)
    {
        var result = base.Load(source, loadableProperties);

        if (result.Contains(nameof(Target.Id)))
        {
            Target.Id = source.Id;
        }

        if (result.Contains(nameof(Target.Name)))
        {
            Target.Name = source.Name ?? string.Empty;
        }

        if (result.Contains(nameof(Target.Email)))
        {
            Target.Email = source.Email;
        }

        if (result.Contains(nameof(Target.IsBlocked)))
        {
            Target.IsBlocked = source.IsBlocked;
        }

        return result;
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected override HashSet<string> CreateAllPropertiesToLoad()
    {
        return new HashSet<string>
            {
                nameof(Target.Id),
                nameof(Target.Name),
                nameof(Target.Email),
                nameof(Target.IsBlocked)
            };
    }

    #endregion Protected methods
}
