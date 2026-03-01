using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

/// <summary>
/// Interface for with basic methods for Equipment Repositories.
/// Handle the Database part of the API.
/// </summary>
public interface IEquipmentRepository
{
    public Task<EquipmentModel?> GetByIdAsync(int id);
}
