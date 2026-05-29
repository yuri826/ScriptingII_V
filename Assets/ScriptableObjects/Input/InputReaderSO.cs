using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject, PlayerInputActions.IGameplayActions, PlayerInputActions.IHUDInteractionActions
{
    private PlayerInputActions inputActions;
    
    public delegate void OnMove(Vector2 inputDir);
    public OnMove onMove;
    
    public delegate void OnStopMovement(Vector2 inputDir);
    public OnStopMovement onStopMovement;
    
    public delegate void OnClickStarted(Vector2 mousePos);
    public OnClickStarted onClickStarted;
    
    public delegate void OnUILClick(Vector2 mousePos);
    public OnUILClick onUIClick;
    
    public delegate void OnPauseInput();
    public OnPauseInput onPause;
    
    public delegate void OnEquipActiveSkill1(int skillN);
    public OnEquipActiveSkill1 onActiveSkill1;
    
    public delegate void OnEquipActiveSkill2(int skillN);
    public OnEquipActiveSkill2 onActiveSkill2;

    public delegate void OnEscapeAction();
    public OnEscapeAction onEscape;
    
    private PlayerInputActions.IHUDInteractionActions ihudInteractionActionsImplementation;

    private void OnEnable()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.Gameplay.Enable();
        inputActions.Gameplay.AddCallbacks(this);
        inputActions.HUDInteraction.Disable();
        inputActions.HUDInteraction.AddCallbacks(this);
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Gameplay.Disable();
        inputActions.Gameplay.RemoveCallbacks(this);
        inputActions.HUDInteraction.RemoveCallbacks(this);
    }
    
    #region Basic

    public void OnLClick(InputAction.CallbackContext context)
    {
        if (context.started) onClickStarted?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnMousePosition(InputAction.CallbackContext context){}
    
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed) onMove?.Invoke(context.ReadValue<Vector2>());
        if (context.canceled) onStopMovement?.Invoke(Vector2.zero);
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.started) onEscape?.Invoke();
    }

    public void OnUIClick(InputAction.CallbackContext context)
    {
        if (context.started) onClickStarted?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started) onPause?.Invoke();
    }
    
    #endregion

    #region Skills

    public void OnActiveSkill1(InputAction.CallbackContext context)
    {
        if (context.started) onActiveSkill1?.Invoke(0);
    }

    public void OnActiveSkill2(InputAction.CallbackContext context)
    {
        if (context.started) onActiveSkill2?.Invoke(1);
    }

    public void OnPassiveSkill1(InputAction.CallbackContext context){}
    public void OnPassiveSkill2(InputAction.CallbackContext context){}

    #endregion

    #region Mappings / actions
    
    public void EnableHUDInteraction()
    {
        inputActions.FindAction("LClick").Disable();
    }
    
    public void DisableHUDInteraction()
    {
        if (inputActions.Gameplay.enabled) inputActions.FindAction("LClick").Enable();
    }

    public void DisableGameplay()
    {
        inputActions.Gameplay.Disable();
        inputActions.HUDInteraction.Enable();

        //Para el movimiento del jugador
        InputAction.CallbackContext fakeCtx = new InputAction.CallbackContext();
        OnMovement(fakeCtx);
    }
    
    public void EnableGameplay()
    {
        inputActions.Gameplay.Enable();
        //inputActions.FindAction("LClick").Enable();
        inputActions.HUDInteraction.Disable();
    }
    
    #endregion
}
