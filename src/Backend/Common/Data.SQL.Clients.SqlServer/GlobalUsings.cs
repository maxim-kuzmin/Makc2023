// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Data;
global using System.Data.Common;
global using System.Data.SqlClient;
global using System.Runtime.InteropServices;
global using System.Text;
global using Makc2023.Backend.Common.Core.App;
global using Makc2023.Backend.Common.Data.SQL;
global using Makc2023.Backend.Common.Data.SQL.Clients.SqlServer.Commands.Identity.Reseed;
global using Makc2023.Backend.Common.Data.SQL.Clients.SqlServer.Commands.Tree.Calculate;
global using Makc2023.Backend.Common.Data.SQL.Clients.SqlServer.Commands.Tree.Trigger;
global using Makc2023.Backend.Common.Data.SQL.Clients.SqlServer.Filestream;
global using Makc2023.Backend.Common.Data.SQL.Commands.Identity.Reseed;
global using Makc2023.Backend.Common.Data.SQL.Commands.Tree.Calculate;
global using Makc2023.Backend.Common.Data.SQL.Commands.Tree.Trigger;
global using Makc2023.Backend.Common.Data.SQL.Commands.Trigger;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Win32.SafeHandles;
