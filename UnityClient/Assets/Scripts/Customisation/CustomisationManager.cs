using UnityEngine;

/// <summary>
/// Contains and manage all the Character's customisation data.
/// </summary>
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

    /// <summary>
    /// Get the Race's body corresponding to the id.
    /// </summary>
    /// <param name="raceId">The Id of the Character's race.</param>
    /// <param name="bodyId">The Id of the body.</param>
    /// <returns></returns>
    public Sprite GetBody(int raceId, int bodyId)
    {
        if(raceId-1 < raceBodies.Length)
        {
            return raceBodies[raceId-1].GetBody(bodyId-1);
        }

        return null;
    }

    /// <summary>
    /// Get the Equipment corresponding to the body Id.
    /// </summary>
    /// <param name="equipmentId">The Id of the Equipment wanted.</param>
    /// <param name="bodyId">The id of the Character's body.</param>
    /// <returns></returns>
    public Sprite GetEquipment(int equipmentId, int bodyId)
    {
        if (equipmentId-1 < equipments.Length)
        {
            return equipments[equipmentId-1].GetBody(bodyId-1);
        }

        return null;
    }

    /// <summary>
    /// Get the Hair corresponding to the Id and its color.
    /// </summary>
    /// <param name="hairId">The Id of the hairstyle.</param>
    /// <param name="hairColorId">The Id of the color wanted for that hairstyle.</param>
    /// <returns></returns>
    public Sprite GetHair(int hairId, int hairColorId)
    {
        if (hairId-1 < hairs.Length)
        {
            return hairs[hairId-1].GetHair(hairColorId-1);
        }

        return null;
    }
}
