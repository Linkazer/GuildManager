using GuildManagerServer.Api.Models;

namespace GuildManagerServer.Api.Repositories;

/// <summary>
/// Interface for with basic methods for Character Repositories.
/// Handle the Database part of the API.
/// </summary>
public interface ICharacterRepository
{
    public Task<List<CharacterModel>> GetAllModelsAsync();

    public Task<CharacterModel?> GetModelByIdAsync(int id);

    public Task AddModelAsync(CharacterModel modelToSave);

    public Task UpdateModelAsync(CharacterModel modelToUpdate);

    public Task DeleteModelAsync(int id);
}
