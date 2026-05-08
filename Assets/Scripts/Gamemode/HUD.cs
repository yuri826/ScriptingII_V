using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class HUD : GamemodeSubsystem
{
    [Header("Skills")]
    [SerializeField] private Button ActiveSlot1;
    [SerializeField] private Image ActiveSlot1Icon;
    [SerializeField] private Button ActiveSlot2;
    [SerializeField] private Image ActiveSlot2Icon;
    [SerializeField] private GameObject PassiveSlot1;
    [SerializeField] private GameObject PassiveSlot2;
    
    [SerializeField] private GameObject ActiveSelection;

    [Header("Mana")] [SerializeField] private Image manaImage;
    [Header("Health")] [SerializeField] private Image healthImage;
    
    [Header("SkillHotbar")]
    [SerializeField] private Transform skillHotbarPool;
    [SerializeField] private SkillHotbarManager skillHotbar;
    private bool isSkillHotbarOpen;

    public override void OnAwake()
    {
        foreach (Transform t in skillHotbarPool)
        {
            if (t.TryGetComponent(out SkillHotbarIcon skillHotbarIcon))
            {
                skillHotbar.hotbarIcons?.Add(skillHotbarIcon);
            }
        }
    }

    public override void OnEnable()
    {
        ActiveSlot1.onClick.AddListener(() => ShowSkillHotbar(ActiveSlot1.transform, 0));
        ActiveSlot2.onClick.AddListener(() => ShowSkillHotbar(ActiveSlot2.transform, 1));
    }

    public void EquipSkill(int activeSkillN)
    {
        ActiveSelection.transform.SetParent(activeSkillN == 0 ? ActiveSlot1.transform : ActiveSlot2.transform);
        ActiveSelection.transform.localPosition = Vector3.zero;
    }
    
    public void ShowSkillHotbar(Transform caller, int slotN)
    {
        Debug.Log("Show Skill Hotbar1");
        
        if (skillHotbar.isOpening) return;
        Debug.Log("Show Skill Hotbar2");
            
        if (isSkillHotbarOpen)
        {
            isSkillHotbarOpen = false;
            skillHotbar.HideIcons();
        }
        else
        {
            isSkillHotbarOpen = true;
            skillHotbar.ShowIcons(caller, slotN);
        }
    }

    public void UpdateMana(int current, int max)
    {
        manaImage.fillAmount =  (float)current/max;
    }
    
    public void UpdateHealth(int current, int max)
    {
        healthImage.fillAmount =  (float)current/max;
    }

    public void ChangeSkill(int slot, Sprite skillIcon)
    {
        switch (slot)
        {
            case 0:
                ActiveSlot1Icon.sprite = skillIcon;
                break;
            
            case 1:
                ActiveSlot2Icon.sprite = skillIcon;
                break;
        }
    }
}
