﻿using DragaliaAPI.Database.Entities;
using DragaliaAPI.Database.Repositories;
using DragaliaAPI.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace DragaliaAPI.Database.Test;

public class DbTestFixture : IDisposable
{
    public ApiContext ApiContext { get; init; }

    public const string DeviceAccountId = "id";

    public DbTestFixture()
    {
        DbContextOptions<ApiContext> options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase($"DbTestFixture-{Guid.NewGuid()}")
            .Options;

        this.ApiContext = new ApiContext(options);

        IDeviceAccountRepository deviceAccountRepository = new DeviceAccountRepository(
            this.ApiContext,
            new CharaDataService()
        );
        deviceAccountRepository.CreateNewSavefile("id").Wait();
        deviceAccountRepository.SaveChangesAsync().Wait();
    }

    public async Task AddToDatabase<TEntity>(TEntity data)
    {
        if (data is null)
            return;

        await this.ApiContext.AddAsync(data);
        await this.ApiContext.SaveChangesAsync();
    }

    public async Task AddRangeToDatabase<TEntity>(IEnumerable<TEntity> data)
    {
        if (data is null)
            return;

        var ids = this.ApiContext.PlayerAbilityCrests.Select(x => x.AbilityCrestId).ToList();

        if (typeof(TEntity) == typeof(DbAbilityCrest))
        {
            var ids2 = data.Cast<DbAbilityCrest>().Select(x => x.AbilityCrestId);
            var offensive = ids.Intersect(ids2).ToList();
        }

        await this.ApiContext.AddRangeAsync((IEnumerable<object>)data);
        await this.ApiContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        this.ApiContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
