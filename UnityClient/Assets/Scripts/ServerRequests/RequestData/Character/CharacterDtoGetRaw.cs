using System;

/// <summary>
/// Character's DTO for GET operation.
/// Contains all the raw data of a Character (before adding race's stats, job's stat, ...).
/// </summary>
[Serializable]
public class CharacterDtoGetRaw
{
    public int Id;
    public string Name;
    public int RaceId;
    public int JobId;
    public int Level;

    //Stats
    public int Strength;
    public int Spirit;
    public int Presence;
    public int Dexterity;
    public int Instinct;

    //Personnalisation
    public int BodyId;
    public int HairId;
    public int HairColorId;
    public int EquipmentId;
}
