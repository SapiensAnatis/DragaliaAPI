﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragaliaAPI.Database.Entities;
using DragaliaAPI.Shared.Definitions.Enums;
using Microsoft.EntityFrameworkCore;

namespace DragaliaAPI.Database.Repositories;

public class InventoryRepository : BaseRepository, IInventoryRepository
{
    private readonly ApiContext apiContext;

    public InventoryRepository(ApiContext apiContext) : base(apiContext)
    {
        this.apiContext = apiContext;
    }

    public async Task<DbPlayerCurrency?> GetCurrency(string deviceAccountId, CurrencyTypes type)
    {
        return await this.apiContext.PlayerWallet.FirstOrDefaultAsync(
            entry => entry.CurrencyType == type
        );
    }

    public IQueryable<DbPlayerCurrency> GetCurrencies(string deviceAccountId)
    {
        return this.apiContext.PlayerWallet.Where(
            wallet => wallet.DeviceAccountId == deviceAccountId
        );
    }

    public async Task<DbPlayerMaterial?> GetMaterial(string deviceAccountId, Materials materialId)
    {
        return await this.apiContext.PlayerStorage.FirstOrDefaultAsync(
            entry => entry.MaterialId == materialId
        );
    }

    public IQueryable<DbPlayerMaterial> GetMaterials(string deviceAccountId)
    {
        return this.apiContext.PlayerStorage.Where(
            storage => storage.DeviceAccountId == deviceAccountId
        );
    }
}
