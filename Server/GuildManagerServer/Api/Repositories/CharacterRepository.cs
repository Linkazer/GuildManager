using GuildManagerServer.Api.Data;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerServer.Api.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly GuildContext context;
    public CharacterRepository(GuildContext nContext)
    {
        context = nContext;
    }

    public async Task<List<CharacterModel>> GetAllModelsAsync()
    {
        return await context.Character.Include(c => c.Race).Include(c => c.Job).Include(c => c.Equipment).ToListAsync();
    }

    public async Task<CharacterModel?> GetModelByIdAsync(int id)
    {
        return await context.Character.Include(c => c.Race).Include(c => c.Job).Include(c => c.Equipment).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddModel(CharacterModel modelToSave)
    {
        context.Character.Add(modelToSave);
        await context.SaveChangesAsync();
    }

    public async Task UpdateModel(CharacterModel modelToUpdate)
    {
        context.Character.Update(modelToUpdate);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteModelAsync(int id)
    {
        await context.Character.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}
