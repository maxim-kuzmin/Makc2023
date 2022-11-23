// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using Makc2023.Core.App;
global using Makc2023.Core.Exceptions.VariableExceptions;
global using Makc2023.Data.Sql;
global using Makc2023.Services.Sample.Data.Entities;
global using Makc2023.Services.Sample.Data.Joins;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyMain;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyMainDummyManyToMany;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyManyToMany;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyManyToOne;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyOneToMany;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyTree;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyTreeLink;
global using Makc2023.Services.Sample.Data.Sql.Types.InternalDomain;
global using Makc2023.Services.Sample.Data.Sql.Types.InternalPermission;
global using Makc2023.Services.Sample.Data.Sql.Types.User;
global using Makc2023.Services.Sample.Data.Sql.Types.UserInternalPermission;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
