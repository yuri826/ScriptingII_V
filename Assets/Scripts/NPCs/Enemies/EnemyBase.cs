using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable, IFreeze
    {
        [SerializeField] protected EnemyState enemyState;
        [SerializeField] protected EnemyHUD enemyHUD;
        [SerializeField] protected EnemyLoot enemyLoot;
        
        [Header("Ice")] 
        [SerializeField] protected GameObject iceCube;
        
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
            
            iceCube.SetActive(false);
            
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

        public IEnumerator ConstantDamage(int damage, float frequency)
        {
            while (true)
            {
                print("awawawa");
                OnDamage(damage);
                yield return new WaitForSeconds(frequency);
            }
        }

        public virtual void OnDamage(int damage)
        {
            if (enemyState.elementState == ElementState.Normal)
            {
                enemyState.ChangeHealth(-damage);
                enemyHUD.UpdateBarFill(enemyState.currentHealth, enemyState.maxHealth);
            }
            else if (enemyState.elementState == ElementState.Frozen)
            {
                StopAllCoroutines();
                OnEndFreeze();
                enemyState.ChangeHealth(-damage*3);
                enemyHUD.UpdateBarFill(enemyState.currentHealth, enemyState.maxHealth);
            }
        }

        public virtual void OnDie()
        {
            enemyLoot.DropLoot();
            Destroy(gameObject);
        }

        public virtual void OnFreeze()
        {
            iceCube.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(FreezeTime());
        }

        protected virtual void OnEndFreeze()
        {
            enemyState.elementState = ElementState.Normal;
            iceCube.SetActive(false);
        }

        private IEnumerator FreezeTime()
        {
            yield return null;
            enemyState.elementState = ElementState.Frozen;
            yield return new WaitForSeconds(10);
            OnEndFreeze();
        }
    }

}
