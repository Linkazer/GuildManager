using GuildManagerServer.Api.Dto.RaceDto;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Mapping;

public static class RaceMapper
{
    /// <summary>
    /// Map a RaceModel to an Race.
    /// </summary>
    /// <param name="model">The Model to map.</param>
    /// <returns></returns>
    public static Race ToRace(this RaceModel model)
    {
        return new Race
        {
            Id = model.Id,
            Name = model.Name,

            Strength = model.Strength,
            Spirit = model.Spirit,
            Presence = model.Presence,
            Dexterity = model.Dexterity,
            Instinct = model.Instinct,

            Health = model.Health
        };
    }
    
    public static DtoGetRace ToDtoGetRace(this Race race)
    {
        return new DtoGetRace
        {
            Id = race.Id,
            Name = race.Name
        };
    }
}
