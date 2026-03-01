using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Mapping;

public static class CharacterMapping
{
    public static Character ToCharacter(this CharacterModel characterModel)
    {
        if(characterModel.Race == null)
        {
            throw new InvalidOperationException("Race must be included in the CharacterModel.");
        }

        if(characterModel.Job == null)
        {
            throw new InvalidOperationException("Job must be included in the CharacterModel.");
        }

        if(characterModel.Equipment == null)
        {
            throw new InvalidOperationException("Equipment must be included in the CharacterModel.");
        }

        return new Character
        (
            characterModel.Id,
            characterModel.Name,
            characterModel.Race.ToRace(),
            characterModel.Job.ToJob(),
            characterModel.Level,

            characterModel.Strength,
            characterModel.Spirit,
            characterModel.Presence,
            characterModel.Dexterity,
            characterModel.Instinct,

            characterModel.BodyId,
            characterModel.HairId,
            characterModel.HairColorId,
            characterModel.Equipment.ToEquipment()
        );
    }

    public static CharacterModel ToModel(this Character character, RaceModel race, JobModel job, EquipmentModel equipment)
    {
        return new CharacterModel
        {
            Id = character.Id,
            Name = character.Name,
            RaceId = character.Race.Id,
            Race = race,
            JobId = character.Job.Id,
            Job = job,
            Level = character.Level,

            Strength = character.Strength,
            Spirit = character.Spirit,
            Presence = character.Presence,
            Dexterity = character.Dexterity,
            Instinct = character.Instinct,

            BodyId = character.BodyId,
            HairId = character.HairId,
            HairColorId = character.HairColorId,
            EquipmentId = character.Equipment.Id,
            Equipment = equipment
        };
    }

    public static DtoGetCharacter ToDtoGetCharacter(this Character character)
    {
        return new DtoGetCharacter
        {
            Id = character.Id,
            Name = character.Name,
            RaceId = character.Race.Id,
            JobId = character.Job.Id,
            Level = character.Level,

            Strength = character.Strength,
            Spirit = character.Spirit,
            Presence = character.Presence,
            Dexterity = character.Dexterity,
            Instinct = character.Instinct,

            BodyId = character.BodyId,
            HairId = character.HairId,
            HairColorId = character.HairColorId,
            EquipmentId = character.Equipment.Id,

            MaxHealth = character.MaxHealth,
            Dodge = character.Dodge,
            Will = character.Will
        };
    }

    public static Character ToCharacter(this DtoPostCharacter postCharacter, Race race, Job job, Equipment equipment)
    {
        return new Character
        (
            postCharacter.Name,
            race,
            job,
            postCharacter.Level,

            postCharacter.Strength,
            postCharacter.Spirit,
            postCharacter.Presence,
            postCharacter.Dexterity,
            postCharacter.Instinct,

            postCharacter.BodyId,
            postCharacter.HairId,
            postCharacter.HairColorId,
            equipment
        );
    }
}
