using UnityEngine;

[CreateAssetMenu(fileName = "ASRockRain", menuName = "ScriptableObjects/ASRockRain")]
public class ASRockRain : PlayerSkill
{
    [SerializeField] private GameObject rockObj;
    [SerializeField] private int damage;
    
    public override void ExecuteSkill(Vector3 mouseRayHit)
    {
        base.ExecuteSkill();

        Vector3 castPoint = GamemodeBase.Instance.GetPlayer().transform.position;
        castPoint += new Vector3(0, 15, 0);
       
        for (int i = 0; i < 10; i++)
        {
            Vector3 newCastPoint = castPoint + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Projectile projectile = Instantiate(rockObj, newCastPoint, Quaternion.identity).GetComponent<Projectile>();
            projectile.Init(Vector3.down, damage);
        }
    }
}
