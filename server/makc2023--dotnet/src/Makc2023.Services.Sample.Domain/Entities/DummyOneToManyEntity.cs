namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Фиктивное отношение один ко многим".
/// 
/// Служит для демонстрации связи одного экземпляра одной сущности
/// со многими экземплярами другой сущности.
///
/// Один экземпляр сущности "Фиктивное отношение один ко многим"
/// связан со многими экземплярами сущности "Фиктивное главное".
/// </summary>
public class DummyOneToManyEntity : Entity<int>
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
    /// <exception cref="NullReferenceException">
    /// Возникает, если NULL содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected DummyOneToManyEntity()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new NullReferenceException(nameof(Name));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public DummyOneToManyEntity(string name)
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    protected override int GetId() => Id;

    #endregion Public methods
}
