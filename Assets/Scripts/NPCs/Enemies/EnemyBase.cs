using System;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        [SerializeField] protected EnemyState enemyState;
        [SerializeField] protected EnemyHUD enemyHUD;
        [SerializeField] protected EnemyLoot enemyLoot;
        
        protected NavMeshAgent navMeshAgent;

        protected virtual void Awake()
        {
            enemyState.enemyParent = this;
            enemyHUD.enemyParent = this;
            enemyLoot.enemyParent = this;
            
            enemyState.OnAwake();
            enemyHUD.OnAwake();
            enemyLoot.OnAwake();
            
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public virtual void OnDamage(float damage)
        {
            enemyState.ChangeHealth(-damage);
            enemyHUD.UpdateBarFill(enemyState.currentHealth, enemyState.maxHealth);
        }

        public virtual void OnDie()
        {
            enemyLoot.DropLoot();
            Destroy(gameObject);
        }
    }

}
