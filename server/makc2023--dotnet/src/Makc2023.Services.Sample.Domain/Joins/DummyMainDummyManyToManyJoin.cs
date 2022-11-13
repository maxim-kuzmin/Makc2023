namespace Makc2023.Services.Sample.Domain.Joins;

/// <summary>
/// Соединение фиктивной главной сущности и фиктивной сущности многие ко многим.
/// </summary>
public class DummyMainDummyManyToManyJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор фиктивной главной сущности.
    /// </summary>
    public int DummyMainId { get; set; }

    /// <summary>
    /// Идентификатор сущности многие ко многим.
    /// </summary>
    public int DummyManyToManyId { get; set; }

    #endregion Properties    
}
