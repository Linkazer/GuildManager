public class JobData : ReferenceData
{
    public string Name { get; set; } = string.Empty;

    public JobData(int nId, string nName) : base(nId)
    {
        Name = nName;
    }
}
