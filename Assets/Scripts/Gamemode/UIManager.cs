using System;
using UI;
using UnityEngine;

[Serializable]
public class UIManager : GamemodeSubsystem
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private DialogueManager dialogueManager;

    private bool isSkillTreeOpened = false;
    [SerializeField] private GameObject skillTreePanel;
    [SerializeField] private GameObject skillTreeInfoPanel;
    private bool inInventoryOpened = false;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryInfoPanel;
 
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
}
