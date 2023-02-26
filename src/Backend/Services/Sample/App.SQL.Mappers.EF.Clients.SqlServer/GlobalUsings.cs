﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Data.SqlClient;
global using Makc2023.Backend.Common.Core.App;
global using Makc2023.Backend.Common.Core.Apps.WebApp;
global using Makc2023.Backend.Common.Core.Apps.WebApp.Setup;
global using Makc2023.Backend.Common.Core.Repeat;
global using Makc2023.Backend.Services.Sample.App.SQL.Mappers.EF.Clients.SqlServer.Setup;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Localization;
global using ModuleOfCommonCore = Makc2023.Backend.Common.Core.Setup.SetupAppModule;
global using ModuleOfCommonDataSQLClientsSqlServer = Makc2023.Backend.Common.Data.SQL.Clients.SqlServer.Setup.ClientSetupAppModule;
global using ModuleOfCommonDataSQLMappersEF = Makc2023.Backend.Common.Data.SQL.Mappers.EF.Setup.MapperSetupAppModule;
global using ModuleOfCommonDataSQL = Makc2023.Backend.Common.Data.SQL.Setup.SetupAppModule;
global using ModuleOfCommonDomain = Makc2023.Backend.Common.Domain.Setup.SetupAppModule;
global using ModuleOfCommonDomainSqlMappersEF = Makc2023.Backend.Common.Domain.SQL.Mappers.EF.Setup.MapperSetupAppModule;
global using ModuleOfServiceApp = Makc2023.Backend.Services.Sample.App.SQL.Mappers.EF.Clients.SqlServer.Setup.SetupAppModule;
global using ModuleOfServiceDataSQLClientsSqlServer = Makc2023.Backend.Services.Sample.Data.SQL.Clients.SqlServer.Setup.ClientSetupAppModule;
global using ModuleOfServiceDataSQLMappersEFClientsSqlServer = Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Setup.ClientMapperSetupAppModule;
global using ISetupServiceOfServiceDataSQL = Makc2023.Backend.Services.Sample.Data.SQL.Setup.ISetupService;
global using ModuleOfServiceDataSQL = Makc2023.Backend.Services.Sample.Data.SQL.Setup.SetupAppModule;
global using ModuleOfServiceDomainSQL = Makc2023.Backend.Services.Sample.Domain.SQL.Setup.SetupAppModule;
global using RequestHandlerOfServiceDomainsDummyMainOperationsItemGet = Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.Item.Get.DomainItemGetOperationRequestHandler;
global using RequestHandlerOfServiceDomainsDummyMainOperationsListGet = Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.List.Get.DomainListGetOperationRequestHandler;
global using ModuleOfServiceDomainsDummyMain = Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Setup.DomainSetupAppModule;
