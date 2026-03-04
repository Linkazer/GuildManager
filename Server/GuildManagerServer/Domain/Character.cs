using GuildManagerServer.Api.Results;

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
    public int Dodge => BaseDodge + TotalDexterity;
    public int Will => BaseWill + TotalSpirit;

    public int TotalStrength => Strength + Race.Strength + Job.Strength;
    public int TotalSpirit => Spirit + Race.Spirit + Job.Spirit;
    public int TotalPresence => Presence + Race.Presence + Job.Presence;
    public int TotalDexterity => Dexterity + Race.Dexterity + Job.Dexterity;
    public int TotalInstinct => Instinct + Race.Instinct + Job.Instinct;

    // Made private so we have to use TryCreate to create a new Character.
    private Character(int nId, string nName, Race nRace, Job nJob, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct, 
        int nBodyId, int nHairId, int nHairColorId, Equipment nEquipment)
    {
        Id = nId;
        Name = nName;
        Race = nRace;
        Job = nJob;
        Level = nLevel;
        Strength = nStrength;
        Spirit = nSpirit;
        Presence = nPresence;
        Dexterity = nDexterity;
        Instinct = nInstinct;
        BodyId = nBodyId;
        HairId = nHairId;
        HairColorId = nHairColorId;
        Equipment = nEquipment;
    }

    public static Result<Character> TryCreate(string nName, Race nRace, Job nJob, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct, 
        int nBodyId, int nHairId, int nHairColorId, Equipment nEquipment)
    {
        Character createdCharacter = new Character(
            0,
            "Newly Created",
            nRace, nJob,
            1, //Level
            0, 0, 0, 0, 0, //Stats
            1, 1, 1, //Custo
            nEquipment
        );

        Result result = new Result();

        result = createdCharacter.SetName(nName);
        if(!result.Succeed)
        {
            return Result<Character>.FromResult(result);
        }
        
        result = createdCharacter.SetStats(nLevel, nStrength, nSpirit, nPresence, nDexterity, nInstinct);
        if(!result.Succeed)
        {
            return Result<Character>.FromResult(result);
        }

        result = createdCharacter.SetPersonalisation(nBodyId, nHairId, nHairColorId);
        if(!result.Succeed)
        {
            return Result<Character>.FromResult(result);
        }

        return Result<Character>.Success(ResultCode.DataCreated, createdCharacter);
    }

    public static Result<Character> TryCreate(int nId, string nName, Race nRace, Job nJob, int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct, 
        int nBodyId, int nHairId, int nHairColorId, Equipment nEquipment)
    {
        if(nId < 1)
        {
            return Result<Character>.Failure(ResultCode.InvalidCharacterData, new KeyValuePair<string, string[]>("Id", new[] {"Id can't be lower than 1."}));
        }

        Result<Character> createdCharacterResult = TryCreate(nName, nRace, nJob, nLevel, nStrength, nSpirit, nPresence, nDexterity, nInstinct, nBodyId, nHairId, nHairColorId, nEquipment);

        if(createdCharacterResult.Succeed)
        {
            createdCharacterResult.Data.SetId(nId);
        }

        return createdCharacterResult;
    }

    public Result SetId(int nId)
    {
        if(nId < 1)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, new KeyValuePair<string, string[]>("Id", new[] {"Id can't be lower than 1."}));
        }

        Id = nId;

        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetName(string nName)
    {
        if(nName == string.Empty || nName.Length > MaxNameLength)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, new KeyValuePair<string, string[]>("Name", new[] {$"Name can't be empty or longer than {MaxNameLength}."}));
        }

        Name = nName;
        
        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetLevel(int nLevel)
    {
        if(nLevel < 1 || nLevel > 10)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, new KeyValuePair<string, string[]>("Level", new[] {$"Level must be between 1 and 10."}));
        }

        Level = nLevel;

        return Result.Success(ResultCode.SimpleValidate);
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
    public Result SetStats(int nLevel, int nStrength, int nSpirit, int nPresence, int nDexterity, int nInstinct)
    {
        Result result = new Result();

        result = SetLevel(nLevel);
        if(!result.Succeed)
        {
            return result;
        }

        int totalAllowed = StartStats + (StatsByTwoLevel * (Level / 2));

        int newTotal = nStrength + nSpirit + nPresence + nDexterity + nInstinct;

        if(newTotal < StartStats || newTotal > totalAllowed)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("TotalStats", new[] {$"Total of stats ({newTotal}) cant be lower than {StartStats} or greater than {totalAllowed}."}));
        }

        result = SetStrength(nStrength);
        if(!result.Succeed)
        {
            return result;
        }

        result = SetSpirit(nSpirit);
        if(!result.Succeed)
        {
            return result;
        }
        
        result = SetPresence(nPresence);
        if(!result.Succeed)
        {
            return result;
        }

        result = SetDexterity(nDexterity);
        if(!result.Succeed)
        {
            return result;
        }

        result = SetInstinct(nInstinct);
        if(!result.Succeed)
        {
            return result;
        }

        return Result.Success(ResultCode.SimpleValidate);
    }

    #region Individual Stats
    public Result SetStrength(int nStrength)
    {
        if(nStrength > StartStats + Level / 2)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("Strength", new[] {$"Strength at level {Level} must not exceed {StartStats + Level / 2}."}));
        }

        Strength = nStrength;

        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetSpirit(int nSpirit)
    {
        if(nSpirit - StartStats > Level / 2)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("Spirit", new[] {$"Spirit at level {Level} must not exceed {StartStats + Level / 2}."}));
        }

        Spirit = nSpirit;

        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetPresence(int nPresence)
    {
        if(nPresence - StartStats > Level / 2)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("Presence", new[] {$"Presence at level {Level} must not exceed {StartStats + Level / 2}."}));
        }

        Presence = nPresence;

        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetDexterity(int nDexterity)
    {
        if(nDexterity - StartStats > Level / 2)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("Dexterity", new[] {$"Dexterity at level {Level} must not exceed {StartStats + Level / 2}."}));
        }

        Dexterity = nDexterity;

        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetInstinct(int nInstinct)
    {
        if(nInstinct - StartStats > Level / 2)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("Instinct", new[] {$"Instinct at level {Level} must not exceed {StartStats + Level / 2}."}));
        }

        Instinct = nInstinct;

        return Result.Success(ResultCode.SimpleValidate);
    }
    #endregion
    #endregion

    #region  Personalisation
    public Result SetPersonalisation(int nBodyId, int nHairId, int nHairColorId)
    {
        Result result = new Result();

        result = SetBody(nBodyId);
        if(!result.Succeed)
        {
            return result;
        }

        result = SetHair(nHairId, nHairColorId);
        if(!result.Succeed)
        {
            return result;
        }

        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetBody(int nBodyId)
    {
        if(nBodyId < 1)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("BodyId", new[] {"BodyId can't be lower than 1."}));
        }

        BodyId = nBodyId;

        return Result.Success(ResultCode.SimpleValidate);
    }

    public Result SetHair(int nHairId, int nHairColorId)
    {
        if(nHairId < 1 || nHairColorId < 1)
        {
            return Result.Failure(ResultCode.InvalidCharacterData, 
                new KeyValuePair<string, string[]>("HairId", new[] {"HairId and HairColorId can't be lower than 1."}));
        }

        HairId = nHairId;
        HairColorId = nHairColorId;

        return Result.Success(ResultCode.SimpleValidate);
    }
    #endregion
}
