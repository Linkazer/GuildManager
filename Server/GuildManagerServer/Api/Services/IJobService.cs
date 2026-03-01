using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

/// <summary>
/// Interface for with basic methods for Job Services.
/// Handle the Domain part of the application, used mainly as intermediary between Controller and Repository.
/// </summary>
public interface IJobService
{
    public Task<Job?> GetByIdAsync(int id);
}
