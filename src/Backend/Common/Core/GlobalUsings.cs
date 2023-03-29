// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Globalization;
global using System.Net;
global using System.Net.Sockets;
global using System.Text.Encodings.Web;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Text.RegularExpressions;
global using Makc2023.Backend.Common.Core.App;
global using Makc2023.Backend.Common.Core.Converting;
global using Makc2023.Backend.Common.Core.Exceptions;
global using Makc2023.Backend.Common.Core.Operation;
global using Makc2023.Backend.Common.Core.Operations;
global using Makc2023.Backend.Common.Core.Operations.List.Get;
global using Makc2023.Backend.Common.Core.Repeat;
global using Makc2023.Backend.Common.Core.Serialization.Json;
global using Makc2023.Backend.Common.Core.Setup;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Abstractions;
global using Microsoft.Extensions.Options;
global using Polly;
global using ILoggerOfNLog = NLog.ILogger;
global using LogManagerOfNLog = NLog.LogManager;
