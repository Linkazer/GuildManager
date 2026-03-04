namespace GuildManagerServer.Api.Dto.EquipmentDto;

public record class DtoGetEquipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
