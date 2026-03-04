using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private Transform bodyHolder;
    [SerializeField] private Transform equipmentHolder;
    [SerializeField] private Transform hairHolder;

    [SerializeField] private GameObject currentBody;
    [SerializeField] private GameObject currentEquipment;
    [SerializeField] private GameObject currentHair;

    private CharacterData data;

    public CharacterData Data => data;

    public void SetCharacter(CharacterData nData)
    {
        if(nData == null)
        {
            Destroy(gameObject);
            return;
        }

        data = nData;

        SetBody(data.RaceId, data.BodyId);
        SetEquipment(data.EquipmentId, data.BodyId);
        SetHair(data.HairId, data.HairColorId);
    }

    private void SetBody(int raceId, int bodyId)
    {
        if (currentBody != null)
        {
            Destroy(currentBody);
        }

        currentBody = Instantiate(CustomisationManager.Instance.GetBody(raceId, bodyId), bodyHolder);
    }

    private void SetEquipment(int equipmentId, int bodyId)
    {
        if (currentEquipment != null)
        {
            Destroy(currentEquipment);
        }

        currentEquipment = Instantiate(CustomisationManager.Instance.GetEquipment(equipmentId, bodyId), equipmentHolder);
    }

    private void SetHair(int hairId, int hairColorId)
    {
        if(currentHair != null)
        {
            Destroy(currentHair);
        }

        currentHair = Instantiate(CustomisationManager.Instance.GetHair(hairId, hairColorId), hairHolder);
    }

}
