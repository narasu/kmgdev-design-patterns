using System;
using UnityEngine;


public class ScreenToWorldspacePointer : MonoBehaviour
{
    private Camera mainCamera;
    private Func<EventLeftMouseButtonClicked, object> onClickEventHandler;

    private void Awake()
    {
        mainCamera = Camera.main;
        onClickEventHandler = QueryPointerHit;
    }

    private void OnEnable()
    {
        EventManager.Subscribe(typeof(EventLeftMouseButtonClicked), onClickEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(EventLeftMouseButtonClicked), onClickEventHandler);
    }

    private object QueryPointerHit(EventLeftMouseButtonClicked _event)
    {
        Ray cameraPointRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraPointRay, out RaycastHit pointerHit, 99.0f, _event.PointerHitMask))
        {
            return pointerHit;
        }

        return null;
    }
}
