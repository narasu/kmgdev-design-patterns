using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IWeapon
{
    public int Ammo { get; private set; }
    public float Damage { get; }
    private float fireRate;

    private Timer fireRateTimer;

    public Weapon(WeaponData _weaponData)
    {
        Ammo = _weaponData.Ammo;
        Damage = _weaponData.Damage;
        fireRate = _weaponData.FireRate;
        fireRateTimer = new Timer(1 / fireRate);
    }

    public void Fire(float _delta)
    {
        fireRateTimer.Run(_delta, out bool isTimerExpired);
        if (isTimerExpired)
        {
            Ammo -= 1;
            EventManager.Invoke(new WeaponFiredEvent(Damage));

            if (Ammo <= 0)
            {
                EventManager.Invoke(new WeaponOutOfAmmoEvent());
            }
        }
    }
}