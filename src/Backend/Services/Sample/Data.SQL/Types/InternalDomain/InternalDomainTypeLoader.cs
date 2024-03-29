﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.InternalDomain;

/// <summary>
/// Загрузчик типа "Внутренний домен".
/// </summary>
public class InternalDomainTypeLoader : Loader<InternalDomainTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public InternalDomainTypeLoader(InternalDomainTypeEntity? target = null)
        : base(target ?? new InternalDomainTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        InternalDomainTypeEntity source,
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
            nameof(Target.Name)
        };
    }

    #endregion Protected methods
}
