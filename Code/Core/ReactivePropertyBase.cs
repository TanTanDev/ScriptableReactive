using UnityEngine;
using UniRx;
public class ReactivePropertyBase<T> : ScriptableObject
{
    [SerializeField] protected T m_startValue;

    protected ReactiveProperty<T> m_property;

    public ReadOnlyReactiveProperty<T> Property {
        get { return m_property.ToReadOnlyReactiveProperty(); } }

    // Todo: evaluate potential problems, if it is possible to access the property before OnEnable is called
    private void OnEnable()
    {
        m_property = new ReactiveProperty<T>(m_startValue);
    }

    public void OnNext(T a_value)
    {
        m_property.Value = a_value;
    }

    public System.IDisposable Subscribe(System.Action<T> a_callback)
    {
        return m_property.Subscribe(a_callback);
    }
}
