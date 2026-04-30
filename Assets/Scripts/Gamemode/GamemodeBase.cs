using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Player;

public class GamemodeBase : MonoBehaviour
{
    public static GamemodeBase Instance { get; private set; }
    
    private GameState gameState = GameState.OnDialogue;

    [SerializeField] private PlayerLogic playerPawn;
    [SerializeField] private PlayerCursor playerCursor;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private InputManager inputManager;

    private void Awake()
    {
        Instance = this;

        uiManager.gamemodeParent = this;
        inputManager.gamemodeParent = this;
        
        uiManager.OnAwake();
        inputManager.OnAwake();
    }

    private void OnEnable()
    {
        uiManager.OnEnable();
        inputManager.OnEnable();
    }

    public void OnLClick(Vector2 mousePos)
    {
        switch (gameState)
        {
            case  GameState.Moving: playerCursor.OnLClick(mousePos);
                break;
            
            case GameState.OnDialogue: uiManager.DialogueClick(); 
                break;
        }
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
