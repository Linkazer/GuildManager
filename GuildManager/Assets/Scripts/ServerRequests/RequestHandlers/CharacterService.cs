using GuildManager;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public static class CharacterService
{
    private const string RequestUrl = "Character";

    public static async Task<List<CharacterData>> GetAllCharacters()
    {
        List<DtoGetCharacter> getData = await HttpRequests.Get<List<DtoGetCharacter>>(RequestUrl);

        return getData.Select(c => c.ToData()).ToList();
    }

    public static async Task<CharacterData> GetCharacterById(int id)
    {
        DtoGetCharacter getData = await HttpRequests.Get<DtoGetCharacter>($"{RequestUrl}/{id}");

        if (getData != null)
        {
            return getData.ToData();
        }

        return null;
    }

    public static async Task PostCharacter(CharacterData dataToPost)
    {
        await HttpRequests.Post<DtoGetCharacter>(RequestUrl, dataToPost.ToPost());
    }

    public static async Task PutCharacter(int id, CharacterData dataToPut)
    {
        await HttpRequests.Put<DtoGetCharacter>($"{RequestUrl}/{id}", dataToPut.ToPut());
    }

    public static async Task DeleteCharacter(int id)
    {
        await HttpRequests.Delete($"{RequestUrl}/{id}");
    }
}
