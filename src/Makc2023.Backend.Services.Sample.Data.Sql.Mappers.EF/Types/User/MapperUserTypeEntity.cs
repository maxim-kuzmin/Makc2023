// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Types.User;

/// <summary>
/// Сущность типа "Пользователь" сопоставителя.
/// </summary>
public class MapperUserTypeEntity : UserTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение пользователя".
    /// </summary>
    public List<MapperUserInternalPermissionTypeEntity> UserInternalPermissionList { get; } = new();

    #endregion Navigation properties
}
