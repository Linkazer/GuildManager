using GuildManager;
using UnityEngine;

public class TetObject : MonoBehaviour
{
    [SerializeField] private CharacterDisplay character;

    public int characterImpected;
    public TestClassGet getResult;
    public TestClassPost postData;
    public TestClassPut putData;

    [ContextMenu("Set Character")]
    async void SetCharacter()
    {
        if(getResult != null)
        {
            character.SetCharacter(getResult.ToData());
        }
    }

    [ContextMenu("Request/GET")]
    async void Get()
    {
        getResult = await HttpRequests.Get<TestClassGet>($"http://localhost:5181/api/Character/{characterImpected}");

        getResult.Print();
    }

    [ContextMenu("Request/POST")]
    async void Post()
    {
        getResult = await HttpRequests.Post<TestClassGet>("http://localhost:5181/api/Character", postData);

        if (getResult != null)
        {
            getResult.Print();
        }
        else
        {
            Debug.Log("Post didn't succeed");
        }
    }

    [ContextMenu("Request/PUT")]
    async void Put()
    {
        await HttpRequests.Put<TestClassGet>($"http://localhost:5181/api/Character/{characterImpected}", putData);
    }


    [ContextMenu("Request/DELETE")]
    async void Delete()
    {
        bool result = await HttpRequests.Delete<TestClassGet>($"http://localhost:5181/api/Character/{characterImpected}");
        Debug.Log("Delete with result : " + result);
    }
}
