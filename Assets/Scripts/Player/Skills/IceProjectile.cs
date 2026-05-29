using Interfaces;
using UnityEngine;

public class IceProjectile : Projectile
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IFreeze freeze))
        {
            freeze.OnFreeze();
            DestroyBullet();
        }
        
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.OnDamage(damage);
            DestroyBullet();
        }
    }
}
