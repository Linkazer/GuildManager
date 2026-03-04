using GuildManagerServer.Api.Results;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

/// <summary>
/// Interface for with basic methods for Equipment Services.
/// Handle the Domain part of the application, used mainly as intermediary between Controller and Repository.
/// </summary>
public interface IEquipmentService
{
    public Task<Result<List<Equipment>>> GetAllAsync();
    public Task<Equipment?> GetByIdAsync(int id);
}
