using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public class JobService : IJobService
{
    private readonly IJobRepository repository;

    public JobService(IJobRepository nRepository)
    {
        repository = nRepository;
    }

    public async Task<Job?> GetByIdAsync(int id)
    {
        JobModel? model = await repository.GetByIdAsync(id);

        if(model == null)
        {
            return null;
        }

        return model.ToJob();
    }
}
