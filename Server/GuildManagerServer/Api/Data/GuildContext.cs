using GuildManagerServer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerServer.Api.Data;

/// <summary>
/// DB Context for the Guild.
/// </summary>
public class GuildContext : DbContext
{
    public GuildContext(DbContextOptions<GuildContext> options)
        : base(options)
    {  
    }

    public DbSet<CharacterModel> Character { get; set; }
    public DbSet<RaceModel> Race { get; set; }
    public DbSet<JobModel> Job { get; set; }
    public DbSet<EquipmentModel> Equipment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Create base data for Races. Note that we could also generate it manualy using SQL Server.
        modelBuilder.Entity<RaceModel>().HasData(
            new {Id = 1, Name = "Human", Strength = 0, Spirit = 0, Presence = 1, Dexterity = 0, Instinct = 1, Health = 10},
            new {Id = 2, Name = "Elf", Strength = 0, Spirit = 1, Presence = 0, Dexterity = 1, Instinct = 0, Health = 7},
            new {Id = 3, Name = "Tiefling", Strength = 0, Spirit = 1, Presence = 1, Dexterity = 0, Instinct = 0, Health = 8}
        );

        //Create base data for Jobs. Note that we could also generate it manualy using SQL Server.
        modelBuilder.Entity<JobModel>().HasData(
            new {Id = 1, Name = "Fighter", Strength = 1, Spirit = 0, Presence = 0, Dexterity = 0, Instinct = 0, HealthByLevel = 3},
            new {Id = 2, Name = "Bard", Strength = 0, Spirit = 0, Presence = 1, Dexterity = 0, Instinct = 0, HealthByLevel = 2},
            new {Id = 3, Name = "Mage", Strength = 0, Spirit = 1, Presence = 0, Dexterity = 0, Instinct = 0, HealthByLevel = 1}
        );

        //Create base data for Equipments. Note that we could also generate it manualy using SQL Server.
        modelBuilder.Entity<EquipmentModel>().HasData(
            new {Id = 1, Name = "Clothe"},
            new {Id = 2, Name = "Leather armor"},
            new {Id = 3, Name = "Chain mail"},
            new {Id = 4, Name = "Plate armor"}
        );
    }
}
