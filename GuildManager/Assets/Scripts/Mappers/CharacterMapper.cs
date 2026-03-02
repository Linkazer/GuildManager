using NUnit.Framework.Internal;

public static class CharacterMapper
{
    public static CharacterData ToData(this TestClassGet getResult)
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

    public static TestClassPost ToPost(this CharacterData character)
    {
        return new TestClassPost
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

    public static TestClassPut ToPut(this CharacterData character)
    {
        return new TestClassPut
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
}
