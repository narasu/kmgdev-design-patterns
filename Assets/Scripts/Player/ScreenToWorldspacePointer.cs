using System;
using UnityEngine;

/// <summary>
/// This class casts a ray from the camera to the worldspace on an event call, and returns a RaycastHit
/// </summary>

public class ScreenToWorldspacePointer : MonoBehaviour
{
    private Camera mainCamera;
    private Func<MousePointerQueryEvent, object> onClickEventHandler;

    private void Awake()
    {
        mainCamera = Camera.main;
        onClickEventHandler = QueryPointerHit;
    }

    private void OnEnable()
    {
        EventManager.Subscribe(typeof(MousePointerQueryEvent), onClickEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(MousePointerQueryEvent), onClickEventHandler);
    }

    private object QueryPointerHit(MousePointerQueryEvent _event)
    {
        Ray cameraPointRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraPointRay, out RaycastHit pointerHit, 99.0f, _event.PointerHitMask))
        {
            return pointerHit;
        }

        return null;
    }
}
