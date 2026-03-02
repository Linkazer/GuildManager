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
}
