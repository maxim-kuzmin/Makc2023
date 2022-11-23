// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Data;
global using System.Data.Common;
global using Makc2023.Core.App;
global using Makc2023.Core.Operation;
global using Makc2023.Data.Sql.Commands.Identity.Reseed;
global using Makc2023.Data.Sql.Commands.Tree.Calculate;
global using Makc2023.Data.Sql.Commands.Tree.Trigger;
global using Makc2023.Data.Sql.Commands.Trigger;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
