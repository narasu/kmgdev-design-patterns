public struct WeaponPickedUpEvent
{
    public IWeapon Weapon { get; }

    public WeaponPickedUpEvent(IWeapon _weapon)
    {
        Weapon = _weapon;
    }
}
