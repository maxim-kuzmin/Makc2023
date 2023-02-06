// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Reflection;
global using Makc2023.Backend.Common.Core.App;
global using Makc2023.Backend.Common.Core.Exceptions.VariableExceptions;
global using Makc2023.Backend.Common.Data.SQL.Mappers.EF;
global using Makc2023.Backend.Common.Data.SQL.Mappers.EF.Db;
global using Makc2023.Backend.Services.Sample.Data.SQL.Clients.SqlServer;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Db;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Db;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyMain;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyMainDummyManyToMany;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyManyToMany;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyManyToOne;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyOneToMany;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyTree;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyTreeLink;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.InternalDomain;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.InternalPermission;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.User;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.UserInternalPermission;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using DbSetupOptions = Makc2023.Backend.Common.Data.SQL.Setup.SetupOptions;
global using DbSetupOptionsForSample = Makc2023.Backend.Services.Sample.Data.SQL.Setup.SetupOptions;

