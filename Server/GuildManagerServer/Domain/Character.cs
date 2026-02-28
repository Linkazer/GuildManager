using System.ComponentModel.DataAnnotations;

namespace GuildManagerServer.Domain;

public class Character
{
    private const int BaseDodge = 3;
    private const int BaseWill = 3;

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public required Race Race  { get; set; }
    public required Job Job { get; set; }
    public int Level { get; set; }

    //Stats
    public int Strength { get; set; }
    public int Spirit { get; set; }
    public int Presence { get; set; }
    public int Dexterity { get; set; }
    public int Instinct { get; set; }

    //Personnalisation
    public int BodyId { get; set; }
    public int HairId { get; set; }
    public int HairColorId { get; set; }
    public required Equipment Equipment  { get; set; }

    //Calculated
    public int MaxHealth => Race.Health + Job.HealthByLevel * Level;
    public int Dodge => BaseDodge + Dexterity;
    public int Will => BaseWill + Spirit;
}
