// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using Makc2023.Core.App;
global using Microsoft.Extensions.Localization;
global using ModuleOfCore = Makc2023.Core.Setup.SetupAppModule;
global using ModuleOfDataSqlClientsSqlServer = Makc2023.Data.Sql.Clients.SqlServer.Setup.ClientSetupAppModule;
global using ModuleOfDataSqlMappersEF = Makc2023.Data.Sql.Mappers.EF.Setup.MapperSetupAppModule;
global using ModuleOfDataSql = Makc2023.Data.Sql.Setup.SetupAppModule;
global using ModuleOfServicesSampleDataSqlClientsSqlServer = Makc2023.Services.Sample.Data.Sql.Clients.SqlServer.Setup.ClientSetupAppModule;
global using ModuleOfServicesSampleDataSqlMappersEFClientsSqlServer = Makc2023.Services.Sample.Data.Sql.Mappers.EF.Clients.SqlServer.Setup.ClientMapperSetupAppModule;
global using ModuleOfServicesSampleDataSqlMappersEF = Makc2023.Services.Sample.Data.Sql.Mappers.EF.Setup.MapperSetupAppModule;
global using ModuleOfServicesSampleDataSql = Makc2023.Services.Sample.Data.Sql.Setup.SetupAppModule;
