// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Внутренний домен".
/// </summary>
public class InternalDomainEntity : Entity<long>
{
    #region Fields

    private readonly List<InternalPermissionEntity> _internalPermissionList = new();

    #endregion Fields

    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public InternalDomainTypeEntity Data { get; init; }

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение".
    /// </summary>
    public IReadOnlyCollection<InternalPermissionEntity> InternalPermissionList => _internalPermissionList;

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public InternalDomainEntity(InternalDomainTypeEntity data)
    {
        Data = data;
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Добавить экземпляр сущности "Фиктивное отношение многие к одному".
    /// </summary>
    /// <param name="data">Данные.</param>
    /// <returns>Добавленный экземпляр.</returns>
    public InternalPermissionEntity AddInternalPermission(InternalPermissionTypeEntity data)
    {
        var result = _internalPermissionList.Where(x => x.Data.Name == data.Name).SingleOrDefault();

        if (result is null)
        {
            data.InternalDomainId = GetId();

            result = new InternalPermissionEntity(data);

            _internalPermissionList.Add(result);
        }

        return result;
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}