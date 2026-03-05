/// <summary>
/// Contains the data of an Equipment.
/// </summary>
public class EquipmentData : ReferenceData
{
    public string Name { get; set; } = string.Empty;

    public EquipmentData(int nId, string nName) : base(nId)
    {
        Name = nName;
    }
}
