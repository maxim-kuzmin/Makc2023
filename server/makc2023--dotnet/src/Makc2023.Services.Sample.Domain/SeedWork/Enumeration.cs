namespace Makc2023.Services.Sample.Domain.SeedWork;

/// <summary>
/// Перечисление.
/// </summary>
public abstract class Enumeration : IComparable
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; private set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="name">Имя.</param>
    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Абсолютная разница.
    /// </summary>
    /// <param name="firstValue">Первое значение.</param>
    /// <param name="secondValue">Второе значение.</param>
    /// <returns>Разница между первым и вторым значением.</returns>
    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        return Math.Abs(firstValue.Id - secondValue.Id);
    }

    /// <inheritdoc/>
    public int CompareTo(object? other) => Id.CompareTo(((Enumeration)other!).Id);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());

        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    /// <summary>
    /// Получить элемент перечисления по имени.
    /// </summary>
    /// <typeparam name="T">Тип перечисления.</typeparam>
    /// <param name="displayName">Имя экземпляра перечисления.</param>
    /// <returns>Перечисление.</returns>
    public static T FromDisplayName<T>(string displayName) where T : Enumeration
    {
        return Parse<T, string>(displayName, "display name", item => item.Name == displayName);
    }

    /// <summary>
    /// Получить экземпляр перечисления по идентификатору.
    /// </summary>
    /// <typeparam name="T">Тип перечисления.</typeparam>
    /// <param name="value">Значение идентификатора экземпляра перечисления.</param>
    /// <returns>Перечисление.</returns>
    public static T FromValue<T>(int value) where T : Enumeration
    {
        return Parse<T, int>(value, "value", item => item.Id == value);
    }

    /// <summary>
    /// Получить все экземпляры перечисления.
    /// </summary>
    /// <typeparam name="T">Тип перечисления.</typeparam>
    /// <returns>Экземпляры перечисления.</returns>
    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                    .Select(f => f.GetValue(null))
                    .Cast<T>();

    /// <inheritdoc/>
    public override int GetHashCode() => Id.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => Name;

    #endregion Public methods

    #region Private methods

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var result = GetAll<T>().FirstOrDefault(predicate);

        if (result == null)
        {
            throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
        }

        return result;
    }

    #endregion Private methods
}
