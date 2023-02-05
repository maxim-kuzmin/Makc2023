﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using Makc2023.Backend.Common.Core.App;
global using MediatR;
global using Microsoft.Extensions.Localization;
global using ModuleOfBackendCore = Makc2023.Backend.Common.Core.Setup.SetupAppModule;
global using ModuleOfBackendDataSqlClientsSqlServer = Makc2023.Backend.Common.Data.Sql.Clients.SqlServer.Setup.ClientSetupAppModule;
global using ModuleOfBackendDataSqlMappersEF = Makc2023.Backend.Common.Data.Sql.Mappers.EF.Setup.MapperSetupAppModule;
global using ModuleOfBackendDataSql = Makc2023.Backend.Common.Data.Sql.Setup.SetupAppModule;
global using ModuleOfBackendDomain = Makc2023.Backend.Common.Domain.Setup.SetupAppModule;
global using ModuleOfBackendDomainSqlMappersEF = Makc2023.Backend.Common.Domain.Sql.Mappers.EF.Setup.MapperSetupAppModule;
global using ModuleOfServiceDataSqlClientsSqlServer = Makc2023.Backend.Services.Sample.Data.Sql.Clients.SqlServer.Setup.ClientSetupAppModule;
global using ModuleOfServiceDataSqlMappersEFClientsSqlServer = Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Clients.SqlServer.Setup.ClientMapperSetupAppModule;
global using ModuleOfServiceDataSqlMappersEF = Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Setup.MapperSetupAppModule;
global using ModuleOfServiceDataSql = Makc2023.Backend.Services.Sample.Data.Sql.Setup.SetupAppModule;
global using ModuleOfServiceDomainsDummyMain = Makc2023.Backend.Services.Sample.Domains.DummyMain.Setup.DomainSetupAppModule;