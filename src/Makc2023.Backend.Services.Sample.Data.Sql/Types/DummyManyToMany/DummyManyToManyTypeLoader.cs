// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Types.DummyManyToMany;

/// <summary>
/// Загрузчик типа "Фиктивное отношение многие ко многим".
/// </summary>
public class DummyManyToManyTypeLoader : Loader<DummyManyToManyTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyManyToManyTypeLoader(DummyManyToManyTypeEntity? target = null)
        : base(target ?? new DummyManyToManyTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        DummyManyToManyTypeEntity source,
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
