using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Api.Services;
using GuildManagerServer.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
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
        Result<List<Character>> result = await service.GetAllAsync();

        Result<List<DtoGetCharacter>> mappedResult = result.Map(list => list.Select(c => c.ToDtoGetCharacter()).ToList());

        return this.GetResult(mappedResult);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        Result<Character> result = await service.GetByIdAsync(id);

        Result<DtoGetCharacter> dtoResult = result.Map(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCharacter([FromBody] DtoPostCharacter characterToCreate)
    {
        Result<Character> result = await service.CreateCharacterAsync(characterToCreate);

        if(result.ResultCode == ResultCode.DataCreated && result.Data != null)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data.ToDtoGetCharacter());
        }

        Result<DtoGetCharacter> dtoResult = result.Map(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCharacter([FromRoute] int id, [FromBody] DtoPutCharacter updateDto)
    {
        Result<Character> result = await service.UpdateCharacterAsync(id, updateDto);

        Result<DtoGetCharacter> dtoResult = result.Map(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        Result<Character> result = await service.DeleteCharacterAsync(id);

        Result<DtoGetCharacter> dtoResult = result.Map(c => c.ToDtoGetCharacter());

        return this.GetResult(dtoResult);
    }
}