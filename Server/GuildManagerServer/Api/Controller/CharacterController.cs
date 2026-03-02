using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Api.Services;
using GuildManagerServer.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerServer.Api.Controller;

/// <summary>
/// Controller for Character data.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService service;

    public CharacterController(ICharacterService nService)
    {
        service = nService;
    }

    /// <summary>
    /// Request to get all Characters from the Database.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        Result<List<Character>> result = await service.GetAllAsync();

        Result<List<DtoGetCharacter>> mappedResult = result.MapData(list => list.Select(c => c.ToDtoGetCharacter()).ToList());

        return this.GetResult(mappedResult);
    }

    /// <summary>
    /// Request to get a Character from the Database.
    /// </summary>
    /// <param name="id">The id of the Character wanted.</param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        Result<Character> result = await service.GetByIdAsync(id);

        Result<DtoGetCharacter> dtoResult = result.MapData(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }

    /// <summary>
    /// Request to create a new Character in the Database.
    /// </summary>
    /// <param name="characterToCreate">The data of the Character to create.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateCharacter([FromBody] DtoPostCharacter characterToCreate)
    {
        Result<Character> result = await service.CreateCharacterAsync(characterToCreate.ToCommand());

        if(result.ResultCode == ResultCode.DataCreated && result.Data != null)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data.ToDtoGetCharacter());
        }

        Result<DtoGetCharacter> dtoResult = result.MapData(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }

    /// <summary>
    /// Request to update an existing Character in the Database.
    /// </summary>
    /// <param name="id">The id of the Character to update.</param>
    /// <param name="updateDto">The updated Character's data.</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCharacter([FromRoute] int id, [FromBody] DtoPutCharacter updateDto)
    {
        Result<Character> result = await service.UpdateCharacterAsync(id, updateDto.ToCommand());

        Result<DtoGetCharacter> dtoResult = result.MapData(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }

    /// <summary>
    /// Request to delete an existing Character from the Database.
    /// </summary>
    /// <param name="id">The id of the Character to delete.</param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        Result<Character> result = await service.DeleteCharacterAsync(id);

        Result<DtoGetCharacter> dtoResult = result.MapData(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }
}