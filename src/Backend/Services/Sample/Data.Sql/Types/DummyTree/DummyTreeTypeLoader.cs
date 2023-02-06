// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Types.DummyTree;

/// <summary>
/// Загрузчик типа "Фиктивное дерево".
/// </summary>
public class DummyTreeTypeLoader : Loader<DummyTreeTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyTreeTypeLoader(DummyTreeTypeEntity? target = null)
        : base(target ?? new DummyTreeTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        DummyTreeTypeEntity source,
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

        if (result.Contains(nameof(Target.ParentId)))
        {
            Target.ParentId = source.ParentId;
        }

        if (result.Contains(nameof(Target.TreeChildCount)))
        {
            Target.TreeChildCount = source.TreeChildCount;
        }

        if (result.Contains(nameof(Target.TreeDescendantCount)))
        {
            Target.TreeDescendantCount = source.TreeDescendantCount;
        }

        if (result.Contains(nameof(Target.TreeLevel)))
        {
            Target.TreeLevel = source.TreeLevel;
        }

        if (result.Contains(nameof(Target.TreePath)))
        {
            Target.TreePath = source.TreePath;
        }

        if (result.Contains(nameof(Target.TreePosition)))
        {
            Target.TreePosition = source.TreePosition;
        }

        if (result.Contains(nameof(Target.TreeSort)))
        {
            Target.TreeSort = source.TreeSort;
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
            nameof(Target.ParentId),
            nameof(Target.TreeChildCount),
            nameof(Target.TreeDescendantCount),
            nameof(Target.TreeLevel),
            nameof(Target.TreePath),
            nameof(Target.TreeSort)
        };
    }

    #endregion Protected methods
}
