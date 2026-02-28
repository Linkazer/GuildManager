using GuildManagerServer.Api.Dto;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public interface ICharacterService
{
    public Task<List<Character>> GetAllAsync();

    public Task<Character?> GetByIdAsync(int id);

    public Task<Character?> CreateCharacterAsync(DtoPostCharacter characterToCreate);

    public Task<Character?> UpdateCharacterAsync(int id, DtoPutCharacter updatedCharacter);

    public Task DeleteCharacterAsync(int id);
}
