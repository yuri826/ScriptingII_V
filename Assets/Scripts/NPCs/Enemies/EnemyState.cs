using System;
using FMODUnity;
using UnityEngine;

namespace Enemy
{
    public enum ElementState
    {
        Normal,
        Frozen
    }
    
    [Serializable]
    public class EnemyState : EnemySubsystem
    {
        [field: SerializeField] public int maxHealth { get; set; }
        public float currentHealth { get; private set; }
        protected internal ElementState elementState = ElementState.Normal;
        [SerializeField] private EventReference sfxDie;

        public override void OnAwake()
        {
            currentHealth = maxHealth;
        }

        public void ChangeHealth(float amount)
        {
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            
            if (currentHealth <= 0)
            {
                AudioManager.Instance.PlaySFX(sfxDie);
                enemyParent.OnDie();
            }
        }
    }
}

