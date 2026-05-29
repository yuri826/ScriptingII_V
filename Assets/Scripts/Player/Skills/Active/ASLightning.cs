using UnityEngine;

[CreateAssetMenu(fileName = "ASLightning", menuName = "ScriptableObjects/ASLightning")]
public class ASLightning : PlayerSkill
{
    [SerializeField] private GameObject lightningObj;
    [SerializeField] private int damage;
    
    public override void ExecuteSkill(Vector3 mouseRayHit)
    {
        base.ExecuteSkill();

        Vector3 castPoint = mouseRayHit;
       
        Projectile projectile = Instantiate(lightningObj, castPoint, Quaternion.identity).GetComponent<Projectile>();
        projectile.Init(Vector3.down, damage);
        Destroy(projectile.gameObject, 0.2f);
    }
}
