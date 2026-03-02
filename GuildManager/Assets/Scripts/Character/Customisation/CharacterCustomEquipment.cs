using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCustomEquipment", menuName = "Scriptable Objects/CharacterCustomEquipment")]
public class CharacterCustomEquipment : ScriptableObject
{
    [SerializeField] private int equipmentId;

    [SerializeField] private GameObject[] bodyPrefabs;

    public int EquipmentId => equipmentId;

    public GameObject GetBody(int id)
    {
        return bodyPrefabs[id];
    }
}
