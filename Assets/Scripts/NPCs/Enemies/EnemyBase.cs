using System;
using System.Collections;
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
        
        private Coroutine damageRoutine;

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamageArea damageArea))
            {
                print("damageArea");
                damageRoutine = StartCoroutine(ConstantDamage(damageArea.damage, damageArea.frequency));
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out DamageArea damageArea))
            {
                print("damageAreaStop");
                StopCoroutine(damageRoutine);
            }
        }

        public IEnumerator ConstantDamage(float damage, float frequency)
        {
            while (true)
            {
                print("awawawa");
                OnDamage(damage);
                yield return new WaitForSeconds(frequency);
            }
        }

        public virtual void OnDamage(float damage)
        {
            print("damage");
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
