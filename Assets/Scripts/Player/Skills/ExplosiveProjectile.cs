using Interfaces;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [Header("Collision")] 
    [SerializeField] private LayerMask hitMask;
    private Collider[] hitCols = new Collider[10];
    
    protected override void DestroyBullet()
    {
        int _radius = 2;
        Physics.OverlapSphereNonAlloc(this.transform.position, _radius, hitCols, hitMask);

        foreach (var c in hitCols)
        {
            if (c is null) continue;
            if (c.TryGetComponent(out IDamageable damageable))
            {
                damageable.OnDamage(damage);
            }
        }
        
        Destroy(gameObject);
    }
}
