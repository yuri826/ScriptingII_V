using System;
using UI;
using UnityEngine;

[Serializable]
public class UIManager : GamemodeSubsystem
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private DialogueManager dialogueManager;

    public PlayerInventory GetPlayerInventory()
    {
        return playerInventory;
    }

    public void DialogueClick()
    {
        dialogueManager.OnClick();
    }
}
