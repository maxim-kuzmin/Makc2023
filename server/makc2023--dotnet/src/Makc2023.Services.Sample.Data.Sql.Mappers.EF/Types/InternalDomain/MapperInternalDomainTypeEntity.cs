// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.InternalDomain;

/// <summary>
/// Сущность типа "Внутренний домен" сопоставителя.
/// </summary>
public class MapperInternalDomainTypeEntity : InternalDomainTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение".
    /// </summary>
    public List<MapperInternalPermissionTypeEntity> InternalPermissionList { get; } = new();

    #endregion Navigation properties
}
