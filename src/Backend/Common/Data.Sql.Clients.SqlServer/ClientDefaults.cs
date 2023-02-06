// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Clients.SqlServer;

/// <summary>
/// Значения по умолчанию клиента.
/// </summary>
public class ClientDefaults : IDefaults
{
    #region Properties

    /// <inheritdoc/>
    public string DbColumnForId => "Id";

    /// <inheritdoc/>
    public string DbColumnForName => "Name";

    /// <inheritdoc/>
    public string DbColumnForParentId => "ParentId";

    /// <inheritdoc/>
    public string DbColumnForTreeChildCount => "TreeChildCount";

    /// <inheritdoc/>
    public string DbColumnForTreeDescendantCount => "TreeDescendantCount";

    /// <inheritdoc/>
    public string DbColumnForTreeLevel => "TreeLevel";

    /// <inheritdoc/>
    public string DbColumnForTreePath => "TreePath";

    /// <inheritdoc/>
    public string DbColumnForTreePosition => "TreePosition";

    /// <inheritdoc/>
    public string DbColumnForTreeSort => "TreeSort";

    /// <inheritdoc/>
    public string DbColumnPartsSeparator => "_";

    /// <inheritdoc/>
    public string DbForeignKeyPrefix => "FK";

    /// <inheritdoc/>
    public string DbIndexPrefix => "IX";

    /// <inheritdoc/>
    public string DbPrimaryKeyPrefix => "PK";

    /// <inheritdoc/>
    public string DbSchema => "dbo";

    /// <inheritdoc/>
    public string DbUniqueIndexPrefix => "UX";

    /// <inheritdoc/>
    public string FullNamePartsSeparator => ".";

    /// <inheritdoc/>
    public string NamePartsSeparator => "_";

    #endregion Properties
}
