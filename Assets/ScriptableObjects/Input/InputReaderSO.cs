using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject, PlayerInputActions.IGameplayActions
{
    private PlayerInputActions inputActions;
    
    public delegate void OnClickStarted(Vector2 mousePos);
    public OnClickStarted onClickStarted;
    
    private void OnEnable()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.Gameplay.Enable();
        inputActions.Gameplay.AddCallbacks(this);
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

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }
}
