using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Player;

public class GamemodeBase : MonoBehaviour
{
    public static GamemodeBase Instance { get; private set; }

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
        playerCursor.OnLClick(mousePos); //Da MissingMethodException por qué si lo encuentra bien omg
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
