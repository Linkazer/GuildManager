using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bodyHolder;
    [SerializeField] private SpriteRenderer equipmentHolder;
    [SerializeField] private SpriteRenderer hairHolder;

    private CharacterDtoGetResume data;

    public CharacterDtoGetResume Data => data;

    public void SetCharacter(CharacterDtoGetResume nData)
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
        bodyHolder.sprite = CustomisationManager.Instance.GetBody(raceId, bodyId);
    }

    private void SetEquipment(int equipmentId, int bodyId)
    {
        equipmentHolder.sprite = CustomisationManager.Instance.GetEquipment(equipmentId, bodyId);
    }

    private void SetHair(int hairId, int hairColorId)
    {
        hairHolder.sprite = CustomisationManager.Instance.GetHair(hairId, hairColorId);
    }

}
