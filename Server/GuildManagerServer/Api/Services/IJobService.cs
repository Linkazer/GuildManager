using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public interface IJobService
{
    public Task<Job?> GetByIdAsync(int id);
}
