using UnityEngine;

public struct WeaponPickedUpEvent
{
    public WeaponData PickedUpWeaponData { get; }
    public Transform PickupTransform { get; } 

    public WeaponPickedUpEvent(WeaponData _pickedUpWeaponData, Transform _pickupTransform)
    {
        PickedUpWeaponData = _pickedUpWeaponData;
        PickupTransform = _pickupTransform;
    }
}
