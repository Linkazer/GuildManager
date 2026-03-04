using GuildManager;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UI_CharacterModifier : UI_Menu
{
    [Header("Linked menus")]
    [SerializeField] private UI_CharacterSelector characterSelector;

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

    private CharacterData existingCharacter = null;
    [SerializeField] private CharacterData modifiedCharacter;

    public void SetExistingCharacter(CharacterData nExistingCharacter)
    {
        existingCharacter = nExistingCharacter;
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

        //Equiment limits

        modifiedCharacter = new CharacterData();

        if (existingCharacter != null)
        {
            SetValues(existingCharacter);
        }
        else
        {
            ResetValues();
        }
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

    private void SetValues(CharacterData dataToUse)
    {
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

        //raceDropdown.value = dataToUse.RaceId - 1;
        //jobDropdown.value = dataToUse.JobId - 1;
    }

    protected override void OnCloseMenu()
    {
        modifiedCharacter = new CharacterData();
        existingCharacter = null;
    }

    public async void TryValidateCharacter()
    {
        handler.DisplayLoading();

        if (existingCharacter != null)
        {
            await CharacterService.PutCharacter(existingCharacter.Id, modifiedCharacter);
        }
        else
        {
            await CharacterService.PostCharacter(modifiedCharacter);
        }

        handler.HideLoading();

        CloseModifier();
    }


    private void CloseModifier()
    {
        existingCharacter = null;
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
