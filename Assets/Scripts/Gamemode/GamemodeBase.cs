using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamemodeBase : MonoBehaviour
{
    public static GamemodeBase Instance { get; private set; }

    [SerializeField] private PlayerLogic playerPawn;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        Instance = this;
    }

    public PlayerLogic GetPlayer()
    {
        return playerPawn;
    }
    
    public UIManager GetUiManager()
    {
        return uiManager;
    }
}
