using UnityEngine;

public struct WeaponSpawnedEvent
{
    public Transform SpawnedWeapon;

    public WeaponSpawnedEvent(Transform _spawnedWeapon)
    {
        SpawnedWeapon = _spawnedWeapon;
    }
}