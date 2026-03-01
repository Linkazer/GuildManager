using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public interface ICharacterService
{
    public Task<Result<List<Character>>> GetAllAsync();

    public Task<Result<Character>> GetByIdAsync(int id);

    public Task<Result<Character>> CreateCharacterAsync(DtoPostCharacter characterToCreate);

    public Task<Result<Character>> UpdateCharacterAsync(int id, DtoPutCharacter updatedCharacter);

    public Task<Result<Character>> DeleteCharacterAsync(int id);
}
