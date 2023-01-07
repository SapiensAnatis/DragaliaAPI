﻿// <auto-generated />
using System;
using DragaliaAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DragaliaAPI.Database.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20230105221342_1-1-0_alpha_1")]
    partial class _110alpha1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbAbilityCrest", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text");

                    b.Property<int>("AbilityCrestId")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPlusCount")
                        .HasColumnType("integer");

                    b.Property<int>("BuildupCount")
                        .HasColumnType("integer");

                    b.Property<int>("EquipableCount")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("GetTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HpPlusCount")
                        .HasColumnType("integer");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNew")
                        .HasColumnType("boolean");

                    b.Property<int>("LimitBreakCount")
                        .HasColumnType("integer");

                    b.HasKey("DeviceAccountId", "AbilityCrestId");

                    b.ToTable("PlayerAbilityCrests");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbDeviceAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeviceAccounts");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbParty", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text");

                    b.Property<int>("PartyNo")
                        .HasColumnType("integer");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("DeviceAccountId", "PartyNo");

                    b.ToTable("PartyData");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPartyUnit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("CharaId")
                        .HasColumnType("integer");

                    b.Property<string>("DeviceAccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EditSkill1CharaId")
                        .HasColumnType("integer");

                    b.Property<int>("EditSkill2CharaId")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType1CrestId1")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType1CrestId2")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType1CrestId3")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType2CrestId1")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType2CrestId2")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType3CrestId1")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType3CrestId2")
                        .HasColumnType("integer");

                    b.Property<long>("EquipDragonKeyId")
                        .HasColumnType("bigint");

                    b.Property<long>("EquipTalismanKeyId")
                        .HasColumnType("bigint");

                    b.Property<int>("EquipWeaponBodyId")
                        .HasColumnType("integer");

                    b.Property<int>("EquipWeaponSkinId")
                        .HasColumnType("integer");

                    b.Property<int>("PartyNo")
                        .HasColumnType("integer");

                    b.Property<int>("UnitNo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeviceAccountId", "PartyNo");

                    b.ToTable("PlayerPartyUnits");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerBannerData", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("SummonBannerId")
                        .HasColumnType("integer")
                        .HasColumnName("SummonBannerId");

                    b.Property<int>("ConsecutionSummonPoints")
                        .HasColumnType("integer")
                        .HasColumnName("CsSummonPoints");

                    b.Property<DateTimeOffset>("ConsecutionSummonPointsMaxDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CsSummonPointsMaxDate");

                    b.Property<DateTimeOffset>("ConsecutionSummonPointsMinDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CsSummonPointsMinDate");

                    b.Property<int>("DailyLimitedSummonCount")
                        .HasColumnType("integer")
                        .HasColumnName("DailyLimitedSummons");

                    b.Property<int>("IsBeginnerFreeSummonAvailable")
                        .HasColumnType("integer")
                        .HasColumnName("BeginnerSummonAvailable");

                    b.Property<int>("IsConsecutionFreeSummonAvailable")
                        .HasColumnType("integer")
                        .HasColumnName("CsSummonAvailable");

                    b.Property<int>("IsFreeSummonAvailable")
                        .HasColumnType("integer")
                        .HasColumnName("FreeSummonAvailable");

                    b.Property<byte>("PityRate")
                        .HasColumnType("smallint")
                        .HasColumnName("Pity");

                    b.Property<int>("SummonCount")
                        .HasColumnType("integer")
                        .HasColumnName("SummonCount");

                    b.Property<int>("SummonPoints")
                        .HasColumnType("integer")
                        .HasColumnName("SummonPoints");

                    b.HasKey("DeviceAccountId", "SummonBannerId");

                    b.ToTable("PlayerBannerData");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerCharaData", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("CharaId")
                        .HasColumnType("integer")
                        .HasColumnName("CharaId");

                    b.Property<byte>("Ability1Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Abil1Lvl");

                    b.Property<byte>("Ability2Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Abil2Lvl");

                    b.Property<byte>("Ability3Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Abil3Lvl");

                    b.Property<byte>("AdditionalMaxLevel")
                        .HasColumnType("smallint")
                        .HasColumnName("AddMaxLevel");

                    b.Property<int>("AttackBase")
                        .HasColumnType("integer")
                        .HasColumnName("AtkBase");

                    b.Property<int>("AttackNode")
                        .HasColumnType("integer")
                        .HasColumnName("AtkNode");

                    b.Property<byte>("AttackPlusCount")
                        .HasColumnType("smallint")
                        .HasColumnName("AtkPlusCount");

                    b.Property<byte>("BurstAttackLevel")
                        .HasColumnType("smallint")
                        .HasColumnName("BurstAtkLvl");

                    b.Property<int>("ComboBuildupCount")
                        .HasColumnType("integer")
                        .HasColumnName("ComboBuildupCount");

                    b.Property<byte>("ExAbility2Level")
                        .HasColumnType("smallint")
                        .HasColumnName("ExAbility2Lvl");

                    b.Property<byte>("ExAbilityLevel")
                        .HasColumnType("smallint")
                        .HasColumnName("ExAbility1Lvl");

                    b.Property<int>("Exp")
                        .HasColumnType("integer")
                        .HasColumnName("Exp");

                    b.Property<DateTimeOffset>("GetTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("GetTime");

                    b.Property<int>("HpBase")
                        .HasColumnType("integer")
                        .HasColumnName("HpBase");

                    b.Property<int>("HpNode")
                        .HasColumnType("integer")
                        .HasColumnName("HpNode");

                    b.Property<byte>("HpPlusCount")
                        .HasColumnType("smallint")
                        .HasColumnName("HpPlusCount");

                    b.Property<bool>("IsNew")
                        .HasColumnType("boolean")
                        .HasColumnName("IsNew");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("boolean")
                        .HasColumnName("IsTemp");

                    b.Property<bool>("IsUnlockEditSkill")
                        .HasColumnType("boolean")
                        .HasColumnName("IsUnlockEditSkill");

                    b.Property<byte>("Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Level");

                    b.Property<bool>("ListViewFlag")
                        .HasColumnType("boolean")
                        .HasColumnName("ListViewFlag");

                    b.Property<int>("ManaNodeUnlockCount")
                        .HasColumnType("integer")
                        .HasColumnName("ManaNodeUnlockCount");

                    b.Property<byte>("Rarity")
                        .HasColumnType("smallint")
                        .HasColumnName("Rarity");

                    b.Property<byte>("Skill1Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Skill1Lvl");

                    b.Property<byte>("Skill2Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Skill2Lvl");

                    b.HasKey("DeviceAccountId", "CharaId");

                    b.ToTable("PlayerCharaData");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerCurrency", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("integer")
                        .HasColumnName("CurrencyType");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("Quantity");

                    b.HasKey("DeviceAccountId", "CurrencyType");

                    b.ToTable("PlayerCurrency");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerDragonData", b =>
                {
                    b.Property<long>("DragonKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("DragonKeyId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DragonKeyId"));

                    b.Property<byte>("Ability1Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Abil1Level");

                    b.Property<byte>("Ability2Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Abil2Level");

                    b.Property<byte>("AttackPlusCount")
                        .HasColumnType("smallint")
                        .HasColumnName("AttackPlusCount");

                    b.Property<string>("DeviceAccountId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("DragonId")
                        .HasColumnType("integer")
                        .HasColumnName("DragonId");

                    b.Property<int>("Exp")
                        .HasColumnType("integer")
                        .HasColumnName("Exp");

                    b.Property<DateTimeOffset>("GetTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("GetTime");

                    b.Property<byte>("HpPlusCount")
                        .HasColumnType("smallint")
                        .HasColumnName("HpPlusCount");

                    b.Property<bool>("IsLock")
                        .HasColumnType("boolean")
                        .HasColumnName("IsLocked");

                    b.Property<bool>("IsNew")
                        .HasColumnType("boolean")
                        .HasColumnName("IsNew");

                    b.Property<byte>("Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Level");

                    b.Property<byte>("LimitBreakCount")
                        .HasColumnType("smallint")
                        .HasColumnName("LimitBreakCount");

                    b.Property<byte>("Skill1Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Skill1Level");

                    b.HasKey("DragonKeyId");

                    b.ToTable("PlayerDragonData");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerDragonReliability", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("DragonId")
                        .HasColumnType("integer")
                        .HasColumnName("DragonId");

                    b.Property<int>("Exp")
                        .HasColumnType("integer")
                        .HasColumnName("TotalExp");

                    b.Property<DateTimeOffset>("GetTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastContactTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastContactTime");

                    b.Property<byte>("Level")
                        .HasColumnType("smallint")
                        .HasColumnName("Level");

                    b.HasKey("DeviceAccountId", "DragonId");

                    b.ToTable("PlayerDragonReliability");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerMaterial", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer")
                        .HasColumnName("MaterialId");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("Quantity");

                    b.HasKey("DeviceAccountId", "MaterialId");

                    b.ToTable("PlayerMaterial");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerStoryState", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("StoryType")
                        .HasColumnType("integer")
                        .HasColumnName("StoryType");

                    b.Property<int>("StoryId")
                        .HasColumnType("integer")
                        .HasColumnName("StoryId");

                    b.Property<byte>("State")
                        .HasColumnType("smallint")
                        .HasColumnName("State");

                    b.HasKey("DeviceAccountId", "StoryType", "StoryId");

                    b.ToTable("PlayerStoryState");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerSummonHistory", b =>
                {
                    b.Property<long>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("KeyId"));

                    b.Property<string>("DeviceAccountId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DeviceAccountId");

                    b.Property<int>("EntityAttackPlusCount")
                        .HasColumnType("integer")
                        .HasColumnName("AtkPlusCount");

                    b.Property<int>("EntityHpPlusCount")
                        .HasColumnType("integer")
                        .HasColumnName("HpPlusCount");

                    b.Property<int>("EntityId")
                        .HasColumnType("integer")
                        .HasColumnName("EntityId");

                    b.Property<byte>("EntityLevel")
                        .HasColumnType("smallint")
                        .HasColumnName("Level");

                    b.Property<byte>("EntityLimitBreakCount")
                        .HasColumnType("smallint")
                        .HasColumnName("LimitBreakCount");

                    b.Property<int>("EntityQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("Quantity");

                    b.Property<byte>("EntityRarity")
                        .HasColumnType("smallint")
                        .HasColumnName("Rarity");

                    b.Property<int>("EntityType")
                        .HasColumnType("integer")
                        .HasColumnName("EntityType");

                    b.Property<DateTimeOffset>("ExecDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("SummonDate");

                    b.Property<int>("GetDewPointQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("DewPointGet");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer")
                        .HasColumnName("PaymentType");

                    b.Property<byte>("SummonExecType")
                        .HasColumnType("smallint")
                        .HasColumnName("SummonExecType");

                    b.Property<int>("SummonId")
                        .HasColumnType("integer")
                        .HasColumnName("BannerId");

                    b.Property<int>("SummonPoint")
                        .HasColumnType("integer")
                        .HasColumnName("SummonPointGet");

                    b.Property<int>("SummonPrizeRank")
                        .HasColumnType("integer")
                        .HasColumnName("SummonPrizeRank");

                    b.HasKey("KeyId");

                    b.ToTable("PlayerSummonHistory");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPlayerUserData", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text");

                    b.Property<int>("ActiveMemoryEventId")
                        .HasColumnType("integer");

                    b.Property<int>("BuildTimePoint")
                        .HasColumnType("integer");

                    b.Property<long>("Coin")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Crystal")
                        .HasColumnType("integer");

                    b.Property<int>("DewPoint")
                        .HasColumnType("integer");

                    b.Property<int>("EmblemId")
                        .HasColumnType("integer");

                    b.Property<int>("Exp")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("FortOpenTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastLoginTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastSaveImportTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastStaminaMultiUpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastStaminaSingleUpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("MainPartyNo")
                        .HasColumnType("integer");

                    b.Property<int>("ManaPoint")
                        .HasColumnType("integer");

                    b.Property<int>("MaxDragonQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuestSkipPoint")
                        .HasColumnType("integer");

                    b.Property<int>("StaminaMulti")
                        .HasColumnType("integer");

                    b.Property<int>("StaminaMultiSurplusSecond")
                        .HasColumnType("integer");

                    b.Property<int>("StaminaSingle")
                        .HasColumnType("integer");

                    b.Property<int>("StaminaSingleSurplusSecond")
                        .HasColumnType("integer");

                    b.Property<int>("TutorialFlag")
                        .HasColumnType("integer");

                    b.Property<int>("TutorialStatus")
                        .HasColumnType("integer");

                    b.Property<long>("ViewerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ViewerId"));

                    b.HasKey("DeviceAccountId");

                    b.ToTable("PlayerUserData");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbQuest", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text");

                    b.Property<int>("QuestId")
                        .HasColumnType("integer");

                    b.Property<float>("BestClearTime")
                        .HasColumnType("real");

                    b.Property<int>("DailyPlayCount")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAppear")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMissionClear1")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMissionClear2")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMissionClear3")
                        .HasColumnType("boolean");

                    b.Property<int>("LastDailyResetTime")
                        .HasColumnType("integer");

                    b.Property<int>("LastWeeklyResetTime")
                        .HasColumnType("integer");

                    b.Property<int>("PlayCount")
                        .HasColumnType("integer");

                    b.Property<byte>("State")
                        .HasColumnType("smallint");

                    b.Property<int>("WeeklyPlayCount")
                        .HasColumnType("integer");

                    b.HasKey("DeviceAccountId", "QuestId");

                    b.ToTable("PlayerQuests");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbSetUnit", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text");

                    b.Property<int>("CharaId")
                        .HasColumnType("integer");

                    b.Property<int>("UnitSetNo")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType1CrestId1")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType1CrestId2")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType1CrestId3")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType2CrestId1")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType2CrestId2")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType3CrestId1")
                        .HasColumnType("integer");

                    b.Property<int>("EquipCrestSlotType3CrestId2")
                        .HasColumnType("integer");

                    b.Property<long>("EquipDragonKeyId")
                        .HasColumnType("bigint");

                    b.Property<long>("EquipTalismanKeyId")
                        .HasColumnType("bigint");

                    b.Property<int>("EquipWeaponBodyId")
                        .HasColumnType("integer");

                    b.Property<string>("UnitSetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DeviceAccountId", "CharaId", "UnitSetNo");

                    b.ToTable("PlayerSetUnit");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbTalisman", b =>
                {
                    b.Property<long>("TalismanKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TalismanKeyId"));

                    b.Property<int>("AdditionalAttack")
                        .HasColumnType("integer");

                    b.Property<int>("AdditionalHp")
                        .HasColumnType("integer");

                    b.Property<string>("DeviceAccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("GetTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsLock")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNew")
                        .HasColumnType("boolean");

                    b.Property<int>("TalismanAbilityId1")
                        .HasColumnType("integer");

                    b.Property<int>("TalismanAbilityId2")
                        .HasColumnType("integer");

                    b.Property<int>("TalismanAbilityId3")
                        .HasColumnType("integer");

                    b.Property<int>("TalismanId")
                        .HasColumnType("integer");

                    b.HasKey("TalismanKeyId");

                    b.ToTable("PlayerTalismans");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbWeaponBody", b =>
                {
                    b.Property<string>("DeviceAccountId")
                        .HasColumnType("text");

                    b.Property<int>("WeaponBodyId")
                        .HasColumnType("integer");

                    b.Property<int>("AdditionalCrestSlotType1Count")
                        .HasColumnType("integer");

                    b.Property<int>("AdditionalCrestSlotType2Count")
                        .HasColumnType("integer");

                    b.Property<int>("AdditionalCrestSlotType3Count")
                        .HasColumnType("integer");

                    b.Property<int>("BuildupCount")
                        .HasColumnType("integer");

                    b.Property<int>("EquipableCount")
                        .HasColumnType("integer");

                    b.Property<int>("FortPassiveCharaWeaponBuildupCount")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("GetTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsNew")
                        .HasColumnType("boolean");

                    b.Property<int>("LimitBreakCount")
                        .HasColumnType("integer");

                    b.Property<int>("LimitOverCount")
                        .HasColumnType("integer");

                    b.Property<string>("UnlockWeaponPassiveAbilityNoString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DeviceAccountId", "WeaponBodyId");

                    b.ToTable("PlayerWeapons");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbPartyUnit", b =>
                {
                    b.HasOne("DragaliaAPI.Database.Entities.DbParty", "Party")
                        .WithMany("Units")
                        .HasForeignKey("DeviceAccountId", "PartyNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Party");
                });

            modelBuilder.Entity("DragaliaAPI.Database.Entities.DbParty", b =>
                {
                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}
