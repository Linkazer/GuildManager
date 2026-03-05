namespace GuildManagerServer.Api.Dto.RaceDto;

/// <summary>
/// DTO used to get data of a Race.
/// </summary>
public record class DtoGetRace
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
