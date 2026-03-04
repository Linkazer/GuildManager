using GuildManagerServer.Api.Data;
using GuildManagerServer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerServer.Api.Repositories;

public class JobRepository : IJobRepository
{
    private readonly GuildContext context;

    public JobRepository(GuildContext nContext)
    {
        context = nContext;
    }

    public async Task<List<JobModel>> GetAllModelsAsync()
    {
        return await context.Job.ToListAsync();
    }

    public async Task<JobModel?> GetByIdAsync(int id)
    {
        return await context.Job.FindAsync(id);
    }
}
