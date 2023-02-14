﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using Makc2023.Backend.Common.Core.App;
global using Makc2023.Backend.Common.Core.Exceptions;
global using Makc2023.Backend.Common.Core.Exceptions.VariableExceptions;
global using Makc2023.Backend.Common.Core.Operation;
global using Makc2023.Backend.Common.Core.Operation.Handlers;
global using Makc2023.Backend.Common.Core.Setup;
global using Makc2023.Backend.Common.Data.SQL.Operations.List.Get;
global using Makc2023.Backend.Common.Domain.SQL.Mappers.EF;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Db;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyMain;
global using Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyManyToMany;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyMain;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyOneToMany;
global using Makc2023.Backend.Services.Sample.Domain.SQL.Entities;
global using Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.Item.Get;
global using Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.List.Get;
global using Makc2023.Backend.Services.Sample.Domain.SQL.Repositories;
global using Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.Item.Get;
global using Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.List.Get;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;