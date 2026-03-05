using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository repository;

    public EquipmentService(IEquipmentRepository nRepository)
    {
        repository = nRepository;
    }

    public async Task<Result<List<Equipment>>> GetAllAsync()
    {
        List<EquipmentModel> models = await repository.GetAllModelsAsync();

        List<Equipment> results = models.Select(e => e.ToEquipment()).ToList();

        if(results.Count() == 0)
        {
            return Result<List<Equipment>>.Failure(ResultCode.RaceNotFound);
        }

        return Result<List<Equipment>>.Success(ResultCode.DataFound, results);
    }

    public async Task<Equipment?> GetByIdAsync(int id)
    {
        EquipmentModel? model = await repository.GetByIdAsync(id);

        if(model == null)
        {
            return null;
        }

        return model.ToEquipment();
    }
}
