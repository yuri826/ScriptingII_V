using System;
using UI;
using UnityEngine;

[Serializable]
public class UIManager : GamemodeSubsystem
{
    [SerializeField] private PlayerInventory playerInventory;

    public PlayerInventory GetPlayerInventory()
    {
        return playerInventory;
    }
}
