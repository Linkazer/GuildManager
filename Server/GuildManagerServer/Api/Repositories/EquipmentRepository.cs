using GuildManagerServer.Api.Data;
using GuildManagerServer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerServer.Api.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly GuildContext context;

    public EquipmentRepository(GuildContext nContext)
    {
        context = nContext;
    }

    public async Task<List<EquipmentModel>> GetAllModelsAsync()
    {
        return await context.Equipment.ToListAsync();
    }

    public async Task<EquipmentModel?> GetByIdAsync(int id)
    {
        return await context.Equipment.FindAsync(id);
    }
}
