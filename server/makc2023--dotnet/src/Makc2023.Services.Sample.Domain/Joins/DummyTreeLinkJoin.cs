namespace Makc2023.Services.Sample.Domain.Joins;

/// <summary>
/// Соединение "Связь фиктивного дерева".
/// </summary>
public class DummyTreeLinkJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Идентификатор родителя.
    /// </summary>
    public int ParentId { get; private set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected DummyTreeLinkJoin()
    {
        if (Id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(Id));
        }

        if (ParentId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(ParentId));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="parentId">Идентификатор родителя.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public DummyTreeLinkJoin(int id, int parentId)
    {
        Id = id < 1
            ? throw new ArgumentOutOfRangeException(nameof(id))
            : id;

        ParentId = parentId < 1
            ? throw new ArgumentOutOfRangeException(nameof(parentId))
            : parentId;
    }

    #endregion Constructors
}
