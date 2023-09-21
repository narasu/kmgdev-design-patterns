using System;
using UnityEngine;


public class ScreenToWorldspacePointer : MonoBehaviour
{
    private Camera mainCamera;
    private Func<LeftMouseButtonClickedEvent, object> onClickEventHandler;

    private void Awake()
    {
        mainCamera = Camera.main;
        onClickEventHandler = QueryPointerHit;
    }

    private void OnEnable()
    {
        EventManager.Subscribe(typeof(LeftMouseButtonClickedEvent), onClickEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(LeftMouseButtonClickedEvent), onClickEventHandler);
    }

    private object QueryPointerHit(LeftMouseButtonClickedEvent _event)
    {
        Ray cameraPointRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraPointRay, out RaycastHit pointerHit, 99.0f, _event.PointerHitMask))
        {
            return pointerHit;
        }

        return null;
    }
}
