namespace GuildManagerServer.Api.Dto.EquipmentDto;

/// <summary>
/// DTO used to get data of an Equipment.
/// </summary>
public record class DtoGetEquipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
