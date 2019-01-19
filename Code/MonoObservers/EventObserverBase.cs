using UnityEngine;
using UnityEngine.Events;

public class EventObserverBase<TReactiveBase, TData, TEvent> : MonoBehaviour 
    where TEvent: UnityEvent<TData>
    where TReactiveBase: ReactiveEventBase<TData>
{
    [SerializeField] protected TReactiveBase m_event;
    [SerializeField] protected TEvent m_onNext;

    System.IDisposable m_disposable = null;
    private void OnEnable()
    {
        m_disposable = m_event.Subscribe(OnNext);
    }

    private void OnDisable()
    {
        m_disposable.Dispose();
    }

    private void OnNext(TData a_data)
    {
        m_onNext.Invoke(a_data);
    }
}
