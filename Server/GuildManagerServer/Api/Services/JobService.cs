using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public class JobService : IJobService
{
    private readonly IJobRepository repository;

    public JobService(IJobRepository nRepository)
    {
        repository = nRepository;
    }

    public async Task<Result<List<Job>>> GetAllAsync()
    {
        List<JobModel> models = await repository.GetAllModelsAsync();

        List<Job> results = models.Select(j => j.ToJob()).ToList();

        if(results.Count() == 0)
        {
            return Result<List<Job>>.Failure(ResultCode.JobNotFound);
        }

        return Result<List<Job>>.Success(ResultCode.DataFound, results);
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
