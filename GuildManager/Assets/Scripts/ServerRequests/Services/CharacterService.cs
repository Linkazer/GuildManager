using GuildManager;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public static class CharacterService
{
    private const string RequestCharacterUrl = "Character";
    private const string RequestResumeUrl = "Resume";
    private const string RequestDetailsUrl = "Details";
    private const string RequestBaseUrl = "Base";

    public static async Task<List<CharacterDtoGetResume>> GetAllCharactersResumes()
    {
        List<CharacterDtoGetResume> getData = await HttpRequests.Get<List<CharacterDtoGetResume>>(RequestCharacterUrl);

        return getData;
    }

    public static async Task<CharacterDtoGetResume> GetCharacterResumeById(int id)
    {
        CharacterDtoGetResume getData = await HttpRequests.Get<CharacterDtoGetResume>($"{RequestCharacterUrl}/{RequestResumeUrl}/{id}");

        return getData;
    }

    public static async Task<CharacterDtoGetDetails> GetCharacterDetailsById(int id)
    {
        CharacterDtoGetDetails getData = await HttpRequests.Get<CharacterDtoGetDetails>($"{RequestCharacterUrl}/{RequestDetailsUrl}/{id}");

        return getData;
    }

    public static async Task<CharacterDtoGetBase> GetCharacterBaseById(int id)
    {
        CharacterDtoGetBase getData = await HttpRequests.Get<CharacterDtoGetBase>($"{RequestCharacterUrl}/{RequestBaseUrl}/{id}");

        return getData;
    }

    public static async Task<CharacterData> GetCharacterById(int id)
    {
        CharacterDtoGetDetails getData = await GetCharacterDetailsById(id);

        if (getData != null)
        {
            return getData.ToData();
        }

        return null;
    }

    public static async Task PostCharacter(CharacterData dataToPost)
    {
        await HttpRequests.Post<CharacterDtoGetDetails>(RequestCharacterUrl, dataToPost.ToPost());
    }

    public static async Task PutCharacter(int id, CharacterData dataToPut)
    {
        await HttpRequests.Put<CharacterDtoGetDetails>($"{RequestCharacterUrl}/{id}", dataToPut.ToPut());
    }

    public static async Task DeleteCharacter(int id)
    {
        await HttpRequests.Delete($"{RequestCharacterUrl}/{id}");
    }
}
