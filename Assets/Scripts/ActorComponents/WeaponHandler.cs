using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler
{
    private IWeapon currentWeapon;
    private Action<WeaponPickedUpEvent> onWeaponPickedUpEventHandler;
    private Action<WeaponOutOfAmmoEvent> onWeaponOutOfAmmoEventHandler;
    private Queue<IWeapon> weaponQueue = new Queue<IWeapon>();

    public WeaponHandler()
    {
        onWeaponPickedUpEventHandler = OnWeaponPickedUp;
        onWeaponOutOfAmmoEventHandler = OnWeaponOutOfAmmo;
        
        EventManager.Subscribe(typeof(WeaponPickedUpEvent), onWeaponPickedUpEventHandler);
        EventManager.Subscribe(typeof(WeaponOutOfAmmoEvent), onWeaponOutOfAmmoEventHandler);
    }
    
    public void Update(float _delta)
    {
        if (currentWeapon == null)
        {
            TryGetNewWeapon();
        }
        currentWeapon?.Fire(_delta);
    }

    private void TryGetNewWeapon()
    {
        if (weaponQueue.TryDequeue(out IWeapon newWeapon))
        {
            currentWeapon = newWeapon;
        }
        else
        {
            EventManager.Invoke(new OutOfWeaponsEvent());
        }
    }

    private void OnWeaponOutOfAmmo(WeaponOutOfAmmoEvent _event)
    {
        TryGetNewWeapon();
    }
    
    private void OnWeaponPickedUp(WeaponPickedUpEvent _event)
    {
        weaponQueue.Enqueue( new Weapon(_event.PickedUpWeaponData) );
    }

    ~WeaponHandler()
    {
        EventManager.Unsubscribe(typeof(WeaponPickedUpEvent), onWeaponPickedUpEventHandler);
        EventManager.Unsubscribe(typeof(WeaponOutOfAmmoEvent), onWeaponOutOfAmmoEventHandler);
    }
}
