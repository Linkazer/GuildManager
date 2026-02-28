using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

public interface IRaceRepository
{
    public Task<RaceModel?> GetByIdAsync(int id);
}
