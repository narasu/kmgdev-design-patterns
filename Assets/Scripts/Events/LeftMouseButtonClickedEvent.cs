using UnityEngine;

public struct LeftMouseButtonClickedEvent
{
    public LayerMask PointerHitMask { get; }
    
    public LeftMouseButtonClickedEvent(LayerMask _pointerHitMask)
    {
        PointerHitMask = _pointerHitMask;
    }

}
