using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Application.Command;

namespace GuildManagerServer.Domain.Factory;

public class CharacterFactory
{
    /// <summary>
    /// Try to create a new Character, checking all data before validating the Character's creation.
    /// </summary>
    /// <returns>
    ///     If the Character is created, return a DataCreated result with the Character data in it.
    ///     If one or more data aren't correct, return an error Result specific to the incorrect data.
    /// </returns>
    public static Result<Character> TryCreate(int nId, string nName, Race nRace, Job nJob, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct, 
        int nBodyId, int nHairId, int nHairColorId, Equipment nEquipment)
    {
        return Character.TryCreateWithId(nId, nName, nRace, nJob, nLevel, nStrength, nSpirit, nPresence, nDexterity, nInstinct, nBodyId, nHairId, nHairColorId, nEquipment);
    }

    /// <summary>
    /// Try to create a new Character based on a Model.
    /// </summary>
    /// <returns>
    ///     If the Character is created, return a DataCreated result with the Character data in it.
    ///     If one or more data aren't correct, return an error Result specific to the incorrect data.
    /// </returns>
    public static Result<Character> TryCreate(CharacterModel model)
    {
        if(model.Race == null)
        {
            return Result<Character>.Failure(ResultCode.RaceNotFound);
        }

        if(model.Job == null)
        {
            return Result<Character>.Failure(ResultCode.JobNotFound);
        }

        if(model.Equipment == null)
        {
            return Result<Character>.Failure(ResultCode.EquipmentNotFound);
        }

        return TryCreate(model.Id, model.Name, model.Race.ToRace(), model.Job.ToJob(), model.Level, model.Strength, model.Spirit, model.Presence,
                model.Dexterity, model.Instinct, model.BodyId, model.HairId, model.HairColorId, model.Equipment.ToEquipment());
    }

    /// <summary>
    /// Try to create a new Character based on a CreateCharacterCommand.
    /// </summary>
    /// <returns>
    ///     If the Character is created, return a DataCreated result with the Character data in it.
    ///     If one or more data aren't correct, return an error Result specific to the incorrect data.
    /// </returns>
    public static Result<Character> TryCreate(CreateCharacterCommand creationCommand, Race nRace, Job nJob, Equipment nEquipment)
    {
        return Character.TryCreate(creationCommand.Name, nRace, nJob, creationCommand.Level, creationCommand.Strength, creationCommand.Spirit,
                creationCommand.Presence, creationCommand.Dexterity, creationCommand.Instinct, creationCommand.BodyId, creationCommand.HairId, creationCommand.HairColorId,
                nEquipment);
    }
}
