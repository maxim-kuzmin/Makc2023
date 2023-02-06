// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2023.Backend.Common.Core.Apps.WebApp;
using Makc2023.Backend.Common.Core.Apps.WebApp.Setup;
using Makc2023.Backend.Services.Sample.App.Setup;

using var appHandler = new WebAppHandler();

appHandler.OnStart();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configure();

    builder.Services.AddAppModules(builder.Configuration);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    appHandler.OnError(exception);

    throw;
}