// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Clients.SqlServer;

/// <summary>
/// Параметры типов клиента.
/// </summary>
public class ClientTypesOptions : TypesOptions
{
    #region Fields

    private static readonly Lazy<TypesOptions> _lazy = new(() => new ClientTypesOptions());

    #endregion Fields

    #region Properties

    /// <summary>
    /// Экземпляр.
    /// </summary>
    public static TypesOptions Instance => _lazy.Value;

    #endregion Properties

    #region Constructors

    private ClientTypesOptions()
    {
        var defaults = new ClientDefaults();

        DummyOneToMany = new DummyOneToManyTypeOptions(defaults, "DummyOneToMany");

        DummyMain = new DummyMainTypeOptions(DummyOneToMany, defaults, "DummyMain");

        DummyManyToMany = new DummyManyToManyTypeOptions(defaults, "DummyManyToMany");

        DummyManyToOne = new DummyManyToOneTypeOptions(defaults, "DummyManyToOne");

        DummyMainDummyManyToMany = new DummyMainDummyManyToManyTypeOptions(
            DummyMain,
            DummyManyToMany,
            defaults,
            "DummyMainDummyManyToMany"
            );

        DummyTree = new DummyTreeTypeOptions(defaults, "DummyTree");

        DummyTreeLink = new DummyTreeLinkTypeOptions(DummyTree, defaults, "DummyTreeLink");

        InternalDomain = new InternalDomainTypeOptions(defaults, "InternalDomain");

        InternalPermission = new InternalPermissionTypeOptions(InternalDomain, defaults, "InternalPermission");

        User = new UserTypeOptions(defaults, "User");

        UserInternalPermission = new UserInternalPermissionTypeOptions(
            User,
            InternalPermission,
            defaults,
            "UserInternalPermission");
    }

    #endregion Constructors     
}
