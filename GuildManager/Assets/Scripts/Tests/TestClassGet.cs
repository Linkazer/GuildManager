using System;
using UnityEngine;

[Serializable]
public class TestClassGet
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

    //Calculated
    public int MaxHealth;
    public int Dodge;
    public int Will;

    public void Print()
    {
        //Debug.Log(Name + ", " + Level);
        //Debug.Log(Strength + " / " + Spirit + " / " + Presence + " / " + Dexterity + " / " + Instinct);
        //Debug.Log(MaxHealth + " / " + Dodge + " / " + Will);
    }
}
