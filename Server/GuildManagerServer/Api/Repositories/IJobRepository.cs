using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

public interface IJobRepository
{
    public Task<JobModel?> GetByIdAsync(int id);
}
