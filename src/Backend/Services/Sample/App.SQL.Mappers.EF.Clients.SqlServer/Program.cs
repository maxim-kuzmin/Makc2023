// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using var appHandler = new WebAppHandler();

try
{
    var appEnvironment = new AppEnvironment();

    appHandler.OnStart(appEnvironment);

    var appBuilder = WebApplication.CreateBuilder(args);

    appBuilder.Configure();

    appBuilder.AddAppModules(appEnvironment);

    // Add services to the container.

    appBuilder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    appBuilder.Services.AddEndpointsApiExplorer();
    appBuilder.Services.AddSwaggerGen();

    var app = appBuilder.Build();

    await app.UseAppModules(appEnvironment).ConfigureAwait(false);

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