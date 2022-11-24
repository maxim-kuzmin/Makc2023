// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.UserInternalPermission;

/// <summary>
/// Загрузчик типа "Внутреннее разрешение пользователя".
/// </summary>
public class UserInternalPermissionTypeLoader : Loader<UserInternalPermissionTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public UserInternalPermissionTypeLoader(UserInternalPermissionTypeEntity? target = null)
        : base(target ?? new UserInternalPermissionTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        UserInternalPermissionTypeEntity source,
        HashSet<string>? loadableProperties = null)
    {
        var result = base.Load(source, loadableProperties);

        if (result.Contains(nameof(Target.UserId)))
        {
            Target.UserId = source.UserId;
        }

        if (result.Contains(nameof(Target.InternalPermissionId)))
        {
            Target.InternalPermissionId = source.InternalPermissionId;
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
                nameof(Target.UserId),
                nameof(Target.InternalPermissionId)
            };
    }

    #endregion Protected methods
}
