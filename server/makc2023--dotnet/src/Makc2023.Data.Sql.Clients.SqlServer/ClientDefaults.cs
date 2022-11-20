// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Data.Clients.SqlServer;

/// <summary>
/// Значения по умолчанию клиента.
/// </summary>
public class ClientDefaults : IDefaults
{
    #region Properties

    /// <inheritdoc/>
    public string DbColumnForId => "id";

    /// <inheritdoc/>
    public string DbColumnForName => "name";

    /// <inheritdoc/>
    public string DbColumnForParentId => "parent_id";

    /// <inheritdoc/>
    public string DbColumnForTreeChildCount => "tree_child_count";

    /// <inheritdoc/>
    public string DbColumnForTreeDescendantCount => "tree_descendant_count";

    /// <inheritdoc/>
    public string DbColumnForTreeLevel => "tree_level";

    /// <inheritdoc/>
    public string DbColumnForTreePath => "tree_path";

    /// <inheritdoc/>
    public string DbColumnForTreePosition => "tree_position";

    /// <inheritdoc/>
    public string DbColumnForTreeSort => "tree_sort";

    /// <inheritdoc/>
    public string DbColumnPartsSeparator => "_";

    /// <inheritdoc/>
    public string DbForeignKeyPrefix => "fk";

    /// <inheritdoc/>
    public string DbIndexPrefix => "ix";

    /// <inheritdoc/>
    public string DbPrimaryKeyPrefix => "pk";

    /// <inheritdoc/>
    public string DbSchema => "public";

    /// <inheritdoc/>
    public string DbUniqueIndexPrefix => "ux";

    /// <inheritdoc/>
    public string FullNamePartsSeparator => ".";

    /// <inheritdoc/>
    public string NamePartsSeparator => "_";

    #endregion Properties
}
