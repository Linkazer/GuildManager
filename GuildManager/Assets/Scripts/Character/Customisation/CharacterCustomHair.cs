using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCustomHair", menuName = "Scriptable Objects/CharacterCustomHair")]
public class CharacterCustomHair : ScriptableObject
{
    [SerializeField] private int hairId;

    [SerializeField] private GameObject[] hairPrefabs;

    public int HairId => hairId;

    public GameObject GetHair(int colorId)
    {
        return hairPrefabs[colorId];
    }
}
