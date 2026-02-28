using GuildManagerServer.Api.Data;
using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

public class RaceRepository : IRaceRepository
{
    private readonly GuildContext context;

    public RaceRepository(GuildContext nContext)
    {
        context = nContext;
    }

    public async Task<RaceModel?> GetByIdAsync(int id)
    {
        return await context.Race.FindAsync(id);
    }
}
