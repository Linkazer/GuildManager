using GuildManagerServer.Api.Dto.RaceDto;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Api.Services;
using GuildManagerServer.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerServer.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceService service;

        public RaceController(IRaceService nService)
        {
            service = nService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<Race>> result = await service.GetAllAsync();

            Result<List<DtoGetRace>> mappedResult = result.MapData(list => list.Select(c => c.ToDtoGetRace()).ToList());

            return this.GetResult(mappedResult);
        }
    }
}
