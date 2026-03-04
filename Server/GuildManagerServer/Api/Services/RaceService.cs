using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public class RaceService : IRaceService
{
    private IRaceRepository repository;

    public RaceService(IRaceRepository nRepository)
    {
        repository = nRepository;
    }

    public async Task<Result<List<Race>>> GetAllAsync()
    {
        List<RaceModel> models = await repository.GetAllModelsAsync();

        List<Race> results = models.Select(r => r.ToRace()).ToList();

        if(results.Count() == 0)
        {
            return Result<List<Race>>.Failure(ResultCode.RaceNotFound);
        }

        return Result<List<Race>>.Success(ResultCode.DataFound, results);
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
