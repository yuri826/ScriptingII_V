using System;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;
    protected int damage;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 direction, int damage)
    {
        transform.parent = null;
        rb.linearVelocity = direction.normalized * speed;
        this.damage = damage;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.OnDamage(damage);
            DestroyBullet();
        }
    }

    protected virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
