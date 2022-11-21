// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2023.Core.App;
using Microsoft.Extensions.Localization;

namespace Makc2023.Services.Sample.API.Setup;

public class SetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddLocalization(x => x.ConfigureLocalization());
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
        {
            typeof(IConfiguration),
            typeof(ILogger),
            typeof(IStringLocalizer),
        };
    }

    #endregion Public methods
}
