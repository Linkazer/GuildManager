using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Mapping;

public static class RaceMapping
{
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
}
