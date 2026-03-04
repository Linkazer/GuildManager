namespace GuildManagerServer.Api.Dto.RaceDto;

public record class DtoGetRace
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
