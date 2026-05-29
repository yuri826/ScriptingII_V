using System;
using System.Collections;
using Enemy;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;

enum EnemyState
{
    Idle,
    Approach,
    Attack
}

public class EnemyMelee : EnemyBase
{
    [Header("Attack")] 
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private float attackRadius = 1f;
    private Collider[] hitColliders = new Collider[3];
    
    [Header("Navigation")]
    [SerializeField] private int initAggroRadius;
    [SerializeField] private int aggroRadius;
    private Coroutine searchPlayerRoutine;

    private EnemyState state = EnemyState.Idle;
    private GameObject player;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        player = GamemodeBase.Instance.GetPlayer().gameObject;
    }

    private void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:

                if ((Vector3.Distance(this.transform.position, player.transform.position) < initAggroRadius) 
                    && (enemyState.elementState == ElementState.Normal))
                {
                    searchPlayerRoutine = StartCoroutine(FiniteLookForPlayer());
                    state = EnemyState.Approach;
                }
                
                break;
            case EnemyState.Approach:
                
                if (Vector3.Distance(this.transform.position, player.transform.position) > aggroRadius)
                {
                    navMeshAgent.isStopped = true;
                    if (searchPlayerRoutine is not null) StopCoroutine(searchPlayerRoutine);
                    state = EnemyState.Idle;
                }

                if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                {
                    if (searchPlayerRoutine is not null) StopCoroutine(searchPlayerRoutine);
                    StartCoroutine(EndAttack());
                    state = EnemyState.Attack;
                }
                
                break;
            case EnemyState.Attack:
                break;
        }
    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
        if (enemyState.elementState == ElementState.Normal) state = EnemyState.Approach;
    }

    public void MeleeAttack()
    {
        Physics.OverlapSphereNonAlloc(attackPosition.position, attackRadius, hitColliders, playerMask);

        foreach (Collider c in hitColliders)
        {
            if (c is null) continue;
            
            if (c.TryGetComponent(out IDamageable damageable))
            {
                damageable.OnDamage(damage);
            }
        }
    }

    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.1f);
        MeleeAttack();
        yield return new WaitForSeconds(0.8f);
        searchPlayerRoutine = StartCoroutine(FiniteLookForPlayer());
        state = EnemyState.Approach;
    }

    private IEnumerator FiniteLookForPlayer()
    {
        navMeshAgent.isStopped = false;
        while (true)
        {
            navMeshAgent.SetDestination(player.transform.position);
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    public override void OnDie()
    {
        enemyLoot.DropLoot();
        Destroy(gameObject);
    }
    
    public override void OnFreeze()
    {
        base.OnFreeze();
        state = EnemyState.Idle;
    }

    protected override void OnEndFreeze()
    {
        base.OnEndFreeze();
        state = EnemyState.Approach;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, initAggroRadius);
        Gizmos.color = Color.forestGreen;
        Gizmos.DrawWireSphere(this.transform.position, aggroRadius);
        Gizmos.color = Color.darkBlue;
        Gizmos.DrawWireSphere(attackPosition.position, attackRadius);
    }
}
