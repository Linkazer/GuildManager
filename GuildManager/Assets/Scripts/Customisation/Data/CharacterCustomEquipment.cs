using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCustomEquipment", menuName = "Scriptable Objects/CharacterCustomEquipment")]
public class CharacterCustomEquipment : ScriptableObject
{
    [SerializeField] private int equipmentId;

    [SerializeField] private Sprite[] bodySprite;

    public int EquipmentId => equipmentId;

    public Sprite GetBody(int id)
    {
        return bodySprite[id];
    }
}
