using UnityEngine;
using UniRx;
using System.Linq;
using System.Collections.Generic;

public class ReactiveCollectionBase<T> : ScriptableObject
{

    protected ReactiveCollection<T> m_property;

    public UniRx.IReadOnlyReactiveCollection<T> Property {
        get { return m_property; } }

    // Todo: evaluate potential problems, if it is possible to access the property before OnEnable is called
    private void OnEnable()
    {
        m_property = new ReactiveCollection<T>();
    }

    public void Add(T a_value)
    {
        m_property.Add(a_value);
    }

    public void Remove(T a_value)
    {
        m_property.Remove(a_value);
    }

    public List<T> GetGeneratedList()
    {
        List<T> list = new List<T>(m_property.Count);
        for(int i = 0; i < m_property.Count; i++)
        {
            list.Add(m_property[i]);
        }
        return list;
    }
}
