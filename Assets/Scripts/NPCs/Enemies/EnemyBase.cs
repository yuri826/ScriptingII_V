using System;
using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyState enemyState;
        [SerializeField] private EnemyHUD enemyHUD;
        [SerializeField] private EnemyLoot enemyLoot;

        private void Awake()
        {
            enemyState.enemyParent = this;
            enemyHUD.enemyParent = this;
            enemyLoot.enemyParent = this;
            
            enemyState.OnAwake();
            enemyHUD.OnAwake();
            enemyLoot.OnAwake();
        }

        public void OnDamage(float damage)
        {
            enemyState.ChangeHealth(-damage);
            enemyHUD.UpdateBarFill(enemyState.currentHealth, enemyState.maxHealth);
        }

        public void OnDie()
        {
            enemyLoot.DropLoot();
            Destroy(gameObject);
        }
    }

}
