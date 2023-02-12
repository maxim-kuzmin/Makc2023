// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyManyToOne;

/// <summary>
/// Сущность типа "Фиктивное отношение многие к одному" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyManyToOneTypeEntity : DummyManyToOneTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Фиктивное главное".
    /// </summary>
    public ClientMapperDummyMainTypeEntity? DummyMain { get; set; }

    #endregion Navigation properties
}