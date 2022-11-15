namespace Makc2023.Services.Sample.Domain.Enumerations;

/// <summary>
/// Фиктивное перечисление.
/// </summary>
public class DummyEnumeration : Enumeration
{
    #region Fields

    /// <summary>
    /// Значение 1.
    /// </summary>
    public static readonly DummyEnumeration Value1 = new(1, nameof(Value1).ToLowerInvariant());

    /// <summary>
    /// Зеачение 2.
    /// </summary>
    public static readonly DummyEnumeration Value2 = new(2, nameof(Value2).ToLowerInvariant());

    /// <summary>
    /// Значение 3.
    /// </summary>
    public static readonly DummyEnumeration Value3 = new(3, nameof(Value3).ToLowerInvariant());

    #endregion Fields

    #region Constructors

    /// <inheritdoc/>
    public DummyEnumeration(int id, string name)
        : base(id, name)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Получить список элементов перечисления.
    /// </summary>
    /// <returns>Список элементов перечисления.</returns>
    public static IEnumerable<DummyEnumeration> GetList()
    {
        yield return Value1;
        yield return Value2;
        yield return Value3;
    }

    /// <summary>
    /// Получить элемент перечисления по идентификатору.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <returns>Элемент перечисления.</returns>
    /// <exception cref="DomainException">Выбрасывается в случае, если элемент не найден.</exception>
    public static DummyEnumeration GetById(int id)
    {
        var result = GetList().SingleOrDefault(x => x.Id == id);

        if (result == null)
        {
            string possibleIds = string.Join(",", GetList().Select(x => x.Id));

            throw new DomainException($"Possible identifiers for {nameof(DummyEnumeration)}: {possibleIds}"); //makc//!!!//Localization//
        }

        return result;
    }

    /// <summary>
    /// Получить элемент перечисления по имени.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <returns>Элемент перечисления.</returns>
    /// <exception cref="DomainException">Выбрасывается в случае, если элемент не найден.</exception>
    public static DummyEnumeration GetByName(string name)
    {
        var result = GetList().SingleOrDefault(x => string.Equals(
            x.Name,
            name,
            StringComparison.CurrentCultureIgnoreCase));

        if (result == null)
        {
            string possibleNames = string.Join(",", GetList().Select(x => x.Name));

            throw new DomainException($"Possible names for {nameof(DummyEnumeration)}: {possibleNames}"); //makc//!!!//Localization//
        }

        return result;
    }

    #endregion Public methods
}
