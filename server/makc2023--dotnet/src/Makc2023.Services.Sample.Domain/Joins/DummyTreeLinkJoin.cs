namespace Makc2023.Services.Sample.Domain.Joins;

/// <summary>
/// Соединение связи фиктивного дерева.
/// </summary>
public class DummyTreeLinkJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор родителя.
    /// </summary>
    public int ParentId { get; set; }

    #endregion Properties    
}
