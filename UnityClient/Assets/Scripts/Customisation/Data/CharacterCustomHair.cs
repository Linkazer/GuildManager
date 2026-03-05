using UnityEngine;

/// <summary>
/// Contains the data for a Hairstyle's customisation element.
/// </summary>
[CreateAssetMenu(fileName = "CharacterCustomHair", menuName = "Scriptable Objects/CharacterCustomHair")]
public class CharacterCustomHair : ScriptableObject
{
    [SerializeField] private int hairId;

    [SerializeField] private Sprite[] hairSprite;

    public int HairId => hairId;

    /// <summary>
    /// Get the hairstyle render with the corresponding color.
    /// </summary>
    /// <param name="colorId">The Id of the color wanted.</param>
    /// <returns></returns>
    public Sprite GetHair(int colorId)
    {
        return hairSprite[colorId];
    }
}
