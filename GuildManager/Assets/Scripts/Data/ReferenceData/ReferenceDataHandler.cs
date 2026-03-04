using NUnit.Framework;
using System.Collections.Generic;

public class ReferenceDataHandler<T> where T : ReferenceData
{
    private Dictionary<int, T> data = new Dictionary<int, T>();

    public void SetData(List<T> nData)
    {
        foreach(T d in nData)
        {
            data.Add(d.Id, d);
        }
    }

    public List<T> GetAll()
    {
        List<T> toReturn = new List<T>();

        foreach (KeyValuePair<int, T> d in data)
        {
            toReturn.Add(d.Value);
        }

        return toReturn;
    }

    public T GetDataById(int id)
    {
        if(data.TryGetValue(id, out T foundData))
        {
            return foundData;
        }

        return null;
    }
}
