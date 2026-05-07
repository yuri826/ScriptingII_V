using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkill", menuName = "ScriptableObjects/PlayerSkill")]
public class PlayerSkill : ScriptableObject
{
    [field: SerializeField] public Sprite icon { get; private set; }
    [field: SerializeField] public SkillType skillType { get; private set; }
    [field: SerializeField] public int buyCost { get; private set; }
    [field: SerializeField] public int manaCost { get; private set; }
        
    public virtual void ExecuteSkill()
    {
        PlayerState playerState = GamemodeBase.Instance.GetPlayerState();
        
        Debug.Log(playerState);
        
        if (playerState.currentMana < manaCost) return;
        
        playerState.ChangeMana(-manaCost);

        //Check if player is at a nice distance
        //Move / continue
        //ExecuteSkill
    }
}
