using GuildManager;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_CharacterModifier : UI_Menu
{
    [Header("Linked menus")]
    [SerializeField] private UI_CharacterSelector characterSelector;

    [Header("Previsualisation")]
    [SerializeField] private CharacterDisplay previsualiser;

    [Header("UI Elements")]
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

    private int existingCharacterId = -1;
    [SerializeField] private CharacterData modifiedCharacter;

    public void SetExistingCharacterId(int nId)
    {
        existingCharacterId = nId;
    }

    protected override void OnOpenMenu()
    {
        //Race dropdown
        raceDropdown.ClearOptions();
        List<RaceData> races = ReferenceDataService.RaceData.GetAll();
        raceDropdown.AddOptions(races.Select(r => r.Name).ToList());

        //Job dropdown
        jobDropdown.ClearOptions();
        List<JobData> jobs = ReferenceDataService.JobData.GetAll();
        jobDropdown.AddOptions(jobs.Select(j => j.Name).ToList());

        LoadMenu();
    }

    private async void LoadMenu()
    {
        modifiedCharacter = new CharacterData();

        CharacterDtoGetBase existingCharacter = null;

        if (existingCharacterId > 0)
        {
            existingCharacter = await CharacterService.GetCharacterBaseById(existingCharacterId);
        }

        if (existingCharacter != null)
        {
            modifiedCharacter = existingCharacter.ToData();
            SetValues(existingCharacter);
        }
        else
        {
            ResetValues();
        }

        OnCustomisationChanged();
    }

    private void ResetValues()
    {
        levelModifier.ResetValue();
        strengthModifier.ResetValue();
        spiritModifier.ResetValue();
        presenceModifier.ResetValue();
        dexterityModifier.ResetValue();
        instinctModifier.ResetValue();

        equipmentModifier.ResetValue();
        bodyModifier.ResetValue();
        hairstyleModifier.ResetValue();
        hairColorModifier.ResetValue();

        //raceDropdown.value = 0;
        //jobDropdown.value = 0;
    }

    private void SetValues(CharacterDtoGetBase dataToUse)
    {
        nameField.text = dataToUse.Name;

        levelModifier.SetValue(dataToUse.Level);
        strengthModifier.SetValue(dataToUse.Strength);
        spiritModifier.SetValue(dataToUse.Spirit);
        presenceModifier.SetValue(dataToUse.Presence);
        dexterityModifier.SetValue(dataToUse.Dexterity);
        instinctModifier.SetValue(dataToUse.Instinct);

        equipmentModifier.SetValue(dataToUse.EquipmentId);
        bodyModifier.SetValue(dataToUse.BodyId);
        hairstyleModifier.SetValue(dataToUse.HairId);
        hairColorModifier.SetValue(dataToUse.HairColorId);

        raceDropdown.value = dataToUse.RaceId - 1;
        jobDropdown.value = dataToUse.JobId - 1;
    }

    protected override void OnCloseMenu()
    {
        modifiedCharacter = new CharacterData();
        existingCharacterId = -1;
    }

    public async void TryValidateCharacter()
    {
        handler.DisplayLoading();

        if (existingCharacterId > 0)
        {
            await CharacterService.PutCharacter(existingCharacterId, modifiedCharacter);
        }
        else
        {
            await CharacterService.PostCharacter(modifiedCharacter);
        }

        handler.HideLoading();

        CloseModifier();
    }

    private void OnCustomisationChanged()
    {
        previsualiser.SetCharacter(modifiedCharacter.ToResume());
    }

    private void CloseModifier()
    {
        existingCharacterId = -1;
        handler.OpenMenu(characterSelector);
    }

    public void UE_CloseModifier()
    {
        CloseModifier();
    }

    public void UE_TryValidateCharacter()
    {
        TryValidateCharacter();
    }

    #region Unity Events
    public void UE_UpdateName(string value)
    {
        modifiedCharacter.Name = value;
    }

    public void UE_UpdateRace(int value)
    {
        modifiedCharacter.RaceId = value+1;
        OnCustomisationChanged();
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
        OnCustomisationChanged();
    }

    public void UE_UpdateBody(int value)
    {
        modifiedCharacter.BodyId = value;
        OnCustomisationChanged();
    }

    public void UE_UpdateHairstyle(int value)
    {
        modifiedCharacter.HairId = value;
        OnCustomisationChanged();
    }

    public void UE_UpdateHairColor(int value)
    {
        modifiedCharacter.HairColorId = value;
        OnCustomisationChanged();
    }
    #endregion
}
