// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyMain;

/// <summary>
/// Сущность типа "Фиктивное главное".
/// 
/// Содержит в себе свойства наиболее распространённых типов данных.
/// </summary>
public class DummyMainTypeEntity
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public long DummyOneToManyId { get; set; }

    /// <summary>
    /// Свойство, содержащее логическое значение.
    /// </summary>
    public bool PropBoolean { get; set; }

    /// <summary>
    /// Свойство, содержащее логическое значение или NULL.
    /// </summary>
    public bool? PropBooleanNullable { get; set; }

    /// <summary>
    /// Свойство, содержащее дату.
    /// </summary>
    public DateTime PropDate { get; set; }

    /// <summary>
    /// Свойство, содержащее дату или NULL.
    /// </summary>
    public DateTime? PropDateNullable { get; set; }

    /// <summary>
    /// Свойство, содержащее дату и время с часовым поясом.
    /// </summary>
    public DateTimeOffset PropDateTime { get; set; }

    /// <summary>
    /// Свойство, содержащее дату и время с часовым поясом или NULL.
    /// </summary>
    public DateTimeOffset? PropDateTimeNullable { get; set; }

    /// <summary>
    /// Свойство, содержащее десятичную дробь.
    /// </summary>
    public decimal PropDecimal { get; set; }

    /// <summary>
    /// Свойство, содержащее десятичную дробь или NULL.
    /// </summary>
    public decimal? PropDecimalNullable { get; set; }

    /// <summary>
    /// Свойство, содержащее целое 32-разрядное число.
    /// </summary>
    public int PropInt32 { get; set; }

    /// <summary>
    /// Свойство, содержащее целое 32-разрядное число или NULL.
    /// </summary>
    public int? PropInt32Nullable { get; set; }

    /// <summary>
    /// Свойство, содержащее целое 64-разрядное число.
    /// </summary>
    public long PropInt64 { get; set; }

    /// <summary>
    /// Свойство, содержащее целое 64-разрядное число или NULL.
    /// </summary>
    public long? PropInt64Nullable { get; set; }

    /// <summary>
    /// Свойство, содержащее строку.
    /// </summary>
    public string? PropString { get; set; }

    /// <summary>
    /// Свойство, содержащее строку или NULL.
    /// </summary>
    public string? PropStringNullable { get; set; }

    #endregion Properties
}
