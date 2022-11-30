// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using Makc2023.Backend.Core.App;
global using Makc2023.Backend.Core.Exceptions;
global using Makc2023.Backend.Core.Exceptions.VariableExceptions;
global using Makc2023.Backend.Core.Operation;
global using Makc2023.Backend.Core.Operation.Handlers;
global using Makc2023.Backend.Core.Setup;
global using Makc2023.Backend.Data.Sql.Operations.List.Get;
global using Makc2023.Backend.Domain.Sql.Mappers.EF;
global using Makc2023.Services.Sample.Data.Sql.Mappers.EF.Db;
global using Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyMain;
global using Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyManyToMany;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyMain;
global using Makc2023.Services.Sample.Data.Sql.Types.DummyOneToMany;
global using Makc2023.Services.Sample.Domain.Entities;
global using Makc2023.Services.Sample.Domain.Operations.DummyMain.Item.Get;
global using Makc2023.Services.Sample.Domain.Operations.DummyMain.List.Get;
global using Makc2023.Services.Sample.Domain.Repositories;
global using Makc2023.Services.Sample.Domains.DummyMain.Operations.Item.Get;
global using Makc2023.Services.Sample.Domains.DummyMain.Operations.List.Get;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
