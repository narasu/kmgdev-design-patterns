using UnityEngine;

public class Projectile : IPoolable
{
    public bool IsActive { get; set; }
    public float Damage { get; set; }
    
    private Timer timeUntilHit;

    public Projectile()
    {
        timeUntilHit = new Timer(0.8f);
    }

    public void Update(float _delta)
    {
        timeUntilHit.Run(Time.deltaTime, out bool hasHit);
        if (hasHit) { Hit(); }
    }

    private void Hit()
    {
        //target.TakeDamage(Damage);
        Debug.Log("hit!");

        EventManager.Invoke(new BulletDestroyedEvent(this));
    }

    public void OnEnableObject() { }

    public void OnDisableObject() { }
}