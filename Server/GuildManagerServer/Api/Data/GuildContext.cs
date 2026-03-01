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
            new {Id = 1, Name = "Human", Strength = 0, Spirit = 0, Presence = 0, Dexterity = 0, Instinct = 0, Health = 10}
        );

        //Create base data for Jobs. Note that we could also generate it manualy using SQL Server.
        modelBuilder.Entity<JobModel>().HasData(
            new {Id = 1, Name = "Fighter", Strength = 0, Spirit = 0, Presence = 0, Dexterity = 0, Instinct = 0, HealthByLevel = 3}
        );

        //Create base data for Equipments. Note that we could also generate it manualy using SQL Server.
        modelBuilder.Entity<EquipmentModel>().HasData(
            new {Id = 1, Name = "Basic clothes"}
        );
    }
}
