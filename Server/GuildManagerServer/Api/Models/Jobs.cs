namespace GuildManagerServer.Api.Models;

public class Job
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Bonus Stats
    public int Strength { get; set; }
    public int Spirit { get; set; }
    public int Presence { get; set; }
    public int Dexterity { get; set; }
    public int Instinct { get; set; }

    // Health
    public int HealthByLevel { get; set; }
}
