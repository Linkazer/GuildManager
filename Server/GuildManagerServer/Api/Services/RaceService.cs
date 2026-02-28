using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public class RaceService : IRaceService
{
    private IRaceRepository repository;

    public RaceService(IRaceRepository nRepository)
    {
        repository = nRepository;
    }

    public async Task<Race?> GetByIdAsync(int id)
    {
        RaceModel? model = await repository.GetByIdAsync(id);

        if(model == null)
        {
            return null;
        }

        return model.ToRace();
    }
}
