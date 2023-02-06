// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyManyToOne;

/// <summary>
/// Загрузчик типа "Фиктивное отношение многие к одному".
/// </summary>
public class DummyManyToOneTypeLoader : Loader<DummyManyToOneTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyManyToOneTypeLoader(DummyManyToOneTypeEntity? target = null)
        : base(target ?? new DummyManyToOneTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        DummyManyToOneTypeEntity source,
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

        if (result.Contains(nameof(Target.DummyMainId)))
        {
            Target.DummyMainId = source.DummyMainId;
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
            nameof(Target.DummyMainId)
        };
    }

    #endregion Protected methods
}
