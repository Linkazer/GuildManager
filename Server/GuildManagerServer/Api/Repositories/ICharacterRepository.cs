using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Repositories;

public interface ICharacterRepository
{
    public Task<List<CharacterModel>> GetAllModelsAsync();

    public Task<CharacterModel?> GetModelByIdAsync(int id);

    public Task AddModel(CharacterModel modelToSave);

    public Task UpdateModel(CharacterModel modelToUpdate);

    public Task DeleteModelAsync(int id);
}
