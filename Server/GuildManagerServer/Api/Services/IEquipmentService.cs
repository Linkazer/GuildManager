using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public interface IEquipmentService
{
    public Task<Equipment?> GetByIdAsync(int id);
}
