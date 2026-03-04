using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCustomBody", menuName = "Scriptable Objects/CharacterCustomBody")]
public class CharacterCustomBody : ScriptableObject
{
    [SerializeField] private int raceId;

    [SerializeField] private GameObject[] bodyPrefabs;

    public int RaceId => raceId;

    public GameObject GetBody(int id)
    {
        return bodyPrefabs[id];
    }
}
