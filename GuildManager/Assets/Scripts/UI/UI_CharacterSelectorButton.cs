using TMPro;
using UnityEngine;

public class UI_CharacterSelectorButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private int characterId;

    private UI_CharacterSelector selector;

    public void Set(UI_CharacterSelector nSelector, CharacterData data)
    {
        selector = nSelector;
        characterId = data.Id;
        buttonText.text = data.Name;
    }

    public void UE_SelectCharacter()
    {
        selector.SelectCharacter(characterId);
    }
}
