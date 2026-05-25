using UnityEngine;

[CreateAssetMenu(fileName = "ASFireball", menuName = "ScriptableObjects/ASFireball")]
public class ASFireball : PlayerSkill
{
    [SerializeField] private GameObject fireballObj;
    [SerializeField] private LayerMask projectileMask;
    [SerializeField] private int damage;

    public override void ExecuteSkill(Vector3 mouseRayHit)
    {
        base.ExecuteSkill();

        Transform castPoint = GamemodeBase.Instance.GetPlayer().castPoint;
        
        Projectile projectile = Instantiate(fireballObj, castPoint.position, castPoint.rotation).GetComponent<Projectile>();
        projectile.transform.parent = null;
       
        Vector3 shootDir = (mouseRayHit - castPoint.position);
        shootDir.y = 0;

        projectile.Init(shootDir.normalized, damage);
    }
}
