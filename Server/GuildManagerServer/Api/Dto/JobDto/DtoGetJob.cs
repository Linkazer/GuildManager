namespace GuildManagerServer.Api.Dto.JobDto;

/// <summary>
/// DTO used to get data of a Job.
/// </summary>
public record class DtoGetJob
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
