﻿using DragaliaAPI.Models.Database.Savefile;
using DragaliaAPI.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MockQueryable.Moq;

namespace DragaliaAPI.Test.Unit.Services;

public class SessionServiceTest
{
    private readonly Mock<IApiRepository> mockRepository;
    private readonly SessionService sessionService;
    private readonly DeviceAccount deviceAccount = new("id", "password");
    private readonly DeviceAccount deviceAccountTwo = new("id 2", "password 2");
    private readonly List<DbSavefilePlayerInfo> dbPlayerSavefile = new()
    {
        new() { DeviceAccountId = "id", ViewerId = 1 },
    };
    private readonly List<DbSavefilePlayerInfo> dbPlayerSavefileTwo = new()
    {
        new() { DeviceAccountId = "id 2", ViewerId = 2 },
    };

    public SessionServiceTest()
    {
        mockRepository = new(MockBehavior.Strict);
        mockRepository.Setup(x => x.GetSavefile("id")).Returns(dbPlayerSavefile.AsQueryable().BuildMock());
        mockRepository.Setup(x => x.GetSavefile("id 2")).Returns(dbPlayerSavefileTwo.AsQueryable().BuildMock());

        var opts = Options.Create(new MemoryDistributedCacheOptions());
        IDistributedCache testCache = new MemoryDistributedCache(opts);

        sessionService = new(mockRepository.Object, testCache);
    }

    [Fact]
    public async Task NewSession_CreatesValidSession()
    {
        string sessionId = await PrepareAndRegisterSession("id_token", deviceAccount);

        bool valid = await sessionService.ValidateSession(sessionId);

        valid.Should().Be(true);
    }

    [Fact]
    public async Task NewSession_ExistingSession_ReplacesOldSession()
    {
        string firstSessionId = await PrepareAndRegisterSession("id_token", deviceAccount);
        string secondSessionId = await PrepareAndRegisterSession("id_token", deviceAccount);

        bool firstValid = await sessionService.ValidateSession(firstSessionId);
        bool secondValid = await sessionService.ValidateSession(secondSessionId);

        firstValid.Should().Be(false);
        secondValid.Should().Be(true);
        secondSessionId.Should().NotBeEquivalentTo(firstSessionId);
    }

    [Fact]
    public async Task NewSession_TwoCreated_BothValid()
    {
        string firstSessionId = await PrepareAndRegisterSession("id_token_1", deviceAccount);
        string secondSessionId = await PrepareAndRegisterSession("id_token_2", deviceAccountTwo);

        bool firstValid = await sessionService.ValidateSession(firstSessionId);
        bool secondValid = await sessionService.ValidateSession(secondSessionId);

        firstValid.Should().Be(true);
        secondValid.Should().Be(true);
        secondSessionId.Should().NotBeEquivalentTo(firstSessionId);
    }

    [Fact]
    public async Task ValidateSession_NonExistentSession_ReturnsFalse()
    {
        bool result = await sessionService.ValidateSession("sessionId");

        result.Should().Be(false);
    }

    private async Task<string> PrepareAndRegisterSession(string idToken, DeviceAccount deviceAccount)
    {
        await sessionService.PrepareSession(deviceAccount, idToken);
        return await sessionService.ActivateSession(idToken);
    }
}