using System;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float damage { get; private set; }
    public float frequency { get; private set; }
    
    public void Init(float damage, float timeToVanish, float frequency)
    {
        this.damage = damage;
        this.frequency = frequency;
        
        Destroy(gameObject, timeToVanish);
    }
}
