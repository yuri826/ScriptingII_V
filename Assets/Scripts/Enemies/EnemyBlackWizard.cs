using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace Enemy
{
    public class EnemyBlackWizard : EnemyBase
    {
        private Transform playerTransform;

        [Header("Attack")] 
        [SerializeField] private GameObject bullet;
        [SerializeField] private int bulletDamage;
        [SerializeField] private float areaShootTime;

        private void Start()
        {
            playerTransform = GamemodeBase.Instance.GetPlayer().transform;

            StartCoroutine(AreaShoot());
        }

        private IEnumerator AreaShoot()
        {
            Vector3 shootDir = Vector3.forward;
            float timeBetweenBullets = 0.3f;

            while (true)
            {
                print("In");
                
                for (int i = 0; i < 8; i++)
                {
                    Shoot(shootDir);
                    yield return new WaitForSeconds(timeBetweenBullets);
                
                    shootDir = Quaternion.AngleAxis(45, Vector3.up) * shootDir;
                }

                print("Out");
                yield return new WaitForSeconds(areaShootTime);
                
                if (Vector3.Distance(this.transform.position, playerTransform.position) < 15)
                {
                    navMeshAgent.SetDestination(playerTransform.position);
                }
            }
        }

        public override void OnFreeze()
        {
            //Dont freeze
            //base.OnFreeze();
        }
        
        public override void OnDie()
        {
            base.OnDie();
            GamemodeBase.Instance.onWin?.Invoke();
        }

        public void Shoot(Vector3 direction)
        {
            print("Shoot");
            Projectile projectile = Instantiate(bullet,transform.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.Init(direction, bulletDamage);
        }
    }
}
