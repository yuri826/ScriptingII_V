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
    
    public delegate void OnPauseInput();
    public OnPauseInput onPause;
    
    public delegate void OnEquipActiveSkill1(int skillN);
    public OnEquipActiveSkill1 onActiveSkill1;
    
    public delegate void OnEquipActiveSkill2(int skillN);
    public OnEquipActiveSkill2 onActiveSkill2;
    
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
    }

    public void OnLClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            var mousePos = context.ReadValue<Vector2>();
            onClickStarted?.Invoke(mousePos);
        }
    }

    public void OnMousePosition(InputAction.CallbackContext context){}

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started) onPause?.Invoke();
    }

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
    public void OnInventory(InputAction.CallbackContext context){}
    
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed) onMove?.Invoke(context.ReadValue<Vector2>());
        if (context.canceled) onStopMovement?.Invoke(Vector2.zero);
    }

    public void EnableHUDInteraction()
    {
        inputActions.Gameplay.Disable();
        inputActions.HUDInteraction.Enable();
    }
    
    public void DisableHUDInteraction()
    {
        inputActions.Gameplay.Enable();
        inputActions.HUDInteraction.Disable();
    }

    public void OnHUDClick(InputAction.CallbackContext context){}
}
