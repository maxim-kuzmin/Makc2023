// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Data.Common;
global using System.Text;
global using Makc2023.Backend.Common.Core.App;
global using Makc2023.Backend.Common.Data.Sql;
global using Makc2023.Backend.Common.Data.Sql.Clients.PostgreSql.Commands.Identity.Reseed;
global using Makc2023.Backend.Common.Data.Sql.Clients.PostgreSql.Commands.Tree.Calculate;
global using Makc2023.Backend.Common.Data.Sql.Clients.PostgreSql.Commands.Tree.Trigger;
global using Makc2023.Backend.Common.Data.Sql.Commands.Identity.Reseed;
global using Makc2023.Backend.Common.Data.Sql.Commands.Tree.Calculate;
global using Makc2023.Backend.Common.Data.Sql.Commands.Tree.Trigger;
global using Makc2023.Backend.Common.Data.Sql.Commands.Trigger;
global using Microsoft.Extensions.DependencyInjection;
global using Npgsql;
