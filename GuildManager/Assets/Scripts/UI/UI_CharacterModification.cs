using GuildManager;
using TMPro;
using UnityEngine;

public class UI_CharacterModification : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_Dropdown raceDropdown;
    [SerializeField] private TMP_Dropdown jobDropdown;

    [SerializeField] private UI_IntegerModifier levelModifier;
    [SerializeField] private UI_IntegerModifier strengthModifier;
    [SerializeField] private UI_IntegerModifier spiritModifier;
    [SerializeField] private UI_IntegerModifier presenceModifier;
    [SerializeField] private UI_IntegerModifier dexterityModifier;
    [SerializeField] private UI_IntegerModifier instinctModifier;

    [SerializeField] private UI_IntegerModifier equipmentModifier;
    [SerializeField] private UI_IntegerModifier bodyModifier;
    [SerializeField] private UI_IntegerModifier hairstyleModifier;
    [SerializeField] private UI_IntegerModifier hairColorModifier;

    [Header("UI")]
    [SerializeField] private CanvasGroup loadingGroup;

    private CharacterData currentCharacter = null;
    private CharacterData modifiedCharacter;

    private void Start()
    {
        OpenMenu();
    }

    [ContextMenu("Open Menu")]
    public void OpenMenu()
    {
        modifiedCharacter = new CharacterData();
    }

    public async void TryValidateCharacter()
    {
        loadingGroup.alpha = 1.0f;
        loadingGroup.blocksRaycasts = true;

        if (currentCharacter != null)
        {
            await HttpRequests.Put<TestClassGet>($"http://localhost:5181/api/Character/{currentCharacter.Id}", modifiedCharacter.ToPut());
        }
        else
        {
            await HttpRequests.Post<TestClassGet>($"http://localhost:5181/api/Character", modifiedCharacter.ToPost());
        }

        loadingGroup.alpha = 0.0f;
        loadingGroup.blocksRaycasts = false;
    }

    #region Unity Events
    public void UE_UpdateName(string value)
    {
        modifiedCharacter.Name = value;
    }

    public void UE_UpdateRace(int value)
    {
        modifiedCharacter.RaceId = value+1;
    }

    public void UE_UpdateJob(int value)
    {
        modifiedCharacter.JobId = value+1;
    }

    public void UE_UpdateLevel(int value)
    {
        modifiedCharacter.Level = value;
    }

    public void UE_UpdateStrength(int value)
    {
        modifiedCharacter.Strength = value;
    }

    public void UE_UpdateSpirit(int value)
    { 
        modifiedCharacter.Spirit = value;
    }

    public void UE_UpdatePresence(int value)
    {
        modifiedCharacter.Presence = value;
    }

    public void UE_UpdateDexterity(int value)
    {
        modifiedCharacter.Dexterity = value;
    }

    public void UE_UpdateInstinct(int value)
    {
        modifiedCharacter.Instinct = value;
    }

    public void UE_UpdateEquipment(int value)
    {
        modifiedCharacter.EquipmentId = value;
    }

    public void UE_UpdateBody(int value)
    {
        modifiedCharacter.BodyId = value;
    }

    public void UE_UpdateHairstyle(int value)
    {
        modifiedCharacter.HairId = value;
    }

    public void UE_UpdateHairColor(int value)
    {
        modifiedCharacter.HairColorId = value;
    }
    #endregion
}
