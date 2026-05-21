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
    private bool isInventoryOpened = false;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryInfoPanel;

    [Header("Shop")] 
    private bool isShopOpened = false;
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
        if (isSkillTreeOpened || isShopOpened) return;
        
        isInventoryOpened = !isInventoryOpened;
        
        if (isInventoryOpened) gamemodeParent.GetInputManager().DisableGameplay();
        else  gamemodeParent.GetInputManager().EnableGameplay();
        
        inventoryPanel.SetActive(isInventoryOpened);
        inventoryInfoPanel.SetActive(false);
    }

    public void OpenSkillTree()
    {
        if (isInventoryOpened || isShopOpened) return;
        
        isSkillTreeOpened = !isSkillTreeOpened;
        
        if (isSkillTreeOpened) gamemodeParent.GetInputManager().DisableGameplay();
        else  gamemodeParent.GetInputManager().EnableGameplay();
        
        skillTreePanel.SetActive(isSkillTreeOpened);
        skillTreeInfoPanel.SetActive(false);
    }

    public void OpenShopMenu(ShopData shopData)
    {
        CloseMenus();
        isShopOpened = true;
        gamemodeParent.GetInputManager().DisableGameplay();
        shopManager.ShowMenu(shopData);
    }
    
    public void CloseMenus()
    {
        gamemodeParent.GetInputManager().EnableGameplay();
        
        //Inventory
        isInventoryOpened = false;
        inventoryPanel.SetActive(false);
        inventoryInfoPanel.SetActive(false);
        
        //SkillTree
        isSkillTreeOpened = false;
        skillTreePanel.SetActive(false);
        skillTreeInfoPanel.SetActive(false);
        
        //Shop
        isShopOpened = false;
        shopManager.HideMenu();
    }
}
