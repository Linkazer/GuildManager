using NUnit.Framework.Internal;

public static class CharacterMapper
{
    public static CharacterData ToData(this CharacterDtoGetDetails getResult)
    {
        return new CharacterData
        {
            Id = getResult.Id,
            Name = getResult.Name,
            RaceId = getResult.RaceId,
            JobId = getResult.JobId,
            Level = getResult.Level,

            Strength = getResult.Strength,
            Spirit = getResult.Spirit,
            Presence = getResult.Presence,
            Dexterity = getResult.Dexterity,
            Instinct = getResult.Instinct,

            BodyId = getResult.BodyId,
            HairId = getResult.HairId,
            HairColorId = getResult.HairColorId,
            EquipmentId = getResult.EquipmentId,

            MaxHealth = getResult.MaxHealth,
            Dodge = getResult.Dodge,
            Will = getResult.Will
        };
    }

    public static CharacterData ToData(this CharacterDtoGetBase dto)
    {
        return new CharacterData
        {
            Id = dto.Id,
            Name = dto.Name,
            RaceId = dto.RaceId,
            JobId = dto.JobId,
            Level = dto.Level,

            Strength = dto.Strength,
            Spirit = dto.Spirit,
            Presence = dto.Presence,
            Dexterity = dto.Dexterity,
            Instinct = dto.Instinct,

            BodyId = dto.BodyId,
            HairId = dto.HairId,
            HairColorId = dto.HairColorId,
            EquipmentId = dto.EquipmentId
        };
    }

    public static CharacterDtoPost ToPost(this CharacterData character)
    {
        return new CharacterDtoPost
        {
            Name = character.Name,
            RaceId = character.RaceId,
            JobId = character.JobId,
            Level = character.Level,

            Strength = character.Strength,
            Spirit = character.Spirit,
            Presence = character.Presence,
            Dexterity = character.Dexterity,
            Instinct = character.Instinct,

            BodyId = character.BodyId,
            HairId = character.HairId,
            HairColorId = character.HairColorId,
            EquipmentId = character.EquipmentId
        };
    }

    public static CharacterDtoPut ToPut(this CharacterData character)
    {
        return new CharacterDtoPut
        {
            Name = character.Name,
            RaceId = character.RaceId,
            JobId = character.JobId,
            Level = character.Level,

            Strength = character.Strength,
            Spirit = character.Spirit,
            Presence = character.Presence,
            Dexterity = character.Dexterity,
            Instinct = character.Instinct,

            BodyId = character.BodyId,
            HairId = character.HairId,
            HairColorId = character.HairColorId,
            EquipmentId = character.EquipmentId
        };
    }

    public static CharacterDtoGetResume ToResume(this CharacterData character)
    {
        return new CharacterDtoGetResume
        {
            Id = character.Id,
            Name = character.Name,
            RaceId = character.RaceId,
            JobId = character.JobId,
            BodyId = character.BodyId,
            HairId = character.HairId,
            HairColorId = character.HairColorId,
            EquipmentId = character.EquipmentId
        };
    }

}
