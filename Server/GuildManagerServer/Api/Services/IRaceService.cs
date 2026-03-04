using GuildManagerServer.Api.Results;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

/// <summary>
/// Interface for with basic methods for Race Services.
/// Handle the Domain part of the application, used mainly as intermediary between Controller and Repository.
/// </summary>
public interface IRaceService
{
    public Task<Result<List<Race>>> GetAllAsync();

    public Task<Race?> GetByIdAsync(int id);
}
