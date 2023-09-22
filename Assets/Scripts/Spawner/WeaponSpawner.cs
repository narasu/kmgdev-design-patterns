using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeaponSpawner : MonoBehaviour
{
    public List<WeaponData> weaponTypes;
    private float spawnRate = 9.0f;
    private float currentTime = .0f;
    
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnRate)
        {
            SpawnWeapon();
            currentTime = .0f;
        }
    }

    private void SpawnWeapon()
    {
        GameObject weapon = new GameObject();
        Collider c = weapon.AddComponent<BoxCollider>();
        c.isTrigger = true;
    }
}
