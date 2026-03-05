using System;

/// <summary>
/// Character's DTO for GET operation.
/// Contains only the data needed to identify and display the character.
/// </summary>
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
