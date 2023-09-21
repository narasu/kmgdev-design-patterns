using System;
using UnityEngine;
public class Player : ActorBase
{
    [SerializeField] private LayerMask interactHitMask;
        
    private void Awake()
    {
    }

    private void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseButtonClickedEvent clickLeftMouseButtonClickedEvent = new LeftMouseButtonClickedEvent(interactHitMask);
            if (EventManager.InvokeCallback(clickLeftMouseButtonClickedEvent, out object callback))
            {
                RaycastHit hit = (RaycastHit)callback;
                
                //hit.transform.GetComponent<IDamageable>()?.TakeDamage(1.0f);
            }
        }
    }

    protected override void Move()
    {
        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), .0f, Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(inputVector * (MovementSpeed * Time.deltaTime));
    }

    protected override void Attack()
    {
        
        
    }
}
