using System;
using UnityEngine;

public struct EventLeftMouseButtonClicked : IEvent
{
    public LayerMask PointerHitMask { get; }

    public EventLeftMouseButtonClicked(LayerMask _pointerHitMask)
    {
        PointerHitMask = _pointerHitMask;
    }

}
