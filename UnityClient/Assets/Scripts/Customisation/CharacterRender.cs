using UnityEngine;

/// <summary>
/// Manage the render of a Character.
/// </summary>
public class CharacterRender : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bodyHolder;
    [SerializeField] private SpriteRenderer equipmentHolder;
    [SerializeField] private SpriteRenderer hairHolder;

    private CharacterDtoGetResume data;

    public CharacterDtoGetResume Data => data;

    /// <summary>
    /// Set the render from the corresponding data.
    /// </summary>
    /// <param name="nData">The data of the Character to render.</param>
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
