// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Types.DummyMain;

/// <summary>
/// Загрузчик типа "Фиктивное главное".
/// </summary>
public class DummyMainTypeLoader : Loader<DummyMainTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyMainTypeLoader(DummyMainTypeEntity? target = null)
        : base(target ?? new DummyMainTypeEntity())
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override HashSet<string> Load(
        DummyMainTypeEntity source,
        HashSet<string>? loadableProperties = null)
    {
        var result = base.Load(source, loadableProperties);

        if (result.Contains(nameof(Target.Id)))
        {
            Target.Id = source.Id;
        }

        if (result.Contains(nameof(Target.DummyOneToManyId)))
        {
            Target.DummyOneToManyId = source.DummyOneToManyId;
        }

        if (result.Contains(nameof(Target.Name)))
        {
            Target.Name = source.Name ?? string.Empty;
        }

        if (result.Contains(nameof(Target.PropBoolean)))
        {
            Target.PropBoolean = source.PropBoolean;
        }

        if (result.Contains(nameof(Target.PropBooleanNullable)))
        {
            Target.PropBooleanNullable = source.PropBooleanNullable;
        }

        if (result.Contains(nameof(Target.PropDate)))
        {
            Target.PropDate = source.PropDate;
        }

        if (result.Contains(nameof(Target.PropDateNullable)))
        {
            Target.PropDateNullable = source.PropDateNullable;
        }

        if (result.Contains(nameof(Target.PropDateTime)))
        {
            Target.PropDateTime = source.PropDateTime;
        }

        if (result.Contains(nameof(Target.PropDateTimeNullable)))
        {
            Target.PropDateTimeNullable = source.PropDateTimeNullable;
        }

        if (result.Contains(nameof(Target.PropDecimal)))
        {
            Target.PropDecimal = source.PropDecimal;
        }

        if (result.Contains(nameof(Target.PropDecimalNullable)))
        {
            Target.PropDecimalNullable = source.PropDecimalNullable;
        }

        if (result.Contains(nameof(Target.PropInt32)))
        {
            Target.PropInt32 = source.PropInt32;
        }

        if (result.Contains(nameof(Target.PropInt32Nullable)))
        {
            Target.PropInt32Nullable = source.PropInt32Nullable;
        }

        if (result.Contains(nameof(Target.PropInt64)))
        {
            Target.PropInt64 = source.PropInt64;
        }

        if (result.Contains(nameof(Target.PropInt64Nullable)))
        {
            Target.PropInt64Nullable = source.PropInt64Nullable;
        }

        if (result.Contains(nameof(Target.PropString)))
        {
            Target.PropString = source.PropString ?? string.Empty;
        }

        if (result.Contains(nameof(Target.PropStringNullable)))
        {
            Target.PropStringNullable = source.PropStringNullable;
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
                nameof(Target.DummyOneToManyId),
                nameof(Target.PropBoolean),
                nameof(Target.PropBooleanNullable),
                nameof(Target.PropDate),
                nameof(Target.PropDateNullable),
                nameof(Target.PropDateTime),
                nameof(Target.PropDateTimeNullable),
                nameof(Target.PropDecimal),
                nameof(Target.PropDecimalNullable),
                nameof(Target.PropInt32),
                nameof(Target.PropInt32Nullable),
                nameof(Target.PropInt64),
                nameof(Target.PropInt64Nullable),
                nameof(Target.PropString),
                nameof(Target.PropStringNullable)
            };
    }

    #endregion Protected methods
}
