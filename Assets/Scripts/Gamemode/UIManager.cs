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

    public void OpenInventory(bool open)
    {
        if (isSkillTreeOpened || isShopOpened) return;
        
        gamemodeParent.GetHUD().CloseHotbarInstant();
        
        inventoryPanel.SetActive(open);
        inventoryInfoPanel.SetActive(false);
    }

    public void OpenSkillTree(bool open)
    {
        if (isInventoryOpened || isShopOpened) return;
        
        skillTreePanel.SetActive(open);
        skillTreeInfoPanel.SetActive(false);
    }

    public void OpenShopMenu(ShopData shopData)
    {
        gamemodeParent.GetHUD().CloseHotbarInstant();
        
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
