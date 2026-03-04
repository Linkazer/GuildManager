using System;

[Serializable]
public class CharacterDtoGetBase
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
