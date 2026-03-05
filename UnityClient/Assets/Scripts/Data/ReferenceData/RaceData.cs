/// <summary>
/// Contains the data of a Race.
/// </summary>
public class RaceData : ReferenceData
{
    public string Name { get; private set; } = string.Empty;


    public RaceData(int nId, string nName) : base(nId)
    {
        Name = nName;
    }
}
