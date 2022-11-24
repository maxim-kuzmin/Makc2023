// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.InternalPermission;

/// <summary>
/// Загрузчик типа "Внутреннее разрешение".
/// </summary>
public class InternalPermissionTypeLoader : Loader<InternalPermissionTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public InternalPermissionTypeLoader(InternalPermissionTypeEntity? target = null)
        : base(target ?? new InternalPermissionTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        InternalPermissionTypeEntity source,
        HashSet<string>? loadableProperties = null)
    {
        var result = base.Load(source, loadableProperties);

        if (result.Contains(nameof(Target.Id)))
        {
            Target.Id = source.Id;
        }

        if (result.Contains(nameof(Target.Name)))
        {
            Target.Name = source.Name;
        }

        if (result.Contains(nameof(Target.InternalDomainId)))
        {
            Target.InternalDomainId = source.InternalDomainId;
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
            nameof(Target.InternalDomainId)
        };
    }

    #endregion Protected methods
}
