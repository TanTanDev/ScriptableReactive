using UnityEngine;

public class MonoUpdaterVector3Position : MonoBehaviour
{
    [SerializeField] private ReactiveVector3 m_reactiveVector3;

    void Update()
    {
        if(m_reactiveVector3 != null)
            m_reactiveVector3.OnNext(transform.position);
    }
}
