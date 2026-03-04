using GuildManagerServer.Api.Dto.JobDto;
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
    public class JobController : ControllerBase
    {
        private readonly IJobService service;

        public JobController(IJobService nService)
        {
            service = nService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<Job>> result = await service.GetAllAsync();

            Result<List<DtoGetJob>> mappedResult = result.MapData(list => list.Select(c => c.ToDtoGetJob()).ToList());

            return this.GetResult(mappedResult);
        }
    }
}
