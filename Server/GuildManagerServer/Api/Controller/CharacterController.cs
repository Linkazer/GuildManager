using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Services;
using GuildManagerServer.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerServer.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService service;

    public CharacterController(ICharacterService nService)
    {
        service = nService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Character> characters = await service.GetAllAsync();

        List<DtoGetCharacter> characterDtos = characters.Select(c => c.ToDtoGetCharacter()).ToList();

        return Ok(characterDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        Character? character = await service.GetByIdAsync(id);

        if(character == null)
        {
            return NotFound();
        }

        return Ok(character.ToDtoGetCharacter());
    }

    [HttpPost]
    public async Task<IActionResult> CreateCharacter([FromBody] DtoPostCharacter characterToCreate)
    {
        Character? createdCharacter = await service.CreateCharacterAsync(characterToCreate);

        if(createdCharacter == null)
        {
            return Conflict();
        }

        return Ok(createdCharacter.ToDtoGetCharacter());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCharacter([FromRoute] int id, [FromBody] DtoPutCharacter updateDto)
    {
        Character? updatedCharacter = await service.UpdateCharacterAsync(id, updateDto);

        if(updatedCharacter == null)
        {
            return NotFound(id);
        }

        return Ok(updatedCharacter.ToDtoGetCharacter()); // CODE REVIEW : Voir si c'est nécessaire, ou si on renvoit juste NoContent
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        await service.DeleteCharacterAsync(id);

        return NoContent();
    }
}
