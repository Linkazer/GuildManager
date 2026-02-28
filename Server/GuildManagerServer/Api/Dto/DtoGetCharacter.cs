namespace GuildManagerServer.Api.Dto;

public record class DtoGetCharacter
{
    public int Id { get; set; }
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

    //Calculated
    public int MaxHealth {get ; set;}
    public int Dodge { get; set; }
    public int Will { get; set; }
}
