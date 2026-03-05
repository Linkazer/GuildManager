using UnityEngine;

/// <summary>
/// Contains the data for an Equipment's customisation element.
/// </summary>
[CreateAssetMenu(fileName = "CharacterCustomEquipment", menuName = "Scriptable Objects/CharacterCustomEquipment")]
public class CharacterCustomEquipment : ScriptableObject
{
    [SerializeField] private int equipmentId;

    [SerializeField] private Sprite[] bodySprite;

    public int EquipmentId => equipmentId;

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
