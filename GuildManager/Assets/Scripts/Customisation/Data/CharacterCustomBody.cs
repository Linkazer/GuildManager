using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCustomBody", menuName = "Scriptable Objects/CharacterCustomBody")]
public class CharacterCustomBody : ScriptableObject
{
    [SerializeField] private int raceId;

    [SerializeField] private Sprite[] bodySprite;

    public int RaceId => raceId;

    public Sprite GetBody(int id)
    {
        return bodySprite[id];
    }
}
