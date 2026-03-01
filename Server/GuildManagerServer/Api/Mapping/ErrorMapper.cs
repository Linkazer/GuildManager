using GuildManagerServer.Api.Results;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerServer.Api.Mapping;

public static class ErrorMapper
{
    public static IActionResult GetResult<T>(this ControllerBase controller, Result<T> result)
    {
        switch(result.ResultCode)
        {
            case ResultCode.SimpleValidate :
                return controller.NoContent();
            case ResultCode.DataFound :
                return controller.Ok(result.Data);
            case ResultCode.DataCreated:
                //Must be done in the Controller directly.
            case ResultCode.CharacterNotfound:
                return controller.NotFound("Character not found.");
            case ResultCode.InvalidCharacterData:
                if(result.ErrorMessage == string.Empty)
                {
                    return controller.BadRequest("Character data are not valid.");
                }
                return controller.BadRequest(result.ErrorMessage);
            case ResultCode.RaceNotFound:
                return controller.NotFound("Race not found");
            case ResultCode.JobNotFound:
                return controller.NotFound("Job not found.");
            case ResultCode.EquipmentNotFound:
                return controller.NotFound("Equipment not found.");
        }

        return controller.BadRequest(); //Error not mapped
    }
}