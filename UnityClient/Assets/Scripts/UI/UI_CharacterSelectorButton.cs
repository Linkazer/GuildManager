using TMPro;
using UnityEngine;

/// <summary>
/// Handle the selection of a Character in the CharacterSelector menu.
/// </summary>
public class UI_CharacterSelectorButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private int characterId;

    private UI_CharacterSelector selector;

    public void Set(UI_CharacterSelector nSelector, int id, string name)
    {
        selector = nSelector;
        characterId = id;
        buttonText.text = name;
    }

    public void UE_SelectCharacter()
    {
        selector.SelectCharacter(characterId);
    }
}
