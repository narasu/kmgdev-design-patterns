using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private WeaponPickup PickupPrefab;
    [SerializeField] private List<WeaponData> weaponTypes;
    private float spawnRate = 2.0f;
    private Timer spawnTimer;

    private void Awake()
    {
        spawnTimer = new Timer(spawnRate);
    }

    void Update()
    {
        spawnTimer.Run(Time.deltaTime, out bool isTimerExpired);
        if (isTimerExpired)
        {
            SpawnWeapon();
        }
    }

    private void SpawnWeapon()
    {
        WeaponPickup pickup = Instantiate(PickupPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
        pickup.Create(Util.Pick(weaponTypes));
        EventManager.Invoke(new WeaponSpawnedEvent(pickup.transform));
    }
}
