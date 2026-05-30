using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

using Player;
using UnityEngine.SceneManagement;

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

    public delegate void OnDie();
    public OnDie onDie;
    
    public delegate void OnWin();
    public OnWin onWin;

    private void Awake()
    {
        Instance = this;

        uiManager.gamemodeParent = this;
        inputManager.gamemodeParent = this;
        skillManager.gamemodeParent = this;
        gameHUD.gamemodeParent = this;
        playerState.gamemodeParent = this;
        
        uiManager.OnAwake();
        inputManager.OnAwake();
        skillManager.OnAwake();
        gameHUD.OnAwake();
        playerState.OnAwake();
    }

    private void OnEnable()
    {
        uiManager.OnEnable();
        inputManager.OnEnable();
        gameHUD.OnEnable();
    }

    private void Start()
    {
        onDie += uiManager.OnDie;
        onDie += gameHUD.OnDie;
        onDie += inputManager.OnDie;

        onWin += uiManager.OnWin;
        onWin += gameHUD.OnDie;
        onWin += inputManager.OnDie;
    }

    #region States

    public void StartManaRegen()
    {
        StartCoroutine(ManaRegenRoutine());
    }

    private IEnumerator ManaRegenRoutine()
    {
        while (playerState.currentMana < playerState.maxMana)
        {
            yield return new WaitForSeconds(playerState.manaRegenTime);
            playerState.ChangeMana(playerState.manaRegen);
        }
    }
    
    public void StartHealthRegen()
    {
        StartCoroutine(HealthRegenRoutine());
    }

    private IEnumerator HealthRegenRoutine()
    {
        while (playerState.currentHealth < playerState.maxHealth)
        {
            yield return new WaitForSeconds(playerState.healthRegenTime);
            playerState.ChangeMana(playerState.healthRegen);
        }
    }
    
    #endregion
    
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
    
    #region Skills
    
    public void OnEquipActiveSkill(int skillN)
    {
        gameHUD.EquipSkill(skillN);
        skillManager.EquipSkill(skillN);
    }

    #endregion

    #region UI

    public void OpenInventory()
    {
        uiManager.OpenInventory();
    }
    
    public void OpenSkillTree()
    {
        uiManager.OpenSkillTree();
    }

    #endregion
    
    #region Dialogues

    public void StartDialogue(Dialogue dialogue)
    {
        inputManager.DialogueInput();
        gameState = GameState.OnDialogue;
        
        gameHUD.HideHUD();
        gameHUD.CloseHotbarInstant();
        uiManager.StartDialogue(dialogue);
    }

    public void EndDialogue() 
    {
        gameHUD.ShowHUD();
        inputManager.EnableGameplay();
        gameState = GameState.Moving;
    }
    
    #endregion

    public void Restart()
    {
        uiManager.TransitionIn();
        StartCoroutine(LoadSceneTime(1, SceneManager.GetActiveScene().name));
    }

    public void Quit()
    {
        uiManager.TransitionIn();
        StartCoroutine(LoadSceneTime(1, "MainMenu"));
    }

    private IEnumerator LoadSceneTime(int time, string scene)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
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

    public void OnPause()
    {
        
    }
}
