using System;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class PlayerSkillManager: GamemodeSubsystem
{
    private List<PlayerSkill> allPlayerSkills = new List<PlayerSkill>();
    private List<PlayerSkill> allPlayerActiveSkills = new List<PlayerSkill>();
    private List<PlayerSkill> allPlayerPassiveSkills = new List<PlayerSkill>();

    [SerializeField] private PlayerSkill activeSkill1;
    [SerializeField] private PlayerSkill activeSkill2;
    private PlayerSkill activeSkill3;
    private PlayerSkill currentActiveSkill;
    
    private PlayerSkill passiveSkill1;
    private PlayerSkill passiveSkill2;
    private PlayerSkill passiveSkill3;

    [SerializeField] private Transform skillPool;
    [SerializeField] private GameObject skillPoolEntryPrefab;
    [SerializeField] private SkillHotbarManager hotbarManager;

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
        AudioManager.Instance.PlaySFX(currentActiveSkill.sfx);
        currentActiveSkill?.ExecuteSkill(mouseRayHit);
    }

    public void ExecuteCurrentSkillMouse(Vector3 mouseRayHit)
    {
        AudioManager.Instance.PlaySFX(currentActiveSkill.sfx);        
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
        
        //gamemodeParent.InstantiateSkillEntry(skill, skillPool, skillPoolEntryPrefab);
        
        SkillHotbarIcon skillEntry = GameObject.Instantiate(skillPoolEntryPrefab, skillPool).GetComponent<SkillHotbarIcon>();
        skillEntry.skill = skill;
        hotbarManager.AddIcon(skillEntry);

        if (skill.skillType == SkillType.Active)
            allPlayerActiveSkills.Add(skill);
        else
            allPlayerPassiveSkills.Add(skill);
    }
}
