using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Application.Command;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

/// <summary>
/// Interface for with basic methods for Character Services.
/// Handle the Domain part of the application, used mainly as intermediary between Controller and Repository.
/// </summary>
public interface ICharacterService
{
    public Task<Result<List<Character>>> GetAllAsync();

    public Task<Result<Character>> GetByIdAsync(int id);

    public Task<Result<Character>> CreateCharacterAsync(CreateCharacterCommand characterToCreate);

    public Task<Result<Character>> UpdateCharacterAsync(int id, UpdateCharacterCommand updatedCharacter);

    public Task<Result<Character>> DeleteCharacterAsync(int id);
}
