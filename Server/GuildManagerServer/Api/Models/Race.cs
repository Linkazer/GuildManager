namespace GuildManagerServer.Api.Models;

public class Race
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Start Stats
    public int Strength { get; set; }
    public int Spirit { get; set; }
    public int Presence { get; set; }
    public int Dexterity { get; set; }
    public int Instinct { get; set; }

    // Health
    public int Health { get; set; }
}
