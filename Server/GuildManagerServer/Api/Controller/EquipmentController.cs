using GuildManagerServer.Api.Dto.EquipmentDto;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Api.Services;
using GuildManagerServer.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerServer.Api.Controller
{
    /// <summary>
    /// Controller for Equipment data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService service;

        public EquipmentController(IEquipmentService nService)
        {
            service = nService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<Equipment>> result = await service.GetAllAsync();

            Result<List<DtoGetEquipment>> mappedResult = result.MapData(list => list.Select(e => e.ToDtoGetEquipment()).ToList());

            return this.GetResult(mappedResult);
        }
    }
}
