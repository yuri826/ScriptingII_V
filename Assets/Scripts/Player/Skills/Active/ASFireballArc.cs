using UnityEngine;

[CreateAssetMenu(fileName = "ASFireball", menuName = "ScriptableObjects/ASFireballArc")]
public class ASFireballArc : PlayerSkill
{
    [SerializeField] private GameObject fireballObj;
    [SerializeField] private LayerMask projectileMask;
    [SerializeField] private float damage;

    public override void ExecuteSkill(Vector3 mouseRayHit)
    {
        base.ExecuteSkill();

        Transform castPoint = GamemodeBase.Instance.GetPlayer().castPoint;
        
        Vector3 shootDirInit = (mouseRayHit - castPoint.position);
        shootDirInit.y = 0;

        shootDirInit = Quaternion.AngleAxis(-20, Vector3.up) * shootDirInit;

        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Shoot " + i);
            Projectile projectile =
                Instantiate(fireballObj, castPoint.position, castPoint.rotation).GetComponent<Projectile>();
            projectile.transform.parent = null;
            
            projectile.Init(shootDirInit.normalized, damage);
            
            shootDirInit = Quaternion.AngleAxis(10, Vector3.up) * shootDirInit;
        }
    }
}
