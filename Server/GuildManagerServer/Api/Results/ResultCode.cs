namespace GuildManagerServer.Api.Results;

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

    // Race
    RaceNotFound,

    // Job
    JobNotFound,

    // Equipment
    EquipmentNotFound,
    #endregion
}
