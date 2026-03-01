using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

/// <summary>
/// Interface for with basic methods for Race Repositories.
/// Handle the Database part of the API.
/// </summary>
public interface IRaceRepository
{
    public Task<RaceModel?> GetByIdAsync(int id);
}
