namespace GuildManagerServer.Domain;

/// <summary>
/// Domain class for Characters.
/// </summary>
public class Character
{
    private const int BaseDodge = 3;
    private const int BaseWill = 3;
    private const int StartStats = -1 + 1 + 2;
    private const int StatsByTwoLevel = 2;
    private const int MaxNameLength = 25;

    //Base
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Race Race  { get; private set; }
    public Job Job { get; private set; }
    public int Level { get; private set; }

    //Stats
    public int Strength { get; private set; }
    public int Spirit { get; private set; }
    public int Presence { get; private set; }
    public int Dexterity { get; private set; }
    public int Instinct { get; private set; }

    //Personnalisation
    public int BodyId { get; private set; }
    public int HairId { get; private set; }
    public int HairColorId { get; private set; }
    public Equipment Equipment  { get; private set; }

    //Calculated
    public int MaxHealth => Race.Health + Job.HealthByLevel * Level;
    public int Dodge => BaseDodge + Dexterity;
    public int Will => BaseWill + Spirit;

    public Character(int nId, string nName, Race nRace, Job nJob, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct, 
        int nBodyId, int nHairId, int nHairColorId, Equipment nEquipment)
    {
        Race = nRace;
        Job = nJob;
        Equipment = nEquipment;

        SetCharacter(nId, nName, nRace, nJob, nLevel, nStrength, nSpirit, nPresence, nDexterity, nInstinct, nBodyId, nHairId, nHairColorId, nEquipment);
    }

    public Character(string nName, Race nRace, Job nJob, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct, int nBodyId, int nHairId, int nHairColorId, Equipment nEquipment)
    {
        SetName(nName);

        Race = nRace;
        Job = nJob;
        Equipment = nEquipment;

        SetStats(nLevel, nStrength, nSpirit, nPresence, nDexterity, nInstinct);

        SetPersonalisation(nBodyId, nHairId, nHairColorId);
    }

    public void SetCharacter(int nId, string nName, Race nRace, Job nJob, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct, int nBodyId, int nHairId, int nHairColorId, Equipment nEquipment)
    {
        SetId(nId);

        SetName(nName);
        
        Race = nRace;
        Job = nJob;
        Equipment = nEquipment;

        SetStats(nLevel, nStrength, nSpirit, nPresence, nDexterity, nInstinct);

        SetPersonalisation(nBodyId, nHairId, nHairColorId);
    }

    public void SetId(int nId)
    {
        if(nId < 1)
        {
            throw new ArgumentOutOfRangeException("Id can't be less than 1.");
        }

        Id = nId;
    }

    public void SetName(string nName)
    {
        if(nName == string.Empty || nName.Length > MaxNameLength)
        {
            throw new ArgumentException("Invalid Character name");
        }

        Name = nName;
    }

    public void SetLevel(int nLevel)
    {
        if(nLevel < 1 || nLevel > 10)
        {
            throw new ArgumentOutOfRangeException("Level must be between 1 and 10.");
        }

        Level = nLevel;
    }

    #region References
    public void SetRace(Race nRace)
    {
        Race = nRace;
    }

    public void SetJob(Job nJob)
    {
        Job = nJob;
    }

    public void SetEquipment(Equipment nEquipment)
    {
        Equipment = nEquipment;
    }
    #endregion

    #region All Stats
    public void SetStats(int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct)
    {
        SetLevel(nLevel);

        int totalStartingStats = Race.GetTotalStats() + Job.GetTotalStats() + StartStats;

        int totalAllowed = totalStartingStats + (StatsByTwoLevel * (Level / 2));

        int newTotal = nStrength + nSpirit + nPresence + nDexterity + nInstinct;

        if(newTotal < totalStartingStats || newTotal > totalAllowed)
        {
            throw new ArgumentOutOfRangeException("Invalid stats (Total is too small or too big).");
        }

        SetStrength(nStrength);
        SetSpirit(nSpirit);
        SetPresence(nPresence);
        SetDexterity(nDexterity);
        SetInstinct(nInstinct);
    }

    #region Individual Stats
    public void SetStrength(int nStrength)
    {
        if(nStrength - (Race.Strength + Job.Strength + StartStats) > Level / 2)
        {
            throw new ArgumentOutOfRangeException("Invalid stats : Strength is too high.");
        }

        Strength = nStrength;
    }

    public void SetSpirit(int nSpirit)
    {
        if(nSpirit - (Race.Spirit + Job.Spirit + StartStats) > Level / 2)
        {
             throw new ArgumentOutOfRangeException("Invalid stats : Spirit is too high.");
        }

        Spirit = nSpirit;
    }

    public void SetPresence(int nPresence)
    {
        if(nPresence - (Race.Presence + Job.Presence + StartStats) > Level / 2)
        {
             throw new ArgumentOutOfRangeException("Invalid stats : Presence is too high.");
        }

        Presence = nPresence;
    }

    public void SetDexterity(int nDexterity)
    {
        if(nDexterity - (Race.Dexterity + Job.Dexterity + StartStats) > Level / 2)
        {
             throw new ArgumentOutOfRangeException("Invalid stats : Dexterity is too high.");
        }

        Dexterity = nDexterity;
    }

    public void SetInstinct(int nInstinct)
    {
        if(nInstinct - (Race.Instinct + Job.Instinct + StartStats) > Level / 2)
        {
             throw new ArgumentOutOfRangeException("Invalid stats : Instinct is too high.");
        }

        Instinct = nInstinct;
    }
    #endregion
    #endregion

    #region  Personalisation
    public void SetPersonalisation(int nBodyId, int nHairId, int nHairColorId)
    {
        SetBody(nBodyId);
        SetHair(nHairId, nHairColorId);
    }

    public void SetBody(int nBodyId)
    {
        if(nBodyId < 1)
        {
            throw new ArgumentOutOfRangeException("Body id can't be less than 1.");
        }

        BodyId = nBodyId;
    }

    public void SetHair(int nHairId, int nHairColorId)
    {
        if(nHairId < 1 || nHairColorId < 1)
        {
            throw new ArgumentOutOfRangeException("Hair and hair color id can't be less than 1.");
        }

        HairId = nHairId;
        HairColorId = nHairColorId;
    }
    #endregion
}
