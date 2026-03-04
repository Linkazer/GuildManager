using System.Collections.Generic;
using UnityEngine;

public class UI_CharacterSelector : UI_Menu
{
    [SerializeField] private UI_CharacterSelectorButton buttonPrefab;

    [SerializeField] private RectTransform buttonHolder;

    [Header("Linked menus")]
    [SerializeField] private UI_CharacterDetail detailMenu;
    [SerializeField] private UI_CharacterModifier modifierMenu;

    private List<UI_CharacterSelectorButton> loadedButtons = new List<UI_CharacterSelectorButton>();

    protected override void OnOpenMenu()
    {
        LoadCharacters();
    }

    protected override void OnCloseMenu()
    {
        
    }

    private async void LoadCharacters()
    {
        handler.DisplayLoading();

        CleanButtons();

        List<CharacterDtoGetResume> retrivedData = await CharacterService.GetAllCharactersResumes();

        foreach (CharacterDtoGetResume data in retrivedData)
        {
            UI_CharacterSelectorButton buttonToAdd = Instantiate(buttonPrefab, buttonHolder);
            buttonToAdd.Set(this, data.Id, data.Name);
            loadedButtons.Add(buttonToAdd);
        }

        CharacterDisplayHandler.Instance.ReloadAll(retrivedData);

        handler.HideLoading();
    }

    private void CleanButtons()
    {
        while (loadedButtons.Count > 0)
        {
            Destroy(loadedButtons[0].gameObject);
            loadedButtons.RemoveAt(0);
        }
    }

    public void SelectCharacter(int selectedId)
    {
        detailMenu.SetCharacterId(selectedId);
        handler.OpenMenu(detailMenu);
    }

    private void CreateCharacter()
    {
        modifierMenu.SetExistingCharacterId(-1);
        handler.OpenMenu(modifierMenu);
    }

    public void UE_SelectCharacter(int selectedId)
    {
        SelectCharacter(selectedId);
    }

    public void UE_Reload()
    {
        LoadCharacters();
    }

    public void UE_CreateCharacter()
    {
        CreateCharacter();
    }
}
