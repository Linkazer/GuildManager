/// <summary>
/// Base class for server's data that only need to be loaded at the start of the application.
/// </summary>
public class ReferenceData
{
    public int Id { get; private set; }

    public ReferenceData(int nId)
    {
        Id = nId;
    }
}
