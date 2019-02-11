using UnityEngine;

public class ConstPropertyBase<T> : ScriptableObject
{
    [SerializeField] private T m_value;
    public T Value {
        get { return m_value; } }
}
