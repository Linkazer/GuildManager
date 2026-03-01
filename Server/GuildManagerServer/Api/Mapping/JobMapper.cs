using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Mapping;

public static class JobMapper
{
    /// <summary>
    /// Map a JobModel to an Job.
    /// </summary>
    /// <param name="model">The Model to map.</param>
    /// <returns></returns>
    public static Job ToJob(this JobModel model)
    {
        return new Job
        {
            Id = model.Id,
            Name = model.Name,

            Strength = model.Strength,
            Spirit = model.Spirit,
            Presence = model.Presence,
            Dexterity = model.Dexterity,
            Instinct = model.Instinct,

            HealthByLevel = model.HealthByLevel
        };
    }
}
