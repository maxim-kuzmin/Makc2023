namespace Makc2023.Services.Sample.Domain.DummyMainAggregate;

/// <summary>
/// Макет части главной сущности.
/// </summary>
public class DummyMainPart : ValueObject
{
    #region Properties

    /// <summary>
    /// Свойство 1.
    /// </summary>
    public string Prop1 { get; private set; }

    /// <summary>
    /// Свойство 2.
    /// </summary>
    public string Prop2 { get; private set; }

    /// <summary>
    /// Свойство 3.
    /// </summary>
    public string Prop3 { get; private set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="prop1">Свойство 1.</param>
    public DummyMainPart(string prop1, string prop2, string prop3) =>
        (Prop1, Prop2, Prop3) = (prop1, prop2, prop3);

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Prop1;
    }

    #endregion Protected methods
}
