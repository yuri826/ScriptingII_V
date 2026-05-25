using Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = "ASFireBurst", menuName = "ScriptableObjects/ASFireBurst")]
public class ASFireBurst:PlayerSkill
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask projectileMask;
    [SerializeField] private int damage;
    [SerializeField] private GameObject particles;
    
    private Collider[] attackCols = new Collider[10];

    public override void ExecuteSkill(Vector3 mouseRayHit)
    {
        base.ExecuteSkill();

        Transform castPoint = GamemodeBase.Instance.GetPlayer().transform;
       
        Destroy(Instantiate(particles, castPoint), 3f);
        
        Physics.OverlapSphereNonAlloc(castPoint.position, radius, attackCols,  projectileMask);

        for (int i = 0; i < attackCols.Length; i++)
        {
            if (attackCols[i].TryGetComponent(out IDamageable damageable))
            {
                damageable.OnDamage(damage);
            }
        }
    }
}
