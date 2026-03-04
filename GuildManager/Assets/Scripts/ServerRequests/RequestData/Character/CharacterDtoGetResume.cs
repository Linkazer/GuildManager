using System;

[Serializable]
public class CharacterDtoGetResume
{
    public int Id;
    public string Name;
    public int RaceId;
    public int JobId;

    //Personnalisation
    public int BodyId;
    public int HairId;
    public int HairColorId;
    public int EquipmentId;
}
