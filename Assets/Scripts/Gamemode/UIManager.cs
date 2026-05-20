using System;
using UI;
using UnityEngine;

[Serializable]
public class UIManager : GamemodeSubsystem
{
    [Header("Dialogue")]
    [SerializeField] private DialogueManager dialogueManager;

    [Header("SkillTree")]
    private bool isSkillTreeOpened = false;
    [SerializeField] private GameObject skillTreePanel;
    [SerializeField] private GameObject skillTreeInfoPanel;
    
    [Header("Inventory")]
    [SerializeField] private PlayerInventory playerInventory;
    private bool inInventoryOpened = false;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryInfoPanel;

    [Header("Shop")] 
    [SerializeField] private ShopMenuManager shopManager;
 
    public PlayerInventory GetPlayerInventory()
    {
        return playerInventory;
    }

    public void DialogueClick()
    {
        Debug.Log("Dialogue Click");
        dialogueManager.OnClick();
    }
    
    public void StartDialogue(TextAsset inkStory)
    {
        dialogueManager.StartStory(inkStory);
    }

    public void OpenInventory()
    {
        if (isSkillTreeOpened) return;
        
        inInventoryOpened = !inInventoryOpened;
        
        if (inInventoryOpened) gamemodeParent.GetInputManager().DisableGameplay();
        else  gamemodeParent.GetInputManager().EnableGameplay();
        
        inventoryPanel.SetActive(inInventoryOpened);
        inventoryInfoPanel.SetActive(false);
    }

    public void OpenSkillTree()
    {
        if (inInventoryOpened) return;
        
        isSkillTreeOpened = !isSkillTreeOpened;
        
        if (isSkillTreeOpened) gamemodeParent.GetInputManager().DisableGameplay();
        else  gamemodeParent.GetInputManager().EnableGameplay();
        
        skillTreePanel.SetActive(isSkillTreeOpened);
        skillTreeInfoPanel.SetActive(false);
    }

    public void OpenShopMenu(ShopData shopData)
    {
        gamemodeParent.GetInputManager().DisableGameplay();
        shopManager.ShowMenu(shopData);
    }
    
    public void CloseMenus()
    {
        gamemodeParent.GetInputManager().EnableGameplay();
        shopManager.HideMenu();
    }
}
