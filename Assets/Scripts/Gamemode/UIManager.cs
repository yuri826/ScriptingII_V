using System;
using UI;
using UnityEngine;

[Serializable]
public class UIManager : GamemodeSubsystem
{
    [Header("Dialogue")]
    [SerializeField] private DialogueManagerNew dialogueManager;

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

    [Header("GameOver")] 
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Animator transitionAnim;
 
    [Header("Win")] 
    [SerializeField] private GameObject winCanvas;
    
    public PlayerInventory GetPlayerInventory()
    {
        return playerInventory;
    }

    public void DialogueClick()
    {
        dialogueManager.OnClick();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueManager.StartStory(dialogue);
    }

    public void OpenInventory()
    {
        if (isSkillTreeOpened || isShopOpened) return;

        isInventoryOpened = !isInventoryOpened;
        gamemodeParent.GetHUD().CloseHotbarInstant();
        
       // if (isInventoryOpened) gamemodeParent.GetInputManager().EnableHUDInteraction();
        //else gamemodeParent.GetInputManager().DisableHUDInteraction();
        
        inventoryPanel.SetActive(isInventoryOpened);
        inventoryInfoPanel.SetActive(false);
    }

    public void OpenSkillTree()
    {
        if (isInventoryOpened || isShopOpened) return;
        
        //if (isSkillTreeOpened) gamemodeParent.GetInputManager().EnableHUDInteraction();
        // gamemodeParent.GetInputManager().DisableHUDInteraction();

        isSkillTreeOpened = !isSkillTreeOpened;
        skillTreePanel.SetActive(isSkillTreeOpened);
        skillTreeInfoPanel.SetActive(false);
    }

    public void OpenShopMenu(ShopData shopData)
    {
        gamemodeParent.GetHUD().CloseHotbarInstant();
        
        //Inventory
        isInventoryOpened = false;
        inventoryPanel.SetActive(false);
        inventoryInfoPanel.SetActive(false);
        
        //SkillTree
        isSkillTreeOpened = false;
        skillTreePanel.SetActive(false);
        skillTreeInfoPanel.SetActive(false);
        
        //gamemodeParent.GetInputManager().EnableHUDInteraction();

        isShopOpened = true;
        //gamemodeParent.GetInputManager().DisableGameplay();
        shopManager.ShowMenu(shopData);
    }
    
    public void CloseMenus()
    {
        //gamemodeParent.GetInputManager().EnableGameplay();
        
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

    public void CloseShop()
    {
        isShopOpened = false;
    }

    public void OnDie()
    {
        CloseMenus();
        ShowGameover();
    }

    private void ShowGameover()
    {
        gameOverCanvas.SetActive(true);
    }

    public void TransitionIn()
    {
        transitionAnim.SetTrigger("TransitionIn");
    }

    public void OnWin()
    {
        winCanvas.SetActive(true);
    }
}
