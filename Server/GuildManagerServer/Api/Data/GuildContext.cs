using GuildManagerServer.Api.Models;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GuildManagerServer.Api.Data;

public class GuildContext : DbContext
{
    public GuildContext(DbContextOptions<GuildContext> options)
        : base(options)
    {  
    }

    public DbSet<Character> Character { get; set; }
    public DbSet<Race> Race { get; set; }
    public DbSet<Job> Job { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
}
