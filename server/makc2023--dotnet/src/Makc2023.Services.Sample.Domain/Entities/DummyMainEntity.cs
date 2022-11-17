namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Фиктивное главное".
/// 
/// Содержит в себе свойства наиболее распространённых типов данных.
/// </summary>
public class DummyMainEntity : Entity<int>, IAggregateRoot
{
    #region Fields

    private readonly List<DummyManyToOneEntity> _dummyManyToOneList;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public int DummyOneToManyId { get; private set; }

    /// <summary>
    /// Свойство, содержащее логическое значение.
    /// </summary>
    public bool PropBoolean { get; private set; }

    /// <summary>
    /// Свойство, содержащее логическое значение или NULL.
    /// </summary>
    public bool? PropBooleanNullable { get; private set; }

    /// <summary>
    /// Свойство, содержащее дату.
    /// </summary>
    public DateTime PropDate { get; private set; }

    /// <summary>
    /// Свойство, содержащее дату или NULL.
    /// </summary>
    public DateTime? PropDateNullable { get; private set; }

    /// <summary>
    /// Свойство, содержащее дату и время с часовым поясом.
    /// </summary>
    public DateTimeOffset PropDateTime { get; private set; }

    /// <summary>
    /// Свойство, содержащее дату и время с часовым поясом или NULL.
    /// </summary>
    public DateTimeOffset? PropDateTimeNullable { get; private set; }

    /// <summary>
    /// Свойство, содержащее десятичное дробное число.
    /// </summary>
    public decimal PropDecimal { get; private set; }

    /// <summary>
    /// Свойство, содержащее десятичное дробное число или NULL.
    /// </summary>
    public decimal? PropDecimalNullable { get; private set; }

    /// <summary>
    /// Свойство, содержащее перечисление.
    /// </summary>
    public DummyEnumeration PropEnumeration { get; private set; }

    /// <summary>
    /// Свойство, содержащее целое 32-разрядное число.
    /// </summary>
    public int PropInt32 { get; private set; }

    /// <summary>
    /// Свойство, содержащее целое 32-разрядное число или NULL.
    /// </summary>
    public int? PropInt32Nullable { get; private set; }

    /// <summary>
    /// Свойство, содержащее целое 64-разрядное число.
    /// </summary>
    public int PropInt64 { get; private set; }

    /// <summary>
    /// Свойство, содержащее целое 64-разрядное число или NULL.
    /// </summary>
    public int? PropInt64Nullable { get; private set; }

    /// <summary>
    /// Свойство, содержащее строку.
    /// </summary>
    public string PropString { get; private set; }

    /// <summary>
    /// Свойство, содержащее строку или NULL.
    /// </summary>
    public string? PropStringNullable { get; private set; }

    /// <summary>
    /// Свойство, содержащее объект-значение.
    /// </summary>
    public DummyValueObject PropValueObject { get; private set; }

    #endregion Properties    

    #region Navigation properties

    /// <summary>
    /// Список элементов соединения "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public List<DummyMainDummyManyToManyJoin>? DummyMainDummyManyToManyList { get; set; }

    /// <summary>
    /// Список элементов сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public ICollection<DummyManyToManyEntity>? DummyManyToManyList { get; set; }

    /// <summary>
    /// Список элементов сущности "Фиктивное отношение многие к одному".
    /// </summary>
    public IReadOnlyCollection<DummyManyToOneEntity> DummyManyToOneList => _dummyManyToOneList;

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public DummyOneToManyEntity? DummyOneToMany { get; set; }

    #endregion Navigation properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в свойстве, которое не должно его содержать.
    /// </exception>
    /// <exception cref="NullReferenceException">
    /// Возникает, если NULL содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected DummyMainEntity()
    {
        _dummyManyToOneList = new();

        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new NullReferenceException(nameof(Name));
        }

        if (DummyOneToManyId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(DummyOneToManyId));
        }

        if (PropEnumeration is null)
        {
            throw new NullReferenceException(nameof(PropEnumeration));
        }

        if (PropString is null)
        {
            throw new NullReferenceException(nameof(PropString));
        }

        if (PropValueObject is null)
        {
            throw new NullReferenceException(nameof(PropValueObject));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="dummyOneToManyId">Идентификатор фиктивного отношения один ко многим.</param>
    /// <param name="propBoolean">Свойство, содержащее логическое значение.</param>
    /// <param name="propBooleanNullable">Свойство, содержащее логическое значение или NULL.</param>
    /// <param name="propDate">Свойство, содержащее дату.</param>
    /// <param name="propDateNullable">Свойство, содержащее дату или NULL.</param>
    /// <param name="propDateTime">Свойство, содержащее дату и время с часовым поясом.</param>
    /// <param name="propDateTimeNullable">Свойство, содержащее дату и время с часовым поясом или NULL.</param>
    /// <param name="propDecimal">Свойство, содержащее десятичное дробное число.</param>
    /// <param name="propDecimalNullable">Свойство, содержащее десятичное дробное число или NULL.</param>
    /// <param name="propEnumeration">Свойство, содержащее перечисление.</param>
    /// <param name="propInt32">Свойство, содержащее целое 32-разрядное число.</param>
    /// <param name="propInt32Nullable">Свойство, содержащее целое 32-разрядное число или NULL.</param>
    /// <param name="propInt64">Свойство, содержащее целое 64-разрядное число.</param>
    /// <param name="propInt64Nullable">Свойство, содержащее целое 64-разрядное число или NULL.</param>
    /// <param name="propString">Свойство, содержащее строку.</param>
    /// <param name="propStringNullable">Свойство, содержащее строку или NULL.</param>
    /// <param name="propValueObject">Свойство, содержащее объект-значение.</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public DummyMainEntity(
        string name,
        int dummyOneToManyId,
        bool propBoolean,
        bool? propBooleanNullable,
        DateTime propDate,
        DateTime? propDateNullable,
        DateTime propDateTime,
        DateTime? propDateTimeNullable,
        decimal propDecimal,
        decimal? propDecimalNullable,
        DummyEnumeration propEnumeration,
        int propInt32,
        int? propInt32Nullable,
        int propInt64,
        int? propInt64Nullable,
        string propString,
        string? propStringNullable,
        DummyValueObject propValueObject) : this()

    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;

        DummyOneToManyId = dummyOneToManyId < 1
            ? throw new ArgumentOutOfRangeException(nameof(dummyOneToManyId))
            : dummyOneToManyId;

        PropBoolean = propBoolean;
        PropBooleanNullable = propBooleanNullable;

        PropDate = propDate;
        PropDateNullable = propDateNullable;

        PropDateTime = propDateTime;
        PropDateTimeNullable = propDateTimeNullable;

        PropDecimal = propDecimal;
        PropDecimalNullable = propDecimalNullable;

        PropEnumeration = propEnumeration;

        PropInt32 = propInt32;
        PropInt32Nullable = propInt32Nullable;

        PropInt64 = propInt64;
        PropInt64Nullable = propInt64Nullable;

        PropString = propString;
        PropStringNullable = propStringNullable;

        PropValueObject = propValueObject;
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Добавить экземпляр сущности "Фиктивное отношение многие к одному".
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Добавленный экземпляр.</returns>
    public DummyManyToOneEntity AddDummyManyToOne(string name)
    {
        var result = _dummyManyToOneList.Where(x => x.Name == name).SingleOrDefault();

        if (result is null)
        {
            result = new DummyManyToOneEntity(name);

            _dummyManyToOneList.Add(result);
        }

        return result;
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected override int GetId() => Id;

    #endregion Protected methods
}
