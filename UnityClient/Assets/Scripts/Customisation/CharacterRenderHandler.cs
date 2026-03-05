using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manage the CharacterDisplayers in the scene, creating and deleting them when needed.
/// </summary>
public class CharacterRenderHandler : MonoBehaviour
{
    private static CharacterRenderHandler instance;

    public static CharacterRenderHandler Instance => instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    [SerializeField] private CharacterRender displayPrefab;
    [SerializeField, Tooltip("All available positions for Characters.")] private Transform[] displayHolders;

    private Dictionary<int, CharacterRender> displayedCharacters = new Dictionary<int, CharacterRender>();

    private List<Transform> availableHolders = new List<Transform>();

    /// <summary>
    /// Display every Character contained in the List.
    /// </summary>
    /// <param name="displayData">The List with Character's data.</param>
    private void DisplayCharacters(List<CharacterDtoGetResume> displayData)
    {
        foreach(CharacterDtoGetResume data in displayData)
        {
            AddCharacter(data.Id, data);
        }
    }

    /// <summary>
    /// Select a random position and remove it from the available position list.
    /// </summary>
    /// <returns>A random available position. If none are available, return NULL.</returns>
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

    /// <summary>
    /// Clear every Characters in the scene and reset the available position list.
    /// </summary>
    private void ClearDisplay()
    {
        availableHolders = displayHolders.ToList();

        foreach(KeyValuePair<int, CharacterRender> displayedCharacter in displayedCharacters)
        {
            Destroy(displayedCharacter.Value.gameObject);
        }

        displayedCharacters.Clear();
    }

    /// <summary>
    /// Reload every Character's diplays.
    /// </summary>
    /// <param name="displayData">The List with Character's data.</param>
    public void ReloadAll(List<CharacterDtoGetResume> displayData)
    {
        ClearDisplay();
        DisplayCharacters(displayData);
    }

    /// <summary>
    /// Add a new Character in the scene.
    /// </summary>
    /// <param name="id">The Id of the Character.</param>
    /// <param name="data">The data of the Character.</param>
    private void AddCharacter(int id, CharacterDtoGetResume data)
    {
        Transform holder = UseHolder();

        if (holder != null)
        {
            CharacterRender newDisplay = Instantiate(displayPrefab, holder);
            newDisplay.SetCharacter(data);

            displayedCharacters.Add(data.Id, newDisplay);
        }
    }
}
