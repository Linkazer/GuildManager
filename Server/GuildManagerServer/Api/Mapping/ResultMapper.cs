using GuildManagerServer.Api.Results;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerServer.Api.Mapping;

/// <summary>
/// Mapper for the Result class.
/// </summary>
public static class ResultMapper
{
    /// <summary>
    /// Get an IActionResult from a Result.
    /// </summary>
    /// <typeparam name="T">The type of data the Result wanted.</typeparam>
    /// <param name="controller">The controller in which we want to get the Result.</param>
    /// <param name="result">The Result sent by the Service.</param>
    /// <returns>The IActionResult corresponding to the Result.</returns>
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
                break;
            case ResultCode.CharacterNotfound:
                return controller.NotFound("Character not found.");
            case ResultCode.InvalidCharacterData:
                if (result.ErrorMessage.Key == null || result.ErrorMessage.Value == null || result.ErrorMessage.Value.Length == 0)
                {
                    return controller.BadRequest("Character data are not valid.");
                }

                var errors = new Dictionary<string, string[]>
                {
                    [result.ErrorMessage.Key] = result.ErrorMessage.Value
                };

                var problemDetails = new ValidationProblemDetails(errors)
                {
                    Title = "Validation Failed",
                    Status = StatusCodes.Status400BadRequest
                };

                return controller.BadRequest(problemDetails);
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