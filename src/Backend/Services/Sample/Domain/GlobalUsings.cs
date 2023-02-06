// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using Makc2023.Backend.Common.Core.Converting;
global using Makc2023.Backend.Common.Core.Exceptions;
global using Makc2023.Backend.Common.Core.Operation;
global using Makc2023.Backend.Common.Core.Operation.Handlers;
global using Makc2023.Backend.Common.Core.Setup;
global using Makc2023.Backend.Common.Data.SQL.Operations.Item.Get;
global using Makc2023.Backend.Common.Data.SQL.Operations.List.Get;
global using Makc2023.Backend.Common.Domain;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyMain;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyManyToMany;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyManyToOne;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyOneToMany;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyTree;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.InternalDomain;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.InternalPermission;
global using Makc2023.Backend.Services.Sample.Data.SQL.Types.User;
global using Makc2023.Backend.Services.Sample.Domain.Entities;
global using Makc2023.Backend.Services.Sample.Domain.Exceptions;
global using Makc2023.Backend.Services.Sample.Domain.Operations.DummyMain.Item.Get;
global using Makc2023.Backend.Services.Sample.Domain.Operations.DummyMain.List.Get;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
