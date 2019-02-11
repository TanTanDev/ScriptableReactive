using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactiveEventBase<T> : ScriptableObject
{
    protected readonly ReactiveCommand<T> m_command = new ReactiveCommand<T>();

    public void OnNext(T a_value)
    {
        m_command.Execute(a_value);
    }

    public System.IDisposable Subscribe(System.Action<T> a_callback)
    {
        return m_command.Subscribe(a_callback);
    }
}