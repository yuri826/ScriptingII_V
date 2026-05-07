using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class HUD : GamemodeSubsystem
{
    [Header("Skills")]
    [SerializeField] private GameObject ActiveSlot1;
    [SerializeField] private GameObject ActiveSlot2;
    [SerializeField] private GameObject PassiveSlot1;
    [SerializeField] private GameObject PassiveSlot2;
    
    [SerializeField] private GameObject ActiveSelection;

    [Header("Mana")] [SerializeField] private Image manaImage;
    [Header("Health")] [SerializeField] private Image healthImage;
    
    public void EquipSkill(int activeSkillN)
    {
        ActiveSelection.transform.SetParent(activeSkillN == 0 ? ActiveSlot1.transform : ActiveSlot2.transform);
        ActiveSelection.transform.localPosition = Vector3.zero;
    }
    
    public void ShowSkillHotbar()
    {
        
    }
    
    public void HideSkillHotbar()
    {
        
    }

    public void UpdateMana(int current, int max)
    {
        manaImage.fillAmount =  current/max;
    }
    
    public void UpdateHealth(int current, int max)
    {
        healthImage.fillAmount =  current/max;
    }
}
