using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

public interface IEquipmentRepository
{
    public Task<EquipmentModel?> GetByIdAsync(int id);
}
