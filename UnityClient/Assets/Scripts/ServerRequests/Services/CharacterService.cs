using GuildManager;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Service that provides access to every Character's server requests.
/// </summary>
public static class CharacterService
{
    private const string RequestCharacterUrl = "Character";
    private const string RequestResumeUrl = "Resume";
    private const string RequestDetailsUrl = "Details";
    private const string RequestBaseUrl = "Base";

    /// <summary>
    /// Get all Character as a Resume DTO.
    /// </summary>
    /// <returns></returns>
    public static async Task<List<CharacterDtoGetResume>> GetAllCharactersResumes()
    {
        List<CharacterDtoGetResume> getData = await HttpRequests.Get<List<CharacterDtoGetResume>>(RequestCharacterUrl);

        return getData;
    }

    /// <summary>
    /// Get the Resume DTO of a Character.
    /// </summary>
    /// <param name="id">The Id of the Character to get.</param>
    /// <returns></returns>
    public static async Task<CharacterDtoGetResume> GetCharacterResumeById(int id)
    {
        CharacterDtoGetResume getData = await HttpRequests.Get<CharacterDtoGetResume>($"{RequestCharacterUrl}/{RequestResumeUrl}/{id}");

        return getData;
    }

    /// <summary>
    /// Get the Detail DTO of a Character.
    /// </summary>
    /// <param name="id">The Id of the Character to get.</param>
    /// <returns></returns>
    public static async Task<CharacterDtoGetDetails> GetCharacterDetailsById(int id)
    {
        CharacterDtoGetDetails getData = await HttpRequests.Get<CharacterDtoGetDetails>($"{RequestCharacterUrl}/{RequestDetailsUrl}/{id}");

        return getData;
    }

    /// <summary>
    /// Get the Raw DTO of a Character.
    /// </summary>
    /// <param name="id">The Id of the Character to get.</param>
    /// <returns></returns>
    public static async Task<CharacterDtoGetBase> GetCharacterBaseById(int id)
    {
        CharacterDtoGetBase getData = await HttpRequests.Get<CharacterDtoGetBase>($"{RequestCharacterUrl}/{RequestBaseUrl}/{id}");

        return getData;
    }

    /// <summary>
    /// Get a full Character.
    /// </summary>
    /// <param name="id">The Id of the Character to get.</param>
    /// <returns></returns>
    public static async Task<CharacterData> GetCharacterById(int id)
    {
        CharacterDtoGetDetails getData = await GetCharacterDetailsById(id);

        if (getData != null)
        {
            return getData.ToData();
        }

        return null;
    }

    /// <summary>
    /// Request the server to add a Character to the database.
    /// </summary>
    /// <param name="dataToPost">The Character's data to send.</param>
    /// <returns></returns>
    public static async Task PostCharacter(CharacterData dataToPost)
    {
        await HttpRequests.Post<CharacterDtoGetDetails>(RequestCharacterUrl, dataToPost.ToPost());
    }

    /// <summary>
    /// Request the server to update a Character in the database.
    /// </summary>
    /// <param name="id">The Id of the Character to update.</param>
    /// <param name="dataToPut">The Character's data to send.</param>
    /// <returns></returns>
    public static async Task PutCharacter(int id, CharacterData dataToPut)
    {
        await HttpRequests.Put<CharacterDtoGetDetails>($"{RequestCharacterUrl}/{id}", dataToPut.ToPut());
    }

    /// <summary>
    /// Request the server to delete a Character from the database.
    /// </summary>
    /// <param name="id">The Id of the Character to delete.</param>
    /// <returns></returns>
    public static async Task DeleteCharacter(int id)
    {
        await HttpRequests.Delete($"{RequestCharacterUrl}/{id}");
    }
}
