using System;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository repository;

    public EquipmentService(IEquipmentRepository nRepository)
    {
        repository = nRepository;
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
