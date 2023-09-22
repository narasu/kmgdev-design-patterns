using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public List<WeaponData> weaponTypes;
    private float spawnRate = 9.0f;
    private float currentTime = .0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
