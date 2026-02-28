using GuildManagerServer.Api.Data;
using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly GuildContext context;

    public EquipmentRepository(GuildContext nContext)
    {
        context = nContext;
    }

    public async Task<EquipmentModel?> GetByIdAsync(int id)
    {
        return await context.Equipment.FindAsync(id);
    }
}
