public struct BulletDestroyedEvent
{
    public Projectile DestroyedBullet { get; }

    public BulletDestroyedEvent(Projectile _destroyedBullet)
    {
        DestroyedBullet = _destroyedBullet;
    }
}