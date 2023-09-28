using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private ObjectPool<Projectile> projectilePool;
    private Action<WeaponFiredEvent> onWeaponFiredEventHandler;
    private Action<BulletDestroyedEvent> onBulletDestroyedEventHandler;

    private void Awake()
    {
        projectilePool = new ObjectPool<Projectile>();
        onWeaponFiredEventHandler = OnWeaponFired;
        onBulletDestroyedEventHandler = _event => projectilePool.ReturnObjectToPool(_event.DestroyedBullet);
    }

    private void Update()
    {
        if (projectilePool.TryGetActiveObjects(out Projectile[] projectiles))
        {
            foreach (Projectile p in projectiles)
            {
                p.Update(Time.deltaTime);
            }
        }
    }

    private void OnWeaponFired(WeaponFiredEvent _event)
    {
        Projectile projectile = projectilePool.RequestObject();
        projectile.Damage = _event.Damage;
    }

    private void OnEnable()
    {
        EventManager.Subscribe(typeof(WeaponFiredEvent), onWeaponFiredEventHandler);
        EventManager.Subscribe(typeof(BulletDestroyedEvent), onBulletDestroyedEventHandler);
    }


    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(WeaponFiredEvent), onWeaponFiredEventHandler);
        EventManager.Unsubscribe(typeof(BulletDestroyedEvent), onBulletDestroyedEventHandler);
    }
}