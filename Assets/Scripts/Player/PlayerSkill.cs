using FMODUnity;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkill", menuName = "ScriptableObjects/PlayerSkill")]
public class PlayerSkill : ScriptableObject
{
    [field: SerializeField] public Sprite icon { get; private set; }
    [field: SerializeField] public string name { get; private set; }
    [field: SerializeField] public string description { get; private set; }
    [field: SerializeField] public SkillType skillType { get; private set; }
    [field: SerializeField] public int buyCost { get; private set; }
    [field: SerializeField] public int manaCost { get; private set; }
    [field: SerializeField] public EventReference sfx { get; private set; }

    protected virtual void ExecuteSkill()
    {
        PlayerState playerState = GamemodeBase.Instance.GetPlayerState();
        
        if (playerState.currentMana < manaCost) return;
        
        playerState.ChangeMana(-manaCost);

        //Check if player is at a nice distance
        //Move / continue
        //ExecuteSkill
    }
    
    public virtual void ExecuteSkill(Vector3 mouseRayHit)
    {
        PlayerState playerState = GamemodeBase.Instance.GetPlayerState();
        
        if (playerState.currentMana < manaCost) return;
        
        playerState.ChangeMana(-manaCost);
    
        //Check if player is at a nice distance
        //Move / continue
        //ExecuteSkill
    }
}
