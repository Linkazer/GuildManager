using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public interface IRaceService
{
    public Task<Race?> GetByIdAsync(int id);
}
