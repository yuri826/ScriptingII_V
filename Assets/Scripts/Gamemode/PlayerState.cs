using System;
using UnityEngine;

[Serializable]
public class PlayerState : GamemodeSubsystem
{
    [field: SerializeField] public int maxMana { get; set; }
    public int currentMana { get; set; }
    
    [field: SerializeField] public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    
    [field: SerializeField] public int XP { get; set; }

    public override void OnAwake()
    {
        currentMana = maxMana;
        currentHealth = maxHealth;
        Debug.Log(currentMana);
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
}
