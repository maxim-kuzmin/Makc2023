// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

global using System.Net.Sockets;
global using System.Text;
global using System.Text.Json;
global using Makc2023.Backend.Common.Core.Extensions;
global using Makc2023.Backend.Common.Core.Integration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Polly;
global using Polly.Retry;
global using RabbitMQ.Client;
global using RabbitMQ.Client.Events;
global using RabbitMQ.Client.Exceptions;
