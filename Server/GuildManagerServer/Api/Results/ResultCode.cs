namespace GuildManagerServer.Api.Results;

/// <summary>
/// All available Result that can be mapped.
/// </summary>
public enum ResultCode
{
    #region Valid Result
    SimpleValidate,
    DataFound,
    DataCreated,
    #endregion

    #region Invalid Result
    // Character
    CharacterNotfound,
    InvalidCharacterData,

    // Race
    RaceNotFound,

    // Job
    JobNotFound,

    // Equipment
    EquipmentNotFound,
    #endregion
}
