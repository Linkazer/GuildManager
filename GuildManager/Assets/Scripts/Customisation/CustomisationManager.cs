using UnityEngine;

public class CustomisationManager : MonoBehaviour
{
    private static CustomisationManager instance;

    public static CustomisationManager Instance => instance;

    [SerializeField] private CharacterCustomBody[] raceBodies;
    [SerializeField] private CharacterCustomEquipment[] equipments;
    [SerializeField] private CharacterCustomHair[] hairs;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject GetBody(int raceId, int bodyId)
    {
        if(raceId-1 < raceBodies.Length)
        {
            return raceBodies[raceId-1].GetBody(bodyId-1);
        }

        return null;
    }

    public GameObject GetEquipment(int equipmentId, int bodyId)
    {
        if (equipmentId-1 < equipments.Length)
        {
            return equipments[equipmentId-1].GetBody(bodyId-1);
        }

        return null;
    }

    public GameObject GetHair(int hairId, int hairColorId)
    {
        if (hairId-1 < hairs.Length)
        {
            return hairs[hairId-1].GetHair(hairColorId-1);
        }

        return null;
    }
}
