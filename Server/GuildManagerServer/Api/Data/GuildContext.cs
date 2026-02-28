using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GuildManagerServer.Api.Data;

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

        modelBuilder.Entity<RaceModel>().HasData(
            new {Id = 1, Name = "Human", Strength = 0, Spirit = 0, Presence = 0, Dexterity = 0, Instinct = 0, Health = 10}
        );

        modelBuilder.Entity<JobModel>().HasData(
            new {Id = 1, Name = "Fighter", Strength = 0, Spirit = 0, Presence = 0, Dexterity = 0, Instinct = 0, HealthByLevel = 3}
        );

        modelBuilder.Entity<EquipmentModel>().HasData(
            new {Id = 1, Name = "Basic clothes"}
        );
    }
}
