public struct WeaponSpawnedEvent
{
    public IPickup SpawnedWeapon { get; }
    
    public WeaponSpawnedEvent(IPickup _spawnedWeapon)
    {
        SpawnedWeapon = _spawnedWeapon;
    }
}
