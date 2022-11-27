// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Data;
global using System.Data.Common;
global using System.Data.SqlClient;
global using System.Runtime.InteropServices;
global using System.Text;
global using Makc2023.Backend.Core.App;
global using Makc2023.Backend.Data.Sql;
global using Makc2023.Backend.Data.Sql.Clients.SqlServer.Commands.Identity.Reseed;
global using Makc2023.Backend.Data.Sql.Clients.SqlServer.Commands.Tree.Calculate;
global using Makc2023.Backend.Data.Sql.Clients.SqlServer.Commands.Tree.Trigger;
global using Makc2023.Backend.Data.Sql.Clients.SqlServer.Filestream;
global using Makc2023.Backend.Data.Sql.Commands.Identity.Reseed;
global using Makc2023.Backend.Data.Sql.Commands.Tree.Calculate;
global using Makc2023.Backend.Data.Sql.Commands.Tree.Trigger;
global using Makc2023.Backend.Data.Sql.Commands.Trigger;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Win32.SafeHandles;
