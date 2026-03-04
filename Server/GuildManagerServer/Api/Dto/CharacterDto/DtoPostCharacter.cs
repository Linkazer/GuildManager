namespace GuildManagerServer.Api.Dto.CharacterDto;

/// <summary>
/// DTO used to create a new Character.
/// </summary>
public record class DtoPostCharacter
{
    public string Name { get; set; } = string.Empty;
    public int RaceId  { get; set; }
    public int JobId { get; set; }
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
}
