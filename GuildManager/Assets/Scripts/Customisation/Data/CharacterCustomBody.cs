using UnityEngine;

/// <summary>
/// Contains the data for a Race's body customisation element.
/// </summary>
[CreateAssetMenu(fileName = "CharacterCustomBody", menuName = "Scriptable Objects/CharacterCustomBody")]
public class CharacterCustomBody : ScriptableObject
{
    [SerializeField] private int raceId;

    [SerializeField] private Sprite[] bodySprite;

    public int RaceId => raceId;

    /// <summary>
    /// Get the render for the corresponding body Id.
    /// </summary>
    /// <param name="id">The Id of the Character's body.</param>
    /// <returns></returns>
    public Sprite GetBody(int id)
    {
        return bodySprite[id];
    }
}
