// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Sql.Clients.SqlServer.Types.DummyMain;

internal class DummyMainClientTypeConfiguration : IEntityTypeConfiguration<DummyMainEntity>
{
    #region Public methods

    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<DummyMainEntity> builder)
    {
        throw new NotImplementedException();
    }

    #endregion Public methods
}
