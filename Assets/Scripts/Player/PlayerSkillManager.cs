using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSkillManager: GamemodeSubsystem
{
    private List<PlayerSkill> allPlayerSkills;
    private List<PlayerSkill> allPlayerActiveSkills;
    private List<PlayerSkill> allPlayerPassiveSkills;

    [SerializeField] private PlayerSkill activeSkill1;
    [SerializeField] private PlayerSkill activeSkill2;
    private PlayerSkill activeSkill3;
    private PlayerSkill currentActiveSkill;
    
    private PlayerSkill passiveSkill1;
    private PlayerSkill passiveSkill2;
    private PlayerSkill passiveSkill3;

    public override void OnAwake()
    {
        currentActiveSkill = activeSkill1;
    }

    public void EquipSkill(int activeSkillN)
    {
        currentActiveSkill = activeSkillN == 0 ? activeSkill1 : activeSkill2;
    }
    
    public void ExecuteCurrentSkill(Vector3 mouseRayHit)
    {
        currentActiveSkill?.ExecuteSkill(mouseRayHit);
    }

    public void ExecuteCurrentSkillMouse(Vector3 mouseRayHit)
    {
        currentActiveSkill?.ExecuteSkill(mouseRayHit);
    }

    public void SetSkill(int slot, PlayerSkill skill)
    {
        switch (slot)
        {
            case 0:
                activeSkill1 = skill;
                break;
            case 1: 
                activeSkill2 = skill; 
                break;
        }
        
        GamemodeBase.Instance.GetHUD().ChangeSkill(slot, skill.icon);
    }

    public void AddSkill(PlayerSkill skill)
    {
        allPlayerSkills.Add(skill);

        if (skill.skillType == SkillType.Active)
            allPlayerActiveSkills.Add(skill);
        else
            allPlayerPassiveSkills.Add(skill);
    }
}
