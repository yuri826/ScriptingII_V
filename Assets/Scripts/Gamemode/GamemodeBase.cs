using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Player;

public class GamemodeBase : MonoBehaviour
{
    public static GamemodeBase Instance { get; private set; }
    
    private GameState gameState = GameState.Moving;

    [SerializeField] private PlayerLogic playerPawn;
    [SerializeField] private PlayerCursor playerCursor;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerSkillManager skillManager;
    [SerializeField] private HUD gameHUD;
    [SerializeField] private PlayerState playerState;

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
            case GameState.Moving: playerCursor.OnLClick(mousePos);
                break;
            
            case GameState.OnDialogue: uiManager.DialogueClick(); 
                break;
        }
    }
    
    public void OnEquipActiveSkill(int skillN)
    {
        gameHUD.EquipSkill(skillN);
        skillManager.EquipSkill(skillN);
    }

    public void StartDialogue(TextAsset inkStory)
    {
        gameState = GameState.OnDialogue;
        uiManager.StartDialogue(inkStory);
    }

    public void EndDialogue() 
    {
        gameState = GameState.Moving;
    }

    public PlayerLogic GetPlayer() {
        return playerPawn;
    }

    public UIManager GetUiManager() {
        return uiManager;
    }
    
    public HUD GetHUD() {
        return gameHUD;
    }
    
    public PlayerSkillManager GetSkillManager() {
        return skillManager;
    }

    public PlayerState GetPlayerState() {
        return playerState;
    }

    public InputManager GetInputManager()
    {
        return inputManager;
    }
}
