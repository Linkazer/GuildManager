using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UI_CharacterDetail : UI_Menu
{
    [Header("Linked menus")]
    [SerializeField] private UI_CharacterModifier characterModifier;
    [SerializeField] private UI_CharacterSelector characterSelector;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI nameHolder;
    [SerializeField] private TextMeshProUGUI jobHolder;
    [SerializeField] private TextMeshProUGUI raceHolder;
    [SerializeField] private TextMeshProUGUI levelHolder;
    [SerializeField] private TextMeshProUGUI strengthHolder;
    [SerializeField] private TextMeshProUGUI spiritHolder;
    [SerializeField] private TextMeshProUGUI presenceHolder;
    [SerializeField] private TextMeshProUGUI dexterityHolder;
    [SerializeField] private TextMeshProUGUI instinctHolder;
    [SerializeField] private TextMeshProUGUI currentHealthHolder;
    [SerializeField] private TextMeshProUGUI maxHealthHolder;
    [SerializeField] private TextMeshProUGUI dodgeHolder;
    [SerializeField] private TextMeshProUGUI willHolder;

    private int characterId;
    private CharacterDtoGetDetails loadedCharacter;

    public void SetCharacterId(int nCharacterId)
    {
        characterId = nCharacterId;
    }

    protected override void OnOpenMenu()
    {
        if(characterId > 0)
        {
            LoadCharacter();
        }
        else
        {
            CloseDetail();
        }
    }

    private async void LoadCharacter()
    {
        handler.DisplayLoading();

        loadedCharacter = await CharacterService.GetCharacterDetailsById(characterId);

        if (loadedCharacter != null)
        {
            DisplayDetails(loadedCharacter);
        }
        else
        {
            CloseDetail();
        }

        handler.HideLoading();
    }


    protected override void OnCloseMenu()
    {
        
    }

    private void DisplayDetails(CharacterDtoGetDetails characterData)
    {
        nameHolder.text = characterData.Name;

        JobData job = ReferenceDataService.JobData.GetDataById(characterData.JobId);
        if (job != null)
        {
            jobHolder.text = job.Name;
        }
        else
        {
            jobHolder.text = "No Job";
        }

        RaceData race = ReferenceDataService.RaceData.GetDataById(characterData.RaceId);
        if (race != null)
        {
            raceHolder.text = race.Name;
        }
        else
        {
            raceHolder.text = "No Race";
        }

        levelHolder.text = characterData.Level.ToString();
        strengthHolder.text = characterData.Strength.ToString();
        spiritHolder.text = characterData.Spirit.ToString();
        presenceHolder.text = characterData.Presence.ToString();
        dexterityHolder.text = characterData.Dexterity.ToString();
        instinctHolder.text = characterData.Instinct.ToString();
        currentHealthHolder.text = characterData.MaxHealth.ToString();
        maxHealthHolder.text = characterData.MaxHealth.ToString();
        dodgeHolder.text = characterData.Dodge.ToString();
        willHolder.text = characterData.Will.ToString();
    }

    private void CloseDetail()
    {
        characterId = -1;
        handler.OpenMenu(characterSelector);
    }

    private void OpenModifier()
    {
        characterModifier.SetExistingCharacterId(loadedCharacter.Id);
        handler.OpenMenu(characterModifier);
    }

    private async void TryDeleteCharacter()
    {
        handler.DisplayLoading();

        await CharacterService.DeleteCharacter(characterId);

        handler.HideLoading();

        CloseDetail();
    }

    public void UE_CloseDetail()
    {
        CloseDetail();
    }

    public void UE_OpenModifier()
    {
        OpenModifier();
    }

    public void UE_TryDeleteCharacter()
    {
        TryDeleteCharacter();
    }
}
