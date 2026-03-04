using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterDisplayHandler : MonoBehaviour
{
    private static CharacterDisplayHandler instance;

    public static CharacterDisplayHandler Instance => instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    [SerializeField] private CharacterDisplay displayPrefab;
    [SerializeField] private Transform[] displayHolders;

    private Dictionary<int, CharacterDisplay> displayedCharacters = new Dictionary<int, CharacterDisplay>();

    private List<Transform> availableHolders = new List<Transform>();

    private void DisplayCharacters(List<CharacterDtoGetResume> displayData)
    {
        foreach(CharacterDtoGetResume data in displayData)
        {
            AddCharacter(data.Id, data);
        }
    }

    private Transform UseHolder()
    {
        if (availableHolders.Count > 0)
        {
            Transform toReturn = availableHolders[Random.Range(0, availableHolders.Count)];
            availableHolders.Remove(toReturn);
            return toReturn;
        }
        return null;
    }

    private void ClearDisplay()
    {
        availableHolders = displayHolders.ToList();

        foreach(KeyValuePair<int, CharacterDisplay> displayedCharacter in displayedCharacters)
        {
            Destroy(displayedCharacter.Value.gameObject);
        }

        displayedCharacters.Clear();
    }

    public void ReloadAll(List<CharacterDtoGetResume> displayData)
    {
        ClearDisplay();
        DisplayCharacters(displayData);
    }

    private void AddCharacter(int id, CharacterDtoGetResume data)
    {
        Transform holder = UseHolder();

        if (holder != null)
        {
            CharacterDisplay newDisplay = Instantiate(displayPrefab, holder);
            newDisplay.SetCharacter(data);

            displayedCharacters.Add(data.Id, newDisplay);
        }
    }

    private void RemoveCharacter(int id)
    {
        if(displayedCharacters.ContainsKey(id))
        {
            Destroy(displayedCharacters[id].gameObject);
            displayedCharacters.Remove(id);
        }
    }
}
