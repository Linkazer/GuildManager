using GuildManagerServer.Api.Dto.CharacterDto;
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
    /// Request to get all Characters from the Database as CharacterDtoGetResume.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllResume()
    {
        Result<List<Character>> result = await service.GetAllAsync();

        Result<List<CharacterDtoGetResume>> mappedResult = result.MapData(list => list.Select(c => c.ToDtoGetResume()).ToList());

        return this.GetResult(mappedResult);
    }

    /// <summary>
    /// Request to get a Character from the Database as a CharacterDtoGetResume.
    /// </summary>
    /// <param name="id">The id of the Character wanted.</param>
    /// <returns></returns>
    [HttpGet("Resume/{id:int}")]
    public async Task<IActionResult> GetResumeById([FromRoute] int id)
    {
        Result<Character> result = await service.GetByIdAsync(id);

        Result<CharacterDtoGetResume> dtoResult = result.MapData(c => c.ToDtoGetResume());

        return this.GetResult(dtoResult);
    }

    /// <summary>
    /// Request to get a Character from the Database as a CharacterDtoGetDetails.
    /// </summary>
    /// <param name="id">The id of the Character wanted.</param>
    /// <returns></returns>
    [HttpGet("Details/{id:int}")]
    public async Task<IActionResult> GetDetailsById([FromRoute] int id)
    {
        Result<Character> result = await service.GetByIdAsync(id);

        Result<CharacterDtoGetDetails> dtoResult = result.MapData(c => c.ToDtoGetDetails());

        return this.GetResult(dtoResult);
    }

    /// <summary>
    /// Request to get a Character from the Database as a CharacterDtoGetRaw.
    /// </summary>
    /// <param name="id">The id of the Character wanted.</param>
    /// <returns></returns>
    [HttpGet("Raw/{id:int}")]
    public async Task<IActionResult> GetBaseById([FromRoute] int id)
    {
        Result<Character> result = await service.GetByIdAsync(id);

        Result<CharacterDtoGetRaw> dtoResult = result.MapData(c => c.ToDtoGetRaw());

        return this.GetResult(dtoResult);
    }

    /// <summary>
    /// Request to create a new Character in the Database.
    /// </summary>
    /// <param name="characterToCreate">The data of the Character to create.</param>
    /// <returns>The CharacterDtoGetDetails version of the created Character.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateCharacter([FromBody] CharacterDtoPost characterToCreate)
    {
        Result<Character> result = await service.CreateCharacterAsync(characterToCreate.ToCommand());

        if(result.ResultCode == ResultCode.DataCreated && result.Data != null)
        {
            return CreatedAtAction(nameof(GetDetailsById), new { id = result.Data.Id }, result.Data.ToDtoGetDetails());
        }

        Result<CharacterDtoGetDetails> dtoResult = result.MapData(c => c.ToDtoGetDetails());

        return this.GetResult(dtoResult);
    }

    /// <summary>
    /// Request to update an existing Character in the Database.
    /// </summary>
    /// <param name="id">The id of the Character to update.</param>
    /// <param name="updateDto">The updated Character's data.</param>
    /// <returns>The CharacterDtoGetDetails version of the updated Character.</returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCharacter([FromRoute] int id, [FromBody] CharacterDtoPut updateDto)
    {
        Result<Character> result = await service.UpdateCharacterAsync(id, updateDto.ToCommand());

        Result<CharacterDtoGetDetails> dtoResult = result.MapData(c => c.ToDtoGetDetails());

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

        Result<CharacterDtoGetDetails> dtoResult = result.MapData(c => c.ToDtoGetDetails());

        return this.GetResult(dtoResult);
    }
}