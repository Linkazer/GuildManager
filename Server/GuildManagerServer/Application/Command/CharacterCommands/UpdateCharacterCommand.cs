namespace GuildManagerServer.Application.Command;

/// <summary>
/// Command data for updating Character.
/// </summary>
public record class UpdateCharacterCommand
{
    public string Name { get; init; } = string.Empty;
    public int RaceId  { get; init; }
    public int JobId { get; init; }
    public int Level { get; init; }

    //Stats
    public int Strength { get; init; }
    public int Spirit { get; init; }
    public int Presence { get; init; }
    public int Dexterity { get; init; }
    public int Instinct { get; init; }

    //Personnalisation
    public int BodyId { get; init; }
    public int HairId { get; init; }
    public int HairColorId { get; init; }
    public int EquipmentId  { get; init; }

    public UpdateCharacterCommand(string nName, int nRaceId, int nJobId, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct,
            int nBodyId, int nHairId, int nHairColorId, int nEquipmentId)
    {
        Name = nName;
        RaceId = nRaceId;
        JobId = nJobId;
        Level = nLevel;
        Strength = nStrength;
        Spirit = nSpirit;
        Presence = nPresence;
        Dexterity = nDexterity;
        Instinct = nInstinct;
        BodyId = nBodyId;
        HairId = nHairId;
        HairColorId = nHairColorId;
        EquipmentId = nEquipmentId;
    }
}
