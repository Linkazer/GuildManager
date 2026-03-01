namespace GuildManagerServer.Api.Models;

/// <summary>
/// Model for Characters. Defines the Character data stored in the Database.
/// </summary>
public class CharacterModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RaceId  { get; set; }
    public RaceModel? Race { get; set; }
    public int JobId { get; set; }
    public JobModel? Job { get; set; }
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
    public int EquipmentId  { get; set; }
    public EquipmentModel? Equipment { get; set; }
}
