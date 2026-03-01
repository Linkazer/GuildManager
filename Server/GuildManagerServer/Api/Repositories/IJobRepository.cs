using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

/// <summary>
/// Interface for with basic methods for Job Repositories.
/// Handle the Database part of the API.
/// </summary>
public interface IJobRepository
{
    public Task<JobModel?> GetByIdAsync(int id);
}
