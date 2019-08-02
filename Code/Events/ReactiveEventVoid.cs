using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactive/Events/Void", fileName = "R_E_{name}_void")]
public class ReactiveEventVoid : ReactiveEventBase<VoidData>
{
    private VoidData m_voidData = new VoidData();
    public void OnNext()
    {
        base.OnNext(m_voidData);
    }
}
