namespace GuildManagerServer.Api.Dto.CharacterDto;

public record class CharacterDtoGetResume
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RaceId  { get; set; }
    public int JobId { get; set; }

    public int BodyId { get; set; }
    public int HairId { get; set; }
    public int HairColorId { get; set; }
    public int EquipmentId  { get; set; }
}
