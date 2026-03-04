using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCustomHair", menuName = "Scriptable Objects/CharacterCustomHair")]
public class CharacterCustomHair : ScriptableObject
{
    [SerializeField] private int hairId;

    [SerializeField] private Sprite[] hairSprite;

    public int HairId => hairId;

    public Sprite GetHair(int colorId)
    {
        return hairSprite[colorId];
    }
}
