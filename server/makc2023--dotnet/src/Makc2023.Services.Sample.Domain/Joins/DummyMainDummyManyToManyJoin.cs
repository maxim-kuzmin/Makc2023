namespace Makc2023.Services.Sample.Domain.Joins;

/// <summary>
/// Соединение "Фиктивное отношение многие ко многим фиктивного главного".
/// 
/// Служит для соединения экземпляров сущностей "Фиктивное главное" и
/// "Фиктивное отношение многие ко многим".
/// </summary>
public class DummyMainDummyManyToManyJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное главное".
    /// </summary>
    public int DummyMainId { get; private set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public int DummyManyToManyId { get; private set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected DummyMainDummyManyToManyJoin()
    {
        if (DummyMainId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(DummyMainId));
        }

        if (DummyManyToManyId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(DummyManyToManyId));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dummyMainId">Идентификатор экземпляра сущности "Фиктивное главное".</param>
    /// <param name="dummyManyToManyId">Идентификатор экземпляра сущности "Фиктивное отношение многие ко многим".</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public DummyMainDummyManyToManyJoin(int dummyMainId, int dummyManyToManyId)
    {
        DummyMainId = dummyMainId < 1
            ? throw new ArgumentOutOfRangeException(nameof(dummyMainId))
            : dummyMainId;

        DummyManyToManyId = dummyManyToManyId < 1
            ? throw new ArgumentOutOfRangeException(nameof(dummyManyToManyId))
            : dummyManyToManyId;
    }

    #endregion Constructors
}
