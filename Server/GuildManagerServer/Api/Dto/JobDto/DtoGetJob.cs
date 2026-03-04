namespace GuildManagerServer.Api.Dto.JobDto;

public record class DtoGetJob
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
