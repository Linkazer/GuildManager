using GuildManagerServer.Api.Dto.CharacterDto;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Application.Command;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Mapping;

/// <summary>
/// Mapper for the Character, with Domain, DTO and Model classes.
/// </summary>
public static class CharacterMapper
{
    #region Model
    /// <summary>
    /// Map a Character to a its Model.
    /// </summary>
    /// <param name="character">The Character to map.</param>
    /// <param name="race">The corresponding RaceModel to link.</param>
    /// <param name="job">The corresponding JobModel to link.</param>
    /// <param name="equipment">The corresponding EquipmentMode to link.</param>
    /// <returns></returns>
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
    #endregion

    #region DTO
    /// <summary>
    /// Map a Character to its GetCharacter DTO.
    /// </summary>
    /// <param name="character">The Character to map.</param>
    /// <returns></returns>
    public static DtoGetCharacter ToDtoGetCharacter(this Character character)
    {
        return new DtoGetCharacter
        {
            Id = character.Id,
            Name = character.Name,
            RaceId = character.Race.Id,
            JobId = character.Job.Id,
            Level = character.Level,

            Strength = character.TotalStrength,
            Spirit = character.TotalSpirit,
            Presence = character.TotalPresence,
            Dexterity = character.TotalDexterity,
            Instinct = character.TotalInstinct,

            BodyId = character.BodyId,
            HairId = character.HairId,
            HairColorId = character.HairColorId,
            EquipmentId = character.Equipment.Id,

            MaxHealth = character.MaxHealth,
            Dodge = character.Dodge,
            Will = character.Will
        };
    }
    #endregion

    #region Command
    public static CreateCharacterCommand ToCommand(this DtoPostCharacter postCharacter)
    {
        return new CreateCharacterCommand(
            postCharacter.Name,
            postCharacter.RaceId,
            postCharacter.JobId,
            postCharacter.Level,
            postCharacter.Strength,
            postCharacter.Spirit,
            postCharacter.Presence,
            postCharacter.Dexterity,
            postCharacter.Instinct,
            postCharacter.BodyId,
            postCharacter.HairId,
            postCharacter.HairColorId,
            postCharacter.EquipmentId
        );
    }

    public static UpdateCharacterCommand ToCommand(this DtoPutCharacter putCharacter)
    {
        return new UpdateCharacterCommand(
            putCharacter.Name,
            putCharacter.RaceId,
            putCharacter.JobId,
            putCharacter.Level,
            putCharacter.Strength,
            putCharacter.Spirit,
            putCharacter.Presence,
            putCharacter.Dexterity,
            putCharacter.Instinct,
            putCharacter.BodyId,
            putCharacter.HairId,
            putCharacter.HairColorId,
            putCharacter.EquipmentId
        );
    }
    #endregion
}
