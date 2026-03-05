using System.Collections.Generic;

/// <summary>
/// Manage data of a ReferenceData's type.
/// </summary>
/// <typeparam name="T">The type of ReferenceData to manage.</typeparam>
public class ReferenceDataHandler<T> where T : ReferenceData
{
    private Dictionary<int, T> data = new Dictionary<int, T>();

    /// <summary>
    /// Add new data for the handle to manage. 
    /// </summary>
    /// <param name="nData">The list of new data to add.</param>
    public void AddData(List<T> nData)
    {
        foreach(T d in nData)
        {
            data.Add(d.Id, d);
        }
    }

    /// <summary>
    /// Clear all data.
    /// </summary>
    public void ClearData()
    {
        data.Clear();
    }

    /// <summary>
    /// Get all data contained in the handler.
    /// </summary>
    /// <returns></returns>
    public List<T> GetAll()
    {
        List<T> toReturn = new List<T>();

        foreach (KeyValuePair<int, T> d in data)
        {
            toReturn.Add(d.Value);
        }

        return toReturn;
    }

    /// <summary>
    /// Get a specific data in the handler.
    /// </summary>
    /// <param name="id">The Id of the data to retrieve.</param>
    /// <returns>The data if found. If no data was found, return NULL.</returns>
    public T GetDataById(int id)
    {
        if(data.TryGetValue(id, out T foundData))
        {
            return foundData;
        }

        return null;
    }
}
