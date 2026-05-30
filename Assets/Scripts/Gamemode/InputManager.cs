using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class InputManager : GamemodeSubsystem
{
    [field: SerializeField] public InputReaderSO inputReader { get; private set; }

    public override void OnEnable()
    {
        inputReader.onClickStarted += gamemodeParent.OnLClick;
        inputReader.onUIClick += gamemodeParent.OnLClick;
        inputReader.onPause += gamemodeParent.OnPause;
        inputReader.onActiveSkill1 += gamemodeParent.OnEquipActiveSkill;
        inputReader.onActiveSkill2 += gamemodeParent.OnEquipActiveSkill;
        inputReader.onEscape += gamemodeParent.GetUiManager().CloseMenus;
    }
    
    public void EnableHUDInteraction()
    {
        inputReader.DisableGameplay();
        inputReader.EnableHUDInteraction(); 
    }

    public void DisableHUDInteraction()
    {
        inputReader.EnableGameplay();
        inputReader.DisableHUDInteraction();
    }
    
    public void EnableGameplay()
    {
        inputReader.EnableGameplay();
    }

    public void DisableGameplay()
    {
        inputReader.DisableGameplay();
    }

    public void DialogueInput()
    {
        inputReader.DisableGameplay();
    }

    public void OnDie()
    {
        DisableGameplay();
    }
}
