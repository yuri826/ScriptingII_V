using System;
using UnityEngine;

[Serializable]
public class PlayerState : GamemodeSubsystem
{
    [Header("Mana")]
    [field: SerializeField] public int maxMana { get; set; }
    public int currentMana { get; set; }
    [field: SerializeField]public int manaRegen { get; set; }
    [field: SerializeField]public float manaRegenTime { get; set; }
    
    [Header("HP")]
    [field: SerializeField] public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    [field: SerializeField] public int healthRegen { get; set; }
    [field: SerializeField]public float healthRegenTime { get; set; }
    
    [Header("XP")]
    [field: SerializeField] public int XP { get; set; }

    [Header("Money")]
    [field: SerializeField] public int money { get; set; }
    
    public override void OnAwake()
    {
        currentMana = maxMana;
        currentHealth = maxHealth;
        
        ChangeXp(XP);
        ChangeHealth(currentHealth);
        ChangeMana(currentMana);
        ChangeMoney(money);
    }

    public void ChangeMana(int value)
    {
        currentMana += value;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        gamemodeParent.GetHUD().UpdateMana(currentMana, maxMana);
    }

    public void FillMana(int value)
    {
        currentMana = maxMana;
        gamemodeParent.GetHUD().UpdateMana(currentMana, maxMana);
    }
    
    public void ChangeMaxMana(int value)
    {
        maxMana += value;
        gamemodeParent.GetHUD().UpdateMana(currentMana, maxMana);
    }
    
    public void ChangeHealth(int value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        gamemodeParent.GetHUD().UpdateMana(currentHealth, maxHealth);
    }

    public void FillHealth(int value)
    {
        currentHealth = maxHealth;
        gamemodeParent.GetHUD().UpdateMana(currentHealth, maxHealth);
    }
    
    public void ChangeMaxHealth(int value)
    {
        currentHealth += value;
        gamemodeParent.GetHUD().UpdateMana(currentHealth, maxHealth);
    }

    public void ChangeMoney(int value)
    {
        money += value;
        gamemodeParent.GetHUD().UpdateMoney(money);
    }
    
    public void ChangeXp(int value)
    {
        XP += value;
        gamemodeParent.GetHUD().UpdateXP(XP);
    }
}
