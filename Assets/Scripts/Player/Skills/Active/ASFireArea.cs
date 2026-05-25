using UnityEngine;

[CreateAssetMenu(fileName = "ASFireball", menuName = "ScriptableObjects/ASFireballArea")]
public class ASFireArea : PlayerSkill
{
    [SerializeField] private GameObject fireAreaObj;
    [SerializeField] private int damage;
    [SerializeField] private float timeToVanish;
    [SerializeField] private float frequency;

    public override void ExecuteSkill(Vector3 mouseRayHit)
    {
        base.ExecuteSkill();

        Transform castPoint = GamemodeBase.Instance.GetPlayer().transform;
        
        DamageArea area = Instantiate(fireAreaObj, castPoint.position, castPoint.rotation).GetComponent<DamageArea>();
        area.Init(damage, timeToVanish, frequency);
    }
} 
